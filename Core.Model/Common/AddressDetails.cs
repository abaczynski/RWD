using Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Model.Common
{
    public class AddressDetails : ValueObject<AddressDetails>
    {
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
    }
}
