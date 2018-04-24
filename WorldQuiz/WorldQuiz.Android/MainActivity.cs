
using Android.App;
using Android.Content.PM;
using Android.OS;
using System.IO;

namespace WorldQuiz.Droid
{
    [Activity(Label = "WorldQuiz", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            string fileName = "Country_db.sqlite";
            string fileLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fileFullPath = Path.Combine(fileLocation, fileName);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(fileFullPath));
        }
    }
}

