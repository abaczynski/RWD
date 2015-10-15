using Core.Model.Offers;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.DataAccess.Mappings.Offers
{
    public class OfferMap : ClassMap<Offer>
    {
        public OfferMap() {
            Table("Offer");

            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Status).CustomType<EStatus>();
            Map(x => x.OfferedPrice);
            References(x => x.Property).Column("PropertyId");
            References(x => x.Owner).Nullable();
        }
    }
}
