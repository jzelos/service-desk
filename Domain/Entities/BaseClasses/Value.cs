using System;

namespace Orbis.Housing.ServiceDesk.Domain.Entities.BaseClasses
{
    public abstract class Value<T> where T : Value<T>
    {
        public static bool operator !=(Value<T> a, Value<T> b)
        {
            return !(a == b);
        }

        public static bool operator ==(Value<T> a, Value<T> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public override bool Equals(object obj)
        {
            var other = obj as T;

            if (other == null)
                return false;

            return EqualsCore(other);
        }

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        protected abstract bool EqualsCore(T other);

        protected abstract int GetHashCodeCore();
    }
}