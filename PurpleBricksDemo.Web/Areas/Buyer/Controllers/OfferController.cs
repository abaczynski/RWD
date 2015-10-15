using Core.Model.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurpleBricksDemo.Web.Areas.Buyer.Controllers
{
    public class OfferController : Controller
    {
        private readonly IOfferService _offerService;


        public OfferController(IOfferService offerService) {
            _offerService = offerService;
        }
        public ActionResult Index()
        {
            var offersVM = _offerService.GetOffersForUser(new Guid(User.Identity.Name));
            return View(offersVM);
        }

    }
}
