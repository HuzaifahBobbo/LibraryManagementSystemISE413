using LibraryManagementSystem.BLL.Models;
using LibraryManagementSystem.DAL;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.BLL.Services
{
    public class AuthorService
    {
        private readonly LibraryContext _context;

        public AuthorService(LibraryContext context)
        {
            _context = context;
        }

        public List<Author> GetAllAuthors() => _context.Authors.ToList();

        public Author GetAuthorById(int id) => _context.Authors.FirstOrDefault(a => a.Id == id);

        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void UpdateAuthor(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
        }

        public void DeleteAuthor(int id)
        {
            var author = _context.Authors.Find(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }
    }
}
