using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Resources;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Docutain_SDK_Example_Xamarin.DocutainPreferences;

namespace Docutain_SDK_Example_Xamarin.Controls
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwitchList : ViewCell
    {
        public string Key;
        public string Header { get; set; }
        public string Description { get; set; }
        public bool IsToggled { get; set; }

        public SwitchList(ScanSettings settings)
        {
            InitSwitchList(DocutainPreferences.SettingsKey(settings));
        }

        public SwitchList(EditSettings settings)
        {
            InitSwitchList(DocutainPreferences.SettingsKey(settings));
        }

        protected void InitSwitchList(string key)
        {
            InitializeComponent();
            Key = key;
            Header = AppResources.ResourceManager.GetString(Key);
            Description = AppResources.ResourceManager.GetString(Key + "_Description");
            IsToggled = DocutainPreferences.Get(Key);
            BindingContext = this;
        }

        public void Reload()
        {
            IsToggled = DocutainPreferences.Get(Key);
            SettingsSwitch.IsToggled = IsToggled;
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            DocutainPreferences.Set(Key, IsToggled);
        }
    }
}

