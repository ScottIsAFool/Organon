![Organon logo](Media/OrganonLogoL.png)
=======

Organon is a library of Effects for Xamarin.Forms.

Included effects:

| Effect                     | Description | iOS | Android | UWP |
|----------------------------|-------------|-----|---------|-----|
| CapitalizeKeyboardEffect | Enforces caps on the keyboard for an Entry | x | x | Todo |
| ClearEntryEffect | Adds a clear button to an Entry | x | x | - |
| RemoveBorderEffect | Removes the border from an Entry on iOS | x | - | Todo |
| RemoveEntryLineEffect | Removes the underline from an Entry on Android | - | x | - |
| ViewBlurEffect | Blur any view | Todo | Todo | x |


###### iOS

To use this on iOS you need to call

```
Organon.XForms.Effects.iOS.iOSEffects.Init();
```

from your AppDelegate. This ensures the assembly is loaded and the effects are available.

###### Samples

![ClearEntryEffect and CapitalizeKeyboardEffect](Media/ClearEntryAndAllCaps_thumb.gif) ![RemoveBorderEffect](Media/NoBorders_thumb.gif)

![Android Effects](Media/AndroidEffects_thumb.gif)