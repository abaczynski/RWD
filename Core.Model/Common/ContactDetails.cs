using Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Model.Common
{
    public class ContactDetails : ValueObject<ContactDetails>
    {
        public ContactDetails() {
            AddressDetails = new AddressDetails();
        }

        public string Forename { get; set; }
        public string Surname { get; set; }
        public AddressDetails AddressDetails { get; set; }
    
    }
}
