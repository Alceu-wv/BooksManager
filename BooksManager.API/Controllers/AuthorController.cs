using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BooksManager.Infrastructure.Services;
using BooksManager.Infrastructure.Interfaces;
using BooksManager.API.Entities;

namespace BooksManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("{id}")]
        public ActionResult<Author> GetById(int id)
        {
            var author = _authorService.GetById(id);
            if (author == null)
            {
                return NotFound();
            }
            return author;
        }

        [HttpGet]
        public ActionResult<List<Author>> GetAll()
        {
            var authors = _authorService.GetAll();
            return authors;
        }

        [HttpPost]
        public ActionResult<Author> Add(Author author)
        {
            _authorService.Add(author);
            return CreatedAtAction(nameof(GetById), new { id = author.Id }, author);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }
            _authorService.Update(author);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var author = _authorService.GetById(id);
            if (author == null)
            {
                return NotFound();
            }
            _authorService.Delete(author);
            return NoContent();
        }

    }
}
