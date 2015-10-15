using Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Core.Model.Users
{
    public class UserRole : Entity<Guid>
    {
        public UserRole() { }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}
