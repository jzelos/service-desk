using Microsoft.EntityFrameworkCore;
using Orbis.Housing.ServiceDesk.Domain.Entities;
using Persistance.Repositories.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class CategoryRepository : CrudRepository<Category>
    {
        private readonly ServiceDeskContext _context;

        public CategoryRepository(ServiceDeskContext context)
        {
            _context = context;
        }

        public async override Task Add(Category category)
        {
            if (_context.Categories.Any(s => s.Name == category.Name))
                throw new InvalidOperationException($"Cannot create category {category.Name} as it already exists");

            await _context.Categories.AddAsync(category);
        }

        public async override Task<List<Category>> Get()
        {
            return await _context.Categories.ToListAsync();
        }

        public override void Remove(Category category)
        {
            _context.Categories.Remove(category);
        }

        public async override Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}