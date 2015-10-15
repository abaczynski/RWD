using Core.Model.Offers;
using Core.Model.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurpleBricksDemo.Web.Areas.Seller.Controllers
{
    [Authorize(Roles = "Seller")]
    public class DefaultController : Controller
    {
        private readonly IPropertyService _propertyService;
        private readonly IOfferService _offerService;

        public DefaultController(IPropertyService propertyService, IOfferService offerService) {
            _propertyService = propertyService;
            _offerService = offerService;
        }
        
        public ActionResult Index()
        {
            var propertiesVM = _propertyService.GetAllPropertiesForOwner(new Guid(User.Identity.Name));
            return View(propertiesVM);
        }

        public ActionResult ViewOffers(Guid propertyId)
        {
            var offerVM = _offerService.GetOfferForProperty(propertyId);
            return View(offerVM);
        }

        public ActionResult AcceptOffer(Guid offerId)
        {
            _offerService.ChangeStatus(offerId, EStatus.Approved);
            return RedirectToAction("Index", "Default");
        }
        public ActionResult RejectOffer(Guid offerId)
        {
            _offerService.ChangeStatus(offerId, EStatus.Rejected);
            return RedirectToAction("Index", "Default");
        }

        [HttpPost]
        public ActionResult AddProperty(PropertyViewModel property) {
            _propertyService.AddProperty(property, new Guid(User.Identity.Name));

            return RedirectToAction("Index", "Default");
        }

        public ActionResult AddProperty()
        {
            return View(new PropertyViewModel());
        }

    }
}
