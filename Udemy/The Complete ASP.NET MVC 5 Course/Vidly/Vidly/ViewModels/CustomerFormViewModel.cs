using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public string Title
        {
            get
            {
                return Customer.Id == 0 ? "New Customer" : "Edit Customer";
            }
        }
        public Customer Customer { get; set; }        
    }
}