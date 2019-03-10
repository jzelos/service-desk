using System;

namespace Domain
{
    public abstract class Entity
    {
        public long Id { get; private set; }

        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, null))
                return true;

            if (GetType() != other.GetType())
                return false;

            if (Id == 0 || other.Id == 0)
                return false;

            return Id == other.Id;
        }

        public static bool operator ==(Entity a, Entity b)
        {
            
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null) )
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null) )
                return false;

                return a.Equals(b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
        
        protected static void NullCheck(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException($"Parameter {nameof(value)} cannot be null or empty");
        }
    }
}
