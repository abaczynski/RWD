using Core.Model.Users;
using Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Model.Property
{
    public class Property : Entity<Guid>
    {
        protected Property() { }
        public virtual User Owner { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal Price { get; set; }
    }
}
