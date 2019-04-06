using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Source : Value<Source>
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

        protected override bool EqualsCore(Source other)
        {
            return this.Name.Equals(other.Name);
        }

        protected override int GetHashCodeCore()
        {
            return this.Name.GetHashCode();
        }
    }
}
