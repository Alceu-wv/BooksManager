using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BooksManager.Infrastructure.ViewModels
{
    public class BookViewModel
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public int AuthorId { get; set; }
        public List<AuthorViewModel> Authors { get; set; }
    }

}
