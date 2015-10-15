using Core.Model.Offers;
using Core.Model.Property;
using Core.Model.Users;
using Infrastructure.Domain.DataInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Offers
{
    public class OfferService : IOfferService
    {
        private readonly IRepository<Offer, Guid> _offerRepository;
        private readonly IRepository<Property, Guid> _propertyRepository;
        private readonly IUserRepository _userRepository;

        public OfferService(IRepository<Offer,Guid> offerRepository, IRepository<Property, Guid> propertyRepository, IUserRepository userRepository) {
            _offerRepository = offerRepository;
            _propertyRepository = propertyRepository;
            _userRepository = userRepository;

            AutoMapper.Mapper.CreateMap<Offer, OfferViewModel>();
        }

        public ICollection<OfferViewModel> GetOffersForUser(Guid userId)
        {
            var userOffers = _offerRepository.Get(x => x.Owner.Id == userId).ToList();
            var userOffersVM = AutoMapper.Mapper.Map<ICollection<Offer>, ICollection<OfferViewModel>>(userOffers);

            return userOffersVM;
        }

        public void MakeOffer(Guid propertyId, decimal price, Guid ownerId)
        {
            var property = _propertyRepository.Get(propertyId);
            if(property == null) throw new ArgumentNullException("Cant find property");

            var user = _userRepository.Get(ownerId);

            var offer = new Offer();
            offer.Owner = user;
            offer.OfferedPrice = price;
            offer.Property = property;
            offer.Status = EStatus.Pending;

            _offerRepository.SaveOrUpdate(offer);
            _offerRepository.DbContext.CommitChanges();
        }

        public void ChangeStatus(Guid offerId, EStatus status)
        {
            var offer = _offerRepository.Get(offerId);
            if (offer == null) throw new ArgumentNullException("Offer does not exist");

            offer.Status = status;
            _offerRepository.SaveOrUpdate(offer);
            _offerRepository.DbContext.CommitChanges();

        }


        public ICollection<OfferViewModel> GetOfferForProperty(Guid propertyId)
        {
            var offers = _offerRepository.Get(x => x.Property.Id == propertyId).ToList();
            var offerVM = AutoMapper.Mapper.Map<ICollection<Offer>, ICollection<OfferViewModel>>(offers);

            return offerVM;
        }
    }
}
