using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Docutain;
using Docutain.SDK;
using Docutain.SDK.Xamarin.Forms;
using Xamarin.Essentials;

namespace Docutain_SDK_Example_Xamarin
{
    public partial class App : Application
    {
        string licenseKey = "YOUR_LICENSE_KEY_HERE";        

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            if (!DocutainSDK.InitSDK(licenseKey))
            {
                //init of Docutain SDK failed, get the last error message
                System.Console.WriteLine("Initialization of the Docutain SDK failed: " + DocutainSDK.LastError);
                //your logic to deactivate access to SDK functionality
                if (licenseKey == "YOUR_LICENSE_KEY_HERE")
                {
                    ShowLicenseEmptyInfo();
                    return;
                }
            }
            //If you are using data extraction features, you can activate optional values
            //see https://docs.docutain.com/docs/Xamarin/dataExtraction for more details
            var analyzeConfig = new AnalyzeConfiguration
            {
                ReadBIC = true, //defaults to false
                ReadPaymentState = true //defaults to false
            };
            if (!DocumentDataReader.SetAnalyzeConfiguration(analyzeConfig))
            {
                System.Console.WriteLine("Setting AnalyzeConfiguration failed: " + DocutainSDK.LastError);
            }

            //Depending on your needs, you can set the Logger's level
            Logger.SetLogLevel(Logger.Level.Verbose);


            //Depending on the log level that you have set, some temporary files get written on the filesystem
            //You can delete all temporary files by using the following method
            DocutainSDK.DeleteTempFiles(true);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private async void ShowLicenseEmptyInfo()
        {
            if (await Current.MainPage.DisplayAlert("License empty", "A valid license key is required. Please click \"Get License\" in order to create a free trial license key on our website.", "Get License", "Cancel"))
            {
                try
                {
                    await Browser.OpenAsync("https://sdk.docutain.com/TrialLicense?Source=1442309", BrowserLaunchMode.External);
                }
                catch (Exception ex)
                {
                    // An unexpected error occured. No browser may be installed on the device.
                    System.Console.WriteLine("Open Browser failed: " + ex.ToString());
                }
            }
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
