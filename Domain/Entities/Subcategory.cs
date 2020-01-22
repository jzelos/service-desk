using Domain.Entities.BaseClasses;

namespace Domain.Entities
{
    public class Subcategory : Value<Subcategory>
    {
        public Subcategory(
            string name)
        {
            NullCheck(name);
            Name = name;
        }

        public string Name { get; private set; }

        protected override bool EqualsCore(Subcategory other)
        {
            return Name.Equals(other.Name);
        }

        protected override int GetHashCodeCore()
        {
            return Name.GetHashCode();
        }
    }
}