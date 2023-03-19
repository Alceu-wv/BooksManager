using BooksManager.Infrastructure.Entities;
using BooksManager.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book GetById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public Book Create(Book book)
        {
            return _bookRepository.Create(book);
        }

        public Book Update(Book book)
        {
            return _bookRepository.Update(book);
        }

        public void Delete(int id)
        {
            _bookRepository.Delete(id);
        }
    }
}
