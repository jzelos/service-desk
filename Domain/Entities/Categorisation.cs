using Orbis.Housing.ServiceDesk.Domain.Entities.BaseClasses;
using Orbis.Housing.ServiceDesk.Domain.Utilities;

namespace Orbis.Housing.ServiceDesk.Domain.Entities
{
    public class Categorisation : Value<Categorisation>
    {
        public Categorisation(string category, string subcategory)
        {
            Guard.NotNullOrEmpty(category, nameof(category));
            Guard.NotNullOrEmpty(subcategory, nameof(subcategory));

            Category = category;
            Subcategory = subcategory;
        }

        public string Category { get; set; }
        public string Subcategory { get; set; }

        protected override bool EqualsCore(Categorisation other)
        {
            return Category.Equals(other.Category) && Subcategory.Equals(other.Subcategory);
        }

        protected override int GetHashCodeCore()
        {
            return (Category + Subcategory).GetHashCode();
        }
    }
}