using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Organon.XForms.Effects.iOS.Effects;
using UIKit;
using Foundation;

[assembly: ExportEffect(typeof(CapitalizeKeyboardEffect), nameof(CapitalizeKeyboardEffect))]

namespace Organon.XForms.Effects.iOS.Effects
{
    [Preserve]
	public class CapitalizeKeyboardEffect : PlatformEffect
	{
        private UITextAutocapitalizationType _old;

		protected override void OnAttached()
		{
            var editText = Control as UITextField;
			if (editText != null)
			{
                _old = editText.AutocapitalizationType;
                editText.AutocapitalizationType = UITextAutocapitalizationType.AllCharacters;
			}
		}

		protected override void OnDetached()
		{
			var editText = Control as UITextField;
			if (editText != null)
				editText.AutocapitalizationType = _old;
		}
	}
}
