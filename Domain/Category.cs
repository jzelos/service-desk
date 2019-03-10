using System;

namespace Domain
{
    public class Category : AggregateRoot
    {
        public DateTime CreatedDate { get; set; }  // TODO full auditing probably ought to be in EF SaveChanges using change tracking.
        public string Creator { get; set; } 
        public string Name { get; set; }

        public virtual ICollection<Subcategory> Subcategories { get; set; }

        public Category(
                   string user,
                   string name)
        {
            NullCheck(user);
            NullCheck(name);

            this.CreatedDate = DateTime.Now;
            this.Creator = user;
            this.Name = name;
            ticket.Subcategories = new List<Subcategory>();
        }

        protected Category() { }

        // Commands

        // CreateSubcategory
        public void CreateSubcategory(string user, string name)
        {
            if (Subcategories.Any(s => s.Name == name))
                throw new InvalidOperationException($"Cannot create subcatgory {name} as it already exists under category {this.Name}");

            var subcategory = new Subcategory(user, name);
            this.Subcategories.Add(subcategory);
        }

        // DeleteSubcategory
        public void DeleteSubcategory(string name)
        {
            var subcategory = Subcategories.FirstOrDefault(s => s.Name == name);
            if (subcategory == null)
                throw new InvalidOperationException($"Cannot delete subcatgory {name} as it does not exist under category {this.Name}");

            this.Subcategories.Remove(subcategory);
        }

        // GetSubcategory
        public Subcategory GetSubcategoryByName(string name)
        {
            var subcategory = Subcategories.FirstOrDefault(s => s.Name == name);
            if (subcategory == null)
                throw new InvalidOperationException($"Cannot find subcatgory {name} under category {this.Name}");

            return subcategory;
        }

        private static void NullCheck(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException($"Parameter {nameof(value)} cannot be null or empty");
        }
    }
}
