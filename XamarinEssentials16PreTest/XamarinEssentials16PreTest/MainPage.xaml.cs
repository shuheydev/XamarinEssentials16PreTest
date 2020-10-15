using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using XamarinEssentials16PreTest.Views;

namespace XamarinEssentials16PreTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void MediaPicker_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MediaPickerPage());
        }

        private void FilePicker_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FilePickerPage());
        }

        private void Contacts_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ContactsPage());
        }
    }
}
