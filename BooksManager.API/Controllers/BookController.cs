using Microsoft.AspNetCore.Mvc;

namespace BooksManager.API.Controllers
{
    public class BookController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
