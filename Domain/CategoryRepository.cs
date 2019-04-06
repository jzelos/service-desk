using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class CategoryRepository
    {
        private readonly ServiceDeskContext _context;

        public CategoryRepository(ServiceDeskContext context)
        {
            _context = context;
        }

        // CreateCategory
        public void CreateCategory(string user, string name)
        {
            if (_context.Categories.Any(s => s.Name == name))
                throw new InvalidOperationException($"Cannot create category {name} as it already exists");

            var category = new Category(user, name);
            _context.Categories.Add(category);
        }

        // DeleteCategory
        public void DeleteCategory(string name)
        {
            var category = _context.Categories.FirstOrDefault(s => s.Name == name);
            if (category == null)
                throw new InvalidOperationException($"Cannot delete category {name} as it does not exist");

            _context.Categories.Remove(category);
        }

        // GetAll
        public IReadOnlyCollection<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        // GetCategoryByName
        public Category GetCategoryByName(string name)
        {
            var category = _context.Categories.FirstOrDefault(s => s.Name == name);
            if (category == null)
                throw new InvalidOperationException($"Cannot find category {name}");
            return category;
        }

        // Save
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
