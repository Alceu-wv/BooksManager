using BooksManager.Infrastructure;
using BooksManager.Infrastructure.Entities;
using BooksManager.Infrastructure.Interfaces;
using BooksManager.Infrastructure.Repositories;
using BooksManager.Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

public class LibraryController : Controller
{
    private readonly IAuthorService _authorService;
    private readonly IBookService _bookService;
    public LibraryController(IBookService bookService, IAuthorService authorService)
    {
        _bookService = bookService;
        _authorService = authorService;
    }

    private static byte[] FormFileToByteArray(IFormFile formFile)
    {
        using (var memoryStream = new MemoryStream())
        {
            formFile.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }

    [HttpGet]
    public ViewResult CreateAuthorPage()
    {
        List<Author> authors = _authorService.GetAll();
        EditAuthorViewModel viewModel = new EditAuthorViewModel();
        viewModel.Authors = authors;
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult CreateAuthor(Author author, IFormFile photo)
    {
        byte[] photoArray = FormFileToByteArray(photo);
        author.Photo = photoArray;
        _authorService.Add(author);
        BookViewModel viewModel = new();
        viewModel.Authors = _authorService.GetAll().Select(a => new AuthorViewModel
        {
            Id = a.Id,
            FullName = $"{a.FirstName} {a.LastName}"
        }).ToList();
        return View("Create", viewModel);
    }

    [HttpGet]
    public ActionResult DeleteAuthor(int Id)
    {
        Author author = _authorService.GetById(Id);
        _authorService.Delete(author);
        return RedirectToAction("CreateAuthorPage");
    }

    [HttpGet]
    public ActionResult EditAuthor(int Id)
    {
        Author author = _authorService.GetById(Id);
        _authorService.Update(author);
        return RedirectToAction("CreateAuthorPage");
    }

    [HttpGet]
    public ActionResult EditAuthorView(int Id)
    {
        // TODO: Edit Author
        return RedirectToAction("CreateAuthorPage");
    }

    [HttpGet]
    public ViewResult Bookshelf() => View(_bookService.GetAll());

    [HttpGet]
    public ViewResult EditBookView(int id)
    {
        var livro = _bookService.GetById(id);
        var autores = _authorService.GetAll().Select(a => new AuthorViewModel
        {
            Id = a.Id,
            FullName = $"{a.FirstName} {a.LastName}"
        }).ToList();

        var viewModel = new EditBookViewModel
        {
            Book = livro,
            Authors = autores
        };

        return View(viewModel);
    }

    [HttpPost]
    public ActionResult EditBook(Book book, int authorId)
    {
        book.Authors = new List<Author> { _authorService.GetById(authorId) };
        _bookService.Update(book);
        return RedirectToAction("Bookshelf");
    }

    [HttpGet]
    public ActionResult DeleteBook(int id)
    {
        Book book = _bookService.GetById(id);
        _bookService.Delete(book);
        return RedirectToAction("Bookshelf");
    }


    [HttpGet]
    public IActionResult Create()
    {
        // obter todos os autores
        var authors = _authorService.GetAll().Select(a => new AuthorViewModel
        {
            Id = a.Id,
            FullName = $"{a.FirstName} {a.LastName}"
        }).ToList();

        // criar uma nova viewModel para a view
        var viewModel = new BookViewModel
        {
            Authors = authors
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Create(BookViewModel viewModel)
    {
        // criar novo livro com autor
        var book = new Book
        {
            Title = viewModel.Title,
            ISBN = viewModel.ISBN,
            Year = viewModel.Year,
            Authors = new List<Author> { _authorService.GetById(viewModel.AuthorId) }
        };

        // adicionar novo livro ao contexto e salvar
        _bookService.Create(book);

        // se a ModelState não for válida, retornar a mesma view com os dados do viewModel
        viewModel.Authors = _authorService.GetAll().Select(a => new AuthorViewModel
        {
            Id = a.Id,
            FullName = $"{a.FirstName} {a.LastName}"
        }).ToList();

        return View(viewModel);
        
    }
}