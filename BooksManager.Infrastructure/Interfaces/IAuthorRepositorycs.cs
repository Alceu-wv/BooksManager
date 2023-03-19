using BooksManager.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Infrastructure.Interfaces
{
    public interface IAuthorRepository
    {
        Author GetById(int id);
        List<Author> GetAll();
        void Add(Author author);
        void Update(Author author);
        void Delete(Author author);
    }
}
