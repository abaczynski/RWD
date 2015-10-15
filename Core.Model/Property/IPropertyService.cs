using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Model.Property
{
    public interface IPropertyService
    {
        ICollection<PropertyViewModel> GetAllProperties();
        ICollection<PropertyViewModel> GetAllPropertiesForOwner(Guid ownerId);
        void AddProperty(PropertyViewModel property, Guid ownerId);
    }
}
