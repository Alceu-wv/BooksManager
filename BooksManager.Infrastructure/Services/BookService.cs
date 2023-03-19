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

        public void Create(Book book)
        {
            _bookRepository.Create(book);
        }

        public void Update(Book book)
        {
            _bookRepository.Update(book);
        }

        public void Delete(Book book)
        {
            _bookRepository.Delete(book);
        }
    }
}
