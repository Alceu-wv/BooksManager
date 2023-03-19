using System.Collections.Generic;
using BooksManager.Infrastructure.Interfaces;
using BooksManager.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BooksManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            var books = _bookService.GetAll();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = _bookService.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> Create([FromBody] Book book)
        {
            _bookService.Create(book);

            return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            _bookService.Update(book);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookService.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.Delete(id);

            return NoContent();
        }
    }
}