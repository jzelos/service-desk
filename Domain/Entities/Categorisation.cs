using Domain.Entities.BaseClasses;

namespace Domain.Entities
{
    public class Categorisation : Value<Categorisation>
    {
        public Categorisation(string category, string subcategory)
        {
            NullCheck(category);
            NullCheck(subcategory);

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