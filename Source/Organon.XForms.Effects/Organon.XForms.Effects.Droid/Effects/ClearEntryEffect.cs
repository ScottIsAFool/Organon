using Android.Views;
using Android.Widget;
using Organon.XForms.Effects.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(ClearEntryEffect), nameof(ClearEntryEffect))]
namespace Organon.XForms.Effects.Droid.Effects
{
    public class ClearEntryEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            ConfigureControl();
        }

        protected override void OnDetached()
        {
        }

        private void ConfigureControl()
        {
            var editText = Control as EditText;
            if (editText == null) return;
            editText.SetCompoundDrawablesRelativeWithIntrinsicBounds(0, 0, Resource.Drawable.ic_clear_icon, 0);
            editText.SetOnTouchListener(new OnDrawableTouchListener());
        }
    }

    public class OnDrawableTouchListener : Java.Lang.Object, Android.Views.View.IOnTouchListener
    {
        public bool OnTouch(Android.Views.View v, MotionEvent e)
        {
            if (v is EditText && e.Action == MotionEventActions.Up)
            {
                var editText = (EditText)v;
                if (e.RawX >= (editText.Right - editText.GetCompoundDrawables()[2].Bounds.Width()))
                {
                    editText.Text = string.Empty;
                    return true;
                }
            }

            return false;
        }
    }
}