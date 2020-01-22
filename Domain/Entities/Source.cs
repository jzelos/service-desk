using Domain.Entities.BaseClasses;

namespace Domain.Entities
{
    public class Source : Value<Source>
    {
        public Source(
           string name)
        {
            NullCheck(name);
            Name = name;
        }

        public string Name { get; set; }

        protected override bool EqualsCore(Source other)
        {
            return Name.Equals(other.Name);
        }

        protected override int GetHashCodeCore()
        {
            return Name.GetHashCode();
        }
    }
}