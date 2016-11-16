using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Organon.XForms.Effects.iOS.Effects;
using System.Reflection;

namespace Organon.XForms.SampleApp.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");

			//Be sure to let the iOS linker know we need this assembly!
			var cv = typeof(Organon.XForms.Effects.iOS.Effects.ClearEntryEffect);
			var assembly = Assembly.Load(cv.FullName);
			cv = typeof(Organon.XForms.Effects.ClearEntryEffect);
			assembly = Assembly.Load(cv.FullName);			
        }
    }
}
