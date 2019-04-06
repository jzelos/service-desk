using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class SourceRepository
    {
        private readonly ServiceDeskContext _context;

        public SourceRepository(ServiceDeskContext context)
        {
            _context = context;
        }

        // CreateSource
        public void CreateSource(string name)
        {
            if (_context.Sources.Any(s => s.Name == name))
                throw new InvalidOperationException($"Cannot create source {name} as it already exists");

            var source = new Source(name);
            _context.Sources.Add(source);
        }

        // DeleteSource
        public void DeleteSource(string name)
        {
            var source = _context.Sources.FirstOrDefault(s => s.Name == name);
            if (source == null)
                throw new InvalidOperationException($"Cannot delete source {name} as it does not exist");

            _context.Sources.Remove(source);
        }

        // GetAll
        public IReadOnlyCollection<Source> GetAll()
        {
            return _context.Sources.ToList();
        }

        // Save
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
