using BooksManager.Infrastructure;
using BooksManager.Infrastructure.Entities;
using BooksManager.Infrastructure.Interfaces;
using BooksManager.Infrastructure.Repositories;
using BooksManager.Infrastructure.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class BookshelfController : Controller
{
    private readonly IAuthorService _authorService;
    private readonly IBookService _bookService;
    public BookshelfController(IBookService bookService, IAuthorService authorService)
    {
        _bookService = bookService;
        _authorService = authorService;
    }

    [HttpGet]
    public ViewResult Bookshelf() => View(_bookService.GetAll());
}
