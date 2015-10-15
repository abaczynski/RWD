using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Model.Offers
{
    public interface IOfferService
    {
        ICollection<OfferViewModel> GetOffersForUser(Guid userId);
        void MakeOffer(Guid propertyId, decimal price, Guid ownerID);
        void ChangeStatus(Guid offerId, EStatus status);
        ICollection<OfferViewModel> GetOfferForProperty(Guid propertyId);
    }
}
