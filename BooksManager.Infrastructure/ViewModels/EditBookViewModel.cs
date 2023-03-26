using BooksManager.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksManager.Infrastructure.ViewModels
{
    public class EditBookViewModel
    {
        public Book Book { get; set; }
        public List<AuthorViewModel> Authors { get; set; }
        public int AuthorId { get; set; }
    }
}
