using Core.Model.Offers;
using Core.Model.Property;
using PurpleBricksDemo.Web.Areas.Buyer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurpleBricksDemo.Web.Areas.Buyer.Controllers
{
    [Authorize(Roles = "Buyer")]
    public class DefaultController : Controller
    {
        private readonly IOfferService _offerService;
        private readonly IPropertyService _propertyService;

        public DefaultController(IOfferService offerService, IPropertyService propertyService) {
            _offerService = offerService;
            _propertyService = propertyService;
        }

        public ActionResult Index()
        {
            var propertiesVM = _propertyService.GetAllProperties().ToList();
            var userOffersVM = _offerService.GetOffersForUser(new Guid(User.Identity.Name)).ToList();

            var buyerVM = new BuyerPropertyOfferViewModel() { Properties = propertiesVM, Offers = userOffersVM };

            return View(buyerVM);
        }

        public ActionResult MakeOffer(Guid propertyId)
        {
            return View(new OfferRequestViewModel() { PropertyId = propertyId});
        }

        [HttpPost]
        public ActionResult MakeOffer(OfferRequestViewModel offerRequest) {
            _offerService.MakeOffer(offerRequest.PropertyId, offerRequest.Price, new Guid(User.Identity.Name));

            return RedirectToAction("Index", "Default", new { area = "Buyer" });
        }


    }
}
