using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.Views;
using Organon.XForms.Effects.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(RemoveEntryLineEffect), "RemoveEntryLineEffect")]
namespace Organon.XForms.Effects.Droid.Effects
{
    public class RemoveEntryLineEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            ShapeDrawable shape = new ShapeDrawable(new RectShape());
            shape.Paint.Color = Android.Graphics.Color.Transparent;
            shape.Paint.StrokeWidth = 0;
            shape.Paint.SetStyle(Paint.Style.Stroke);
            Control.Background = shape;
        }

        protected override void OnDetached()
        {
            throw new System.NotImplementedException();
        }
    }
}