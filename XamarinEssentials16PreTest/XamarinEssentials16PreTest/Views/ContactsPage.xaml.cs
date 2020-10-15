using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinEssentials16PreTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : ContentPage
    {
        public ContactsPage()
        {
            InitializeComponent();

            PickContactCommand = new Command(async () =>
            {
                await PickContactAsync();
            });

            BindingContext = this;
        }

        #region PickContact
        async Task PickContactAsync()
        {
            try
            {
                var contact = await Contacts.PickContactAsync();

                if (contact == null)
                    return;

                LoadContact(contact);
            }
            catch (Exception ex)
            {

            }
        }

        private void LoadContact(Contact contact)
        {
            Contact = contact;
        }

        private Contact _contact;
        public Contact Contact
        {
            get
            {
                return _contact;
            }
            set
            {
                _contact = value;
                OnPropertyChanged();
            }
        }

        public ICommand PickContactCommand { get; private set; }

        #endregion
    }
}