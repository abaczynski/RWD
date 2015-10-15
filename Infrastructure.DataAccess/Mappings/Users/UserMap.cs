using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.DataAccess.Mappings.Users
{
    class UserMap : ClassMap<Core.Model.Users.User>
    {
        public UserMap()
        {
            Table("[User]");

            Id(u => u.Id).GeneratedBy.GuidComb();
            Map(x => x.Username).Not.Nullable();
            Map(u => u.PasswordHash, "Password_Hash");
            Map(u => u.PasswordSalt, "Password_Salt");
            Component(x => x.ContactDetails, c => {
                c.Map(f => f.Forename).Column("Forename");
                c.Map(f => f.Surname).Column("Surname");
                c.Component(ad => ad.AddressDetails, adf =>
                {
                    adf.Map(adfMap => adfMap.Address).Column("Address");
                    adf.Map(adfMap => adfMap.Email).Column("Email");
                    adf.Map(adfMap => adfMap.Telephone).Column("Telephone");
                });
            });
            HasMany(x => x.UserRoles).Cascade.AllDeleteOrphan().KeyColumn("User_Guid").Table("[User]");

        }
    }
}
