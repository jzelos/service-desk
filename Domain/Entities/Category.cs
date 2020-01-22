using Domain.Entities.BaseClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Domain.Entities
{
    public class Category : Value<Category>
    {
        private readonly List<Subcategory> _subcategories = new List<Subcategory>();

        public Category(
            string name)
        {
            NullCheck(name);
            Name = name;
        }

        public string Name { get; set; }

        public virtual ReadOnlyCollection<string> Subcategories => _subcategories.Select(s => s.Name).ToList().AsReadOnly();

        public void AddSubcategory(string name)
        {
            if (_subcategories.Any(s => s.Name == name))
                throw new InvalidOperationException($"Cannot create subcatgory {name} as it already exists under category {Name}");

            _subcategories.Add(new Subcategory(name));
        }

        public void RemoveSubcategory(string name)
        {
            var subcategory = _subcategories.FirstOrDefault(s => s.Name == name);
            if (subcategory != null)
                _subcategories.Remove(subcategory);
        }

        protected override bool EqualsCore(Category other)
        {
            return Name.Equals(other.Name);
        }

        protected override int GetHashCodeCore()
        {
            return Name.GetHashCode();
        }
    }
}