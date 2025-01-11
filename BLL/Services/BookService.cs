namespace LibraryManagementSystem.BLL.Services
{
    public class BookService
    {
        private readonly LibraryContext _context;

        public BookService(LibraryContext context)
        {
            _context = context;
        }

        public List<Book> GetAllBooks() => _context.Books.Include(b => b.Author).Include(b => b.Category).ToList();
        
        public Book GetBookById(int id) => _context.Books.Include(b => b.Author).Include(b => b.Category).FirstOrDefault(b => b.Id == id);

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
