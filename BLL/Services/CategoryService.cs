using LibraryManagementSystem.BLL.Models;
using LibraryManagementSystem.DAL;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.BLL.Services
{
    public class CategoryService
    {
        private readonly LibraryContext _context;

        public CategoryService(LibraryContext context)
        {
            _context = context;
        }

        public List<Category> GetAllCategories() => _context.Categories.ToList();

        public Category GetCategoryById(int id) => _context.Categories.FirstOrDefault(c => c.Id == id);

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
    }
}
