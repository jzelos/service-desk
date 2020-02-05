using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Repositories.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class SourceRepository : CrudRepository<Source>
    {
        private readonly ServiceDeskContext _context;

        public SourceRepository(ServiceDeskContext context)
        {
            _context = context;
        }

        public async override Task Add(Source source)
        {
            if (_context.Sources.Any(s => s.Name == source.Name))
                throw new InvalidOperationException($"Cannot create source {source.Name} as it already exists");

            await _context.Sources.AddAsync(source);
        }

        public async override Task<List<Source>> Get()
        {
            return await _context.Sources
                .ToListAsync();
        }

        public async Task<List<string>> GetSourceNames()
        {
            return await _context.Sources
                .Select(s => s.Name)
                .ToListAsync();
        }

        public override void Remove(Source source)
        {
            _context.Sources.Remove(source);
        }

        public async override Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}