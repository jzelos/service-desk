using System;

namespace Domain
{
    public abstract class Value<T> where T : Value<T>
    {

        public override bool Equals(object obj)
        {
            var other = obj as T;

            if (ReferenceEquals(other, null))
                return false;

            return EqualsCore(other);
        }

        protected abstract bool EqualsCore(T other);

        public static bool operator ==(Value<T> a, Value<T> b)
        {

            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Value<T> a, Value<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        protected abstract int GetHashCodeCore();
        
        protected static void NullCheck(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException($"Parameter {nameof(value)} cannot be null or empty");
        }

    }
}
