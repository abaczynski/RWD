using Core.Model.Property;
using Core.Model.Users;
using Infrastructure.Domain.DataInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Property
{
    public class PropertyService : IPropertyService
    {
        private readonly IRepository<Core.Model.Property.Property, Guid> _propertyRepository;
        private readonly IUserRepository _userRepository;

        public PropertyService(IRepository<Core.Model.Property.Property, Guid> propertyRepository, IUserRepository userRepository){
            _propertyRepository = propertyRepository;
            _userRepository = userRepository;

            AutoMapper.Mapper.CreateMap<Core.Model.Property.Property, PropertyViewModel>()
                .ForMember(x => x.OwnerName, y => y.MapFrom(z => z.Owner.ContactDetails.Forename));

            AutoMapper.Mapper.CreateMap<PropertyViewModel, Core.Model.Property.Property>()
                .ForSourceMember(x => x.OwnerName, y => y.Ignore());
        }

        public ICollection<Model.Property.PropertyViewModel> GetAllProperties()
        {
            var properties = _propertyRepository.GetAll().ToList();
            var propertiesVM = AutoMapper.Mapper.Map<ICollection<Core.Model.Property.Property>, ICollection<PropertyViewModel>>(properties);

            return propertiesVM;
        }


        public ICollection<PropertyViewModel> GetAllPropertiesForOwner(Guid ownerId)
        {
            var properties = _propertyRepository.Get(x => x.Owner.Id == ownerId).ToList();
            var propertiesVM = AutoMapper.Mapper.Map<ICollection<Core.Model.Property.Property>, ICollection<PropertyViewModel>>(properties);
            return propertiesVM;
        }


        public void AddProperty(PropertyViewModel property, Guid ownerId)
        {
            var newProperty = AutoMapper.Mapper.Map<PropertyViewModel, Core.Model.Property.Property>(property);
            var user = _userRepository.Get(ownerId);
            newProperty.Owner = user;

            _propertyRepository.SaveOrUpdate(newProperty);
            _propertyRepository.DbContext.CommitChanges();
        }
    }
}
