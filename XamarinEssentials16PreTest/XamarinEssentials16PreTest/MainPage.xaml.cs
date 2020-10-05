using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace XamarinEssentials16PreTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var permissionContactRead = await Permissions.CheckStatusAsync<Permissions.ContactsRead>();
            var permissionContactWrite = await Permissions.CheckStatusAsync<Permissions.ContactsWrite>();
            var selected =await Xamarin.Essentials.Contacts.PickContactAsync();

            if (selected is null)
                return;
        }
    }
}
