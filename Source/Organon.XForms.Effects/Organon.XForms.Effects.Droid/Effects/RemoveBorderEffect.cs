using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Organon.XForms.Effects.Droid.Effects;
using Android.Runtime;

[assembly: ExportEffect(typeof(RemoveBorderEffect), nameof(RemoveBorderEffect))]

namespace Organon.XForms.Effects.Droid.Effects
{
    [Preserve]
    public class RemoveBorderEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
        }

        protected override void OnDetached()
        {
        }
    }
}