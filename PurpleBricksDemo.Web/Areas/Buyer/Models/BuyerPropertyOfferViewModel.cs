using Core.Model.Offers;
using Core.Model.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurpleBricksDemo.Web.Areas.Buyer.Models
{
    public class BuyerPropertyOfferViewModel
    {
        public IList<PropertyViewModel> Properties { get; set; }
        public IList<OfferViewModel> Offers { get; set; }
    }
}