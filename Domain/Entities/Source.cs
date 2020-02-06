using Orbis.Housing.ServiceDesk.Domain.Entities.BaseClasses;
using Orbis.Housing.ServiceDesk.Domain.Utilities;

namespace Orbis.Housing.ServiceDesk.Domain.Entities
{
    public class Source : Value<Source>
    {
        public Source(
           string name)
        {
            Guard.NotNullOrEmpty(name, nameof(name));

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