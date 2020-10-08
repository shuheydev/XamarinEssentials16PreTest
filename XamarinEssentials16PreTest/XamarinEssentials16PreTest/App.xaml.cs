using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinEssentials16PreTest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage =new NavigationPage( new MainPage());

            Device.SetFlags(new string[] { "MediaElement_Experimental" });
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
    }
}
