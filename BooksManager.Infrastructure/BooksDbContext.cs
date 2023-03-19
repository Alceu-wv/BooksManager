using BooksManager.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksManager.Infrastructure
{
    public class BooksDbContext : DbContext
    {
            public BooksDbContext(DbContextOptions options) : base(options) { }

            public DbSet<Book> Book { get; set; }
            public DbSet<Author> Author { get; set; }
            public DbSet<User> User { get; set; }
    }
}
