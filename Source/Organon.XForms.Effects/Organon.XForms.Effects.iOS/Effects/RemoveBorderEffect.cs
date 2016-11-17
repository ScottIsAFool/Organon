using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Organon.XForms.Effects.iOS.Effects;
using UIKit;
using Foundation;

[assembly: ExportEffect(typeof(RemoveBorderEffect), nameof(RemoveBorderEffect))]

namespace Organon.XForms.Effects.iOS.Effects
{
    [Preserve]
	public class RemoveBorderEffect : PlatformEffect
	{
        private UITextBorderStyle _old;

		protected override void OnAttached()
		{
            var editText = Control as UITextField;
			if (editText != null)
			{
                _old = editText.BorderStyle;
                editText.BorderStyle = UITextBorderStyle.None;
			}
		}

		protected override void OnDetached()
		{
			var editText = Control as UITextField;
			if (editText != null)
				editText.BorderStyle = _old;
		}
	}
}
