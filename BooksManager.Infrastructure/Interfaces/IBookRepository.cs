using BooksManager.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Infrastructure.Interfaces
{
    public interface IBookRepository
    {
        Book GetById(int id);
        IEnumerable<Book> GetAll();
        Book Create(Book book);
        Book Update(Book book);
        void Delete(Book book);
    }
}
