using Core.Model.Common;
using Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Model.Users
{
    public class User : Entity<Guid>
    {
        public User() {
            ContactDetails = new ContactDetails();
        }
        public virtual string Username { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string PasswordSalt { get; set; }
        public virtual ContactDetails ContactDetails { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
