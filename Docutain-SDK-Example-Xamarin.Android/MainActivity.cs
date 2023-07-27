using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Docutain;
using AndroidX.Core.Content;
using System;
using Xamarin.Forms;

namespace Docutain_SDK_Example_Xamarin.Droid
{
    [Activity(Label = "Docutain_SDK_Example_Xamarin", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            FormsMaterial.Init(this, savedInstanceState);
            //Set this line for the Docutain SDK
            Docutain.SDK.Xamarin.Forms.Platform.MainActivity = this;
            LoadApplication(new App());
            App.Current.RequestedThemeChanged += ApplyStatusBarColor;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void ApplyStatusBarColor(object sender, EventArgs args)
        {         
            if(Build.VERSION.SdkInt >= BuildVersionCodes.M)
                SetStatusBarColor(Resources.GetColor(Resource.Color.colorPrimary, Theme));
            else
                SetStatusBarColor(Resources.GetColor(Resource.Color.colorPrimary));
        }
    }
}