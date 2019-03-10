using System;

namespace Domain
{
    public class CategoryRepository
    {
        private readonly ServiceDeskContext _content;

        public CategoryRepository(ServiceDeskContext context)
        {
            context = _content;
        }

        // CreateCategory
        public void CreateCategory(string user, string name)
        {
            if (_content.Categories.Any(s => s.Name == name))
                throw new InvalidOperationException($"Cannot create category {name} as it already exists");

            var category = new Category(user, name);
            _content.Categories.Add(category);
        }

        // DeleteCategory
        public void DeleteCategory(string name)
        {
            var category = _content.Categories.FirstOrDefault(s => s.Name == name);
            if (category == null)
                throw new InvalidOperationException($"Cannot delete category {name} as it does not exist");

            _content.Categories.Remove(category);
        }

        // GetAll
        public IReadOnlyCollection<Category> GetAll()
        {
            return _context.Categories;
        }

        // GetCategoryByName
        public Category GetCategoryByName(string name)
        {
            var category = _content.Categories.FirstOrDefault(s => s.Name == name);
            if (category == null)
                throw new InvalidOperationException($"Cannot find category {name}");
            return category;
        }

        // Save
        public void Save()
        {
            _content.SaveChanges();
        }
    }
}
