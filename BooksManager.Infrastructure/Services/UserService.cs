using BooksManager.Infrastructure.Entities;
using BooksManager.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void CreateUser(User user)
        {
            _userRepository.Create(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        public void DeleteUser(User user)
        {
            _userRepository.Delete(user);
        }
        public bool Login(string email, string password)
        {
            User user = _userRepository.GetByEmail(email);

            if (user != null && user.Password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
