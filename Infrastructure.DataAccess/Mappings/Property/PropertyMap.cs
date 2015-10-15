using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.DataAccess.Mappings.Property
{
    public class PropertyMap : ClassMap<Core.Model.Property.Property>
    {
        public PropertyMap() {
            Table("Property");

            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Name);
            Map(x => x.Price);
            Map(x => x.Description).Nullable();
            References(x => x.Owner).Nullable();
        }
    }
}
