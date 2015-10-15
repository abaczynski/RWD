using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Infrastructure.Domain
{
    public class ValueObject<TValueObject> : IEquatable<TValueObject> where TValueObject : ValueObject<TValueObject>
    {
        public bool Equals(TValueObject other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            //compare all public properties
            PropertyInfo[] publicProperties = this.GetType().GetProperties();

            if (publicProperties.Any())
            {
                return publicProperties.All(p =>
                {
                    var left = p.GetValue(this, null);
                    var right = p.GetValue(other, null);
                    if (left == null && right == null)
                        return true;
                    if (left != null && right == null)
                        return false;
                    if (left == null && right != null)
                        return false;
                    if (typeof(TValueObject).IsAssignableFrom(left.GetType()))
                    {
                        //check not self-references...
                        return Object.ReferenceEquals(left, right);
                    }
                    else
                        return left.Equals(right);


                });
            }
            return true;
        }
        public override bool Equals(object obj)
        {
            if ((object)obj == null)
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            ValueObject<TValueObject> item = obj as ValueObject<TValueObject>;

            if ((object)item != null)
                return Equals((TValueObject)item);
            else
                return false;

        }

        public override int GetHashCode()
        {


            int hashCodeMultiplier = 31;
            int hashCode = GetType().GetHashCode();

            PropertyInfo[] publicProperties = this.GetType().GetProperties();


            if ((object)publicProperties != null
                &&
                publicProperties.Any())
            {
                foreach (var item in publicProperties)
                {
                    object value = item.GetValue(this, null);

                    if ((object)value != null)
                    {

                        hashCode = (hashCode * hashCodeMultiplier) ^ (value.GetHashCode() + item.Name.GetHashCode());


                    }
                    else
                        hashCode = (hashCode * hashCodeMultiplier) ^ item.Name.GetHashCode();//only for support {"a",null,null,"a"} <> {null,"a","a",null}
                }
            }

            return hashCode;
        }
    }
}
