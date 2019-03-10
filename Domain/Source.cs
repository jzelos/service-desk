using System;

namespace Domain
{
    public class Source
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

        private static void NullCheck(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException($"Parameter {nameof(value)} cannot be null or empty");
        }
    }
}
