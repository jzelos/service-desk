using System;

namespace Domain
{
    public class Subcategory  : Entity
    {
        public DateTime CreatedDate { get; set; }
        public string Creator { get; set; }
        public string Name { get; set; }

        public virtual Category Category { get; set; }


        public Subcategory(
                   string user,
                   string name)
        {
            NullCheck(user);
            NullCheck(name);

            this.CreatedDate = DateTime.Now;
            this.Creator = user;
            this.Name = name;
        }

        protected Subcategory() { }
    }
}
