using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurpleBricksDemo.Web.Areas.Buyer.Models
{
    public class OfferRequestViewModel
    {
        public decimal Price { get; set; }
        public Guid PropertyId { get; set; }
    }
}