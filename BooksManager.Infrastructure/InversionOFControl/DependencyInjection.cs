using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BooksManager.Infrastructure.InversionOFControl
{
    public class DependencyInjection
    {
        public static void Inject(IServiceCollection services, ConfigurationManager configuration)
        {
            //services.AddDbContext<BooksDbContext>(options => options.UseSqlServer(
             //   configuration.GetConnectionString("DbConnection")
             //   ));
        }
    }
}
