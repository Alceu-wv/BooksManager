using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BooksManager.Infrastructure.Interfaces;
using BooksManager.Infrastructure.Services;
using BooksManager.Infrastructure.Repositories;

namespace BooksManager.Infrastructure.InversionOFControl
{
    public class DependencyInjection
    {
        public static void Inject(IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddDbContext<BooksDbContext>(options => options.UseSqlServer(
               configuration.GetConnectionString("BooksDatabase")
               ));
        }
    }
}
