using System;

namespace Domain
{
    public class Source : Value
    {
        [Key, Required]
        public string Name { get; set; }

        public Source(
           string name)
        {
            NullCheck(name);

            this.Name = name;
        }

        protected Source() { }

        protected override bool EqualsCore(T other)
        {
            return this.Name.Equals(other.Name);
        }

        protected override int GetHashCodeCore()
        {
            return this.Name.GetHashCode();
        }
    }
}
