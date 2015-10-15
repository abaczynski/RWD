using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Model.Offers
{
    public class OfferViewModel
    {
        public Guid Id { get; set; }
        public  string OwnerName { get; set; }
        public  Core.Model.Property.Property Property { get; set; }
        public  EStatus Status { get; set; }
        public  decimal OfferedPrice { get; set; }
    }
}
