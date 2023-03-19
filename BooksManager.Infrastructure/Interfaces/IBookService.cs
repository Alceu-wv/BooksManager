using BooksManager.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Infrastructure.Interfaces
{
    public interface IBookService
    {
        Book GetById(int id);
        IEnumerable<Book> GetAll();
        void Create(Book book);
        void Update(Book book);
        void Delete(Book book);
    }
}
