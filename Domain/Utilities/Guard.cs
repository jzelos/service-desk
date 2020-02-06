using System;

namespace Orbis.Housing.ServiceDesk.Domain.Utilities
{
    public static class Guard
    {
        public static void NotNull(object value, string name)
        {
            if (value == null)
                throw new ArgumentNullException($"Parameter {name} cannot be null");
        }

        public static void NotNullOrEmpty(string value, string name)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException($"Parameter {name} cannot be null or empty");
        }
    }
}