using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BooksManager.Infrastructure
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<BooksDbContext>
    {
        public BooksDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BooksDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BooksDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new BooksDbContext(optionsBuilder.Options);
        }
    }
}
