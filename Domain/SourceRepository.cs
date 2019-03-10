using System;

namespace Domain
{
    public class SourceRepository
    {
        private readonly ServiceDeskContext _content;

        public SourceRepository(ServiceDeskContext context)
        {
            context = _content;
        }

        // CreateSource
        public void CreateSource(string name)
        {
            if (_content.Sources.Any(s => s.Name == name))
                throw new InvalidOperationException($"Cannot create source {name} as it already exists");

            var source = new Source(name);
            _content.Sources.Add(source);
        }

        // DeleteSource
        public void DeleteSource(string name)
        {
            var source = _content.Sources.FirstOrDefault(s => s.Name == name);
            if (source == null)
                throw new InvalidOperationException($"Cannot delete source {name} as it does not exist");

            _content.Sources.Remove(source);
        }

        // GetAll
        public IReadOnlyCollection<Source> GetAll()
        {
            return _context.Sources;
        }

        // Save
        public void Save()
        {
            _content.SaveChanges();
        }
    }
}
