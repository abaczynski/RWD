using Core.Model.Users;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.DataAccess.Mappings.Users
{
    public class UserRoleMap : ClassMap<UserRole>
    {
        public UserRoleMap()
        {
            Table("User_Roles");

            Id(x => x.Id).Column("Role_Id").GeneratedBy.GuidComb();

            Map(x => x.Name).Column("Name").Not.Nullable();
            Map(x => x.Description).Column("Description").Nullable();

        }
    }
}
