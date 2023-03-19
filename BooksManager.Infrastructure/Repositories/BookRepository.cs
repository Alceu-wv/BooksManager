using BooksManager.Infrastructure.Entities;
using BooksManager.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BooksDbContext _context;

        public BookRepository(BooksDbContext context)
        {
            _context = context;
        }

        public Book GetById(int id)
        {
            return _context.Book.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Book.ToList();
        }

        public void Create(Book book)
        {
            _context.Book.Add(book);
            _context.SaveChanges();
        }

        public void Update(Book book)
        {
            _context.Book.Update(book);
            _context.SaveChanges();
        }

        public void Delete(Book book)
        {
            _context.Book.Remove(book);
            _context.SaveChanges();
        }
    }
}
