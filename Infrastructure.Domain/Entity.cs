using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Domain
{
    public class Entity<TId>
    {
        public virtual TId Id { get; protected set; }

        public override bool Equals(object entity)
        {
            return entity != null
                && entity is Entity<TId>
                && this == (Entity<TId>)entity;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static bool operator ==(Entity<TId> entity1, Entity<TId> entity2) {
            if ((object)entity1 == null && (object)entity2 == null)
                return true;

            if ((object)entity1 == null || (object)entity2 == null)
                return false;

            if (entity1.Id.ToString() == entity2.Id.ToString())
                return true;

            return false;
        }

        public static bool operator !=(Entity<TId> entity1, Entity<TId> entity2)
        {
            return (!(entity1 == entity2));
              
        }

        public virtual bool Equals(Entity<TId> other)
        {
            if (other == null) {
                return false;
            }

            return this.Id.Equals(other.Id);
        }
    }
}
