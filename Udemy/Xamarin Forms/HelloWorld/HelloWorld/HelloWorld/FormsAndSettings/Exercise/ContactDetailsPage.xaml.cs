using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld.FormsAndSettings.Exercise
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactDetailsPage : ContentPage
	{
        public Button SaveButton { get { return btnSave; } }

        public ContactDetailsPage (Contact selectedContact)
		{
			InitializeComponent ();            

            BindingContext = new Contact
            {
                Id = selectedContact.Id,
                FirstName = selectedContact.FirstName,
                LastName = selectedContact.LastName,
                Phone = selectedContact.Phone,
                Email = selectedContact.Email,
                IsBlocked = selectedContact.IsBlocked
            };
		}
	}
}