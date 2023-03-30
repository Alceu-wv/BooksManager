using BooksManager.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        User GetById(int id);
        void Create(User user);
        void Update(User user);
        void Delete(User user);
        public User GetByEmail(string email);
    }
}
