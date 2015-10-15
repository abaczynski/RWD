using Core.Model.Users;
using Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Model.Offers
{
    public class Offer : Entity<Guid>
    {
        public Offer() { }
        public virtual User Owner{ get; set; }
        public virtual Core.Model.Property.Property Property { get; set; }
        public virtual EStatus Status { get; set; }
        public virtual decimal OfferedPrice { get; set; }

    }
}
