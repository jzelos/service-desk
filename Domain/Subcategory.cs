using System;

namespace Domain
{
    public class Subcategory  : Entity
    {
        public DateTime CreatedDate { get; set; }
        public string Creator { get; set; }
        public string Name { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Item> Items { get; set; }


        public Subcategory(
                   string user,
                   string name)
        {
            NullCheck(user);
            NullCheck(name);

            this.CreatedDate = DateTime.Now;
            this.Creator = user;
            this.Name = name;
            ticket.Items = new List<Item>();
        }

        protected Subcategory() { }

        // Commands

        // CreateItem
        public void CreateItem(string user, string name)
        {
            if (Items.Any(s => s.Name == name))
                throw new InvalidOperationException($"Cannot create item {name} as it already exists under subcategory {this.Name}");

            var item = new Item(user, name);
            this.Items.Add(item);
        }

        // DeleteItem
        public void DeleteItem(string name)
        {
            var item = Items.FirstOrDefault(s => s.Name == name);
            if (item == null)
                throw new InvalidOperationException($"Cannot delete item {name} as it does not exist under subcategory {this.Name}");

            this.Items.Remove(item);
        }

        private static void NullCheck(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException($"Parameter {nameof(value)} cannot be null or empty");
        }
    }
}
