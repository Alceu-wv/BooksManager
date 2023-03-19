using BooksManager.Infrastructure.Entities;
using BooksManager.Infrastructure.Interfaces;
using System;

namespace BooksManager.Infrastructure.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public Author GetById(int id)
        {
            return _authorRepository.GetById(id);
        }

        public List<Author> GetAll()
        {
            return _authorRepository.GetAll();
        }

        public void Add(Author author)
        {
            _authorRepository.Add(author);
        }

        public void Update(Author author)
        {
            _authorRepository.Update(author);
        }

        public void Delete(Author author)
        {
            _authorRepository.Delete(author);
        }
    }
}
