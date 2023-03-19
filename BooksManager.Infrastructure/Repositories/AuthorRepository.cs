using BooksManager.Infrastructure.Entities;
using BooksManager.Infrastructure.Interfaces;

namespace BooksManager.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BooksDbContext _context;

        public AuthorRepository(BooksDbContext context)
        {
            _context = context;
        }

        public Author GetById(int id)
        {
            return _context.Author.Find(id);
        }

        public List<Author> GetAll()
        {
            return _context.Author.ToList();
        }

        public void Add(Author author)
        {
            _context.Author.Add(author);
            _context.SaveChanges();
        }

        public void Update(Author author)
        {
            _context.Author.Update(author);
            _context.SaveChanges();
        }

        public void Delete(Author author)
        {
            _context.Author.Remove(author);
            _context.SaveChanges();
        }
    }
}
