using System;

namespace Domain
{
    public class Item :  Entity
    {
        public DateTime CreatedDate { get; set; }
        public string Creator { get; set; }
        public string Name { get; set; }

        public virtual Subcategory Subcategory { get; set; }

        public Item(
             string user,
             string name)
        {
            NullCheck(user);
            NullCheck(name);

            this.CreatedDate = DateTime.Now;
            this.Creator = user;
            this.Name = name;
        }

        protected Item() { }
    }
}
