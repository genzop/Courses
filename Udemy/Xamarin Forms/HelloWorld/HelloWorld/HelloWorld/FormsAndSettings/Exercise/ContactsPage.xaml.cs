using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld.FormsAndSettings.Exercise
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactsPage : ContentPage
	{
        private ObservableCollection<Contact> Contacts;

		public ContactsPage ()
		{
			InitializeComponent ();
            Contacts = new ObservableCollection<Contact>
            {
                new Contact{Id = 1, FirstName = "Mosh", LastName = "Hamedani", Email = "moshhamedani@gmail.com", Phone = "+542615633456", IsBlocked = false },
                new Contact{Id = 2, FirstName = "Jonh", LastName = "Smith", Email = "johnsmith@gmail.com", Phone = "+54261434545", IsBlocked = true }
            };

            lvContacts.ItemsSource = Contacts;
		}

        private void AddContact_Clicked(object sender, EventArgs e)
        {
            ContactDetailsPage page = new ContactDetailsPage(new Contact());

            page.SaveButton.Clicked += (source, args) =>
            {
                var newContact = page.BindingContext as Contact;
                Contacts.Add(newContact);
                Navigation.PopAsync();
            };

            Navigation.PushAsync(page);
        }

        private void EditContact_Clicked(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedContact = e.SelectedItem as Contact;
            lvContacts.SelectedItem = null;           
            ContactDetailsPage page = new ContactDetailsPage(selectedContact);

            page.SaveButton.Clicked += (source, args) =>
            {
                var editedContact = page.BindingContext as Contact;
                selectedContact.FirstName = editedContact.FirstName;
                selectedContact.LastName = editedContact.LastName;
                selectedContact.Phone = editedContact.Phone;
                selectedContact.Email = editedContact.Email;
                selectedContact.IsBlocked = editedContact.IsBlocked;

                Navigation.PopAsync();
            };            

            Navigation.PushAsync(page);
        }

        private async void DeleteContact_Clicked(object sender, EventArgs e)
        {
            var confirmed = await DisplayAlert("Delete Contact", "Are you sure you want to delete this contact?", "Yes", "No");
            if (confirmed)
            {
                var contact = (sender as MenuItem).CommandParameter as Contact;
                Contacts.Remove(contact);
            }            
        }
	}
}