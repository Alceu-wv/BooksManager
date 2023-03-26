using BooksManager.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Infrastructure.ViewModels
{
    public class EditAuthorViewModel
    {
        public Author Author { get; set; }
        public List<Author> Authors { get; set; }
    }
}
