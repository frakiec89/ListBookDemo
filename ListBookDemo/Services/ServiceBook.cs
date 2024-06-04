using Microsoft.EntityFrameworkCore;

namespace ListBookDemo.DB.Services
{
    public class ServiceBook
    {
        SqliteContext _context;
        public ServiceBook()
        {
            _context = new SqliteContext();
        }

        public List<Book> Books { get => _context.Books.ToList(); }
        public List<BookHistory> BooksUser(int userid)
        {
            return _context.BookHistories.Where(x => x.UserId == userid).Include(x => x.Book).ToList();
        }

        public void BookHistoriesAdd(int userId, int bookId)
        {
            try
            {
                var book = _context.Books.Find(bookId);
                var us = _context.Users.Find(userId);

                if (_context.BookHistories.Any(x => x.UserId == us.UserId && x.BookId == book.BookId))
                    throw new ArgumentException("такая книга уже куплена");

                _context.BookHistories.Add(new BookHistory
                {
                    BookId = book.BookId,
                    DateTime = DateTime.Now,
                    UserId = us.UserId
                });

                _context.SaveChanges();
            }
            catch (ArgumentException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Error db");
            }
        }


        public void ClearBook (int idUser)
        {
            try
            {
                _context.BookHistories.
                    RemoveRange(_context.BookHistories.Where(x => x.UserId == idUser));
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
