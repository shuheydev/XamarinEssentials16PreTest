using System;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinEssentials16PreTest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            Device.SetFlags(new string[] { "MediaElement_Experimental" });
        }

        protected override async void OnStart()
        {
            try
            {
                await AppActions.SetAsync(
                    new AppAction("app_info", "App Info", icon: "launcher_foreground.png"),
                    new AppAction("battery_info", "Battery Info"));
            }
            catch (FeatureNotSupportedException ex)
            {
                Debug.WriteLine("App Actions not supported");
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
