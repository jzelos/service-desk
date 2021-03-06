using Orbis.Housing.ServiceDesk.Domain.Entities.BaseClasses;
using Orbis.Housing.ServiceDesk.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Orbis.Housing.ServiceDesk.Domain.Entities
{
    public class Category : Value<Category>
    {
        private readonly List<string> _subcategories = new List<string>();

        public Category(
            string name)
        {
            Guard.NotNullOrEmpty(name, nameof(name));

            Name = name;
        }

        public string Name { get; set; }

        public IReadOnlyCollection<string> Subcategories => _subcategories.AsReadOnly();

        public void AddSubcategory(string name)
        {
            Guard.NotNullOrEmpty(name, nameof(name));

            if (_subcategories.Any(s => s == name))
                throw new InvalidOperationException($"Cannot create subcatgory {name} as it already exists under category {Name}");

            _subcategories.Add(name);
        }

        public void RemoveSubcategory(string name)
        {
            var subcategory = _subcategories.FirstOrDefault(s => s == name);
            if (subcategory != null)
                _subcategories.Remove(subcategory);
        }

        protected override bool EqualsCore(Category other)
        {
            return Name.Equals(other.Name); // TODO Also Subcategories?
        }

        protected override int GetHashCodeCore()
        {
            return Name.GetHashCode();
        }
    }
}