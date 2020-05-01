
using Android.App;
using Android.Content.PM;
using Android.OS;
using MobileCamoes.Infra;
using Plugin.CurrentActivity;
using System.IO;
using Xamarin.Forms;


namespace MobileCamoes.Droid
{
    [Activity(Label = "MobileCamoes", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

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

            LoadApplication(new App());
        }


        protected override void OnPause()
        {
            base.OnPause();
            System.Console.WriteLine("Aplicalçao em pausa");

        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnRestart()
        {
            base.OnRestart();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}