using Microsoft.EntityFrameworkCore;
using System;

namespace Domain
{
    [Owned] // EF Core 2.0 inline entity
    public class Categorisation : Value<Categorisation>
    {
        public string Category { get; set; }
        public string Subcategory { get; set; }

        public Categorisation(string category, string subcategory)
        {
            NullCheck(category);
            NullCheck(subcategory);

            this.Category = category;
            this.Subcategory = subcategory;
        }

        protected override bool EqualsCore(Categorisation other) 
        {
            return this.Category.Equals(other.Category) && this.Subcategory.Equals(other.Subcategory);
        }

        protected override int GetHashCodeCore()
        {
            return (this.Category + this.Subcategory).GetHashCode();
        }
    }
}