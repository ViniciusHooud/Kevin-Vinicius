using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Foundation;
using MobileCamoes.Infra;
using UIKit;

namespace MobileCamoes.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            AppSettings.OfflineDataBaseLiteDBPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "CamaoesMobile.db");
            AppSettings.OfflineDataBaseSQLitePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "CamaoesMobileSQLite.db");
            AppSettings.OfflineFileSystemPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "CamaoesMobileFile.txt");

            if (!File.Exists(AppSettings.OfflineDataBaseLiteDBPath))
            {
                File.Create(AppSettings.OfflineDataBaseLiteDBPath).Dispose();
            }

            if (!File.Exists(AppSettings.OfflineDataBaseSQLitePath))
            {
                File.Create(AppSettings.OfflineDataBaseSQLitePath).Dispose();
            }

            if (!File.Exists(AppSettings.OfflineFileSystemPath))
            {
                File.Create(AppSettings.OfflineFileSystemPath).Dispose();
            }

            return base.FinishedLaunching(app, options);
        }
    }
}
