using Azure;
using Azure.Core;
using BooksManager.Infrastructure;
using BooksManager.Infrastructure.Entities;
using BooksManager.Infrastructure.Interfaces;
using BooksManager.Infrastructure.Repositories;
using BooksManager.Infrastructure.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
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
        var httpClient = new HttpClient();
        var deleteUrl = $"https://localhost:7233/api/Author/{Id}";
        string token = HttpContext.Session.GetString("JwtToken");
        //var response = httpClient.DeleteAsync(deleteUrl).Result;
        var request = new HttpRequestMessage(HttpMethod.Delete, deleteUrl);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = httpClient.SendAsync(request).Result;

        if (response.IsSuccessStatusCode)
        {
            // A ação foi concluída com sucesso
            return RedirectToAction("CreateAuthorPage");
        }
        else if (response.StatusCode == HttpStatusCode.NotFound)
        {
            throw new Exception("Author not found");
        }
        else
        {
            // Algum outro erro ocorreu
            throw new Exception("Failed to delete author");
        }
    }


    [HttpGet]
    public ActionResult EditAuthor(int Id)
    {
        var author = _authorService.GetById(Id);
        var updateUrl = $"https://localhost:7233/api/authors/{Id}";
        string token = HttpContext.Session.GetString("JwtToken");
        var requestBody = new StringContent(JsonConvert.SerializeObject(author), Encoding.UTF8, "application/json");

        var httpClient = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Put, updateUrl);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        request.Content = requestBody;

        var response = httpClient.SendAsync(request).Result;

        if (response.IsSuccessStatusCode)
        {
            // A ação foi concluída com sucesso
            return RedirectToAction("CreateAuthorPage");
        }
        else if (response.StatusCode == HttpStatusCode.NotFound)
        {
            throw new Exception("Author not found");
        }
        else
        {
            // Algum outro erro ocorreu
            throw new Exception("Failed to update author");
        }
    }


    [HttpGet]
    public ActionResult EditAuthorView(int Id)
    {
        // TODO: Edit Author
        return RedirectToAction("CreateAuthorPage");
    }

    [HttpGet]
    public ViewResult Bookshelf()
    // => View(_bookService.GetAll());
    {
        var getAllUrl = "https://localhost:7233/Book";
        string token = HttpContext.Session.GetString("JwtToken");

        var httpClient = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, getAllUrl);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = httpClient.SendAsync(request).Result;

        if (response.IsSuccessStatusCode)
        {
            var books = response.Content.ReadAsAsync<IEnumerable<Book>>().Result;
            return View(books);
        }
        else
        {
            // Algum outro erro ocorreu
            throw new Exception("Failed to retrieve books");
        }
    }

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
        var deleteUrl = $"https://localhost:7233/Book/{id}";
        string token = HttpContext.Session.GetString("JwtToken");

        var httpClient = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Delete, deleteUrl);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = httpClient.SendAsync(request).Result;

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Bookshelf");
        }
        else if (response.StatusCode == HttpStatusCode.NotFound)
        {
            throw new Exception("Book not found");
        }
        else
        {
            // Algum outro erro ocorreu
            throw new Exception("Failed to delete book");
        }
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
        var httpClient = new HttpClient();
        string token = HttpContext.Session.GetString("JwtToken");
        var createUrl = "https://localhost:7233/Book";
        var getAllAuthorUrl = $"https://localhost:7233/api/Author/{viewModel.AuthorId}";

        var authorRequest = new HttpRequestMessage(HttpMethod.Get, getAllAuthorUrl);
        authorRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var authorResponse = httpClient.SendAsync(authorRequest).Result;

        if (!authorResponse.IsSuccessStatusCode)
        {
            throw new Exception("Author not found");
        }

        var author = JsonConvert.DeserializeObject<Author>(authorResponse.Content.ReadAsStringAsync().Result);

        var book = new Book
        {
            Title = viewModel.Title,
            ISBN = viewModel.ISBN,
            Year = viewModel.Year,
            Authors = new List<Author> { author }
        };

        var requestBody = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");

        
        var requestBook = new HttpRequestMessage(HttpMethod.Post, createUrl);
        requestBook.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        requestBook.Content = requestBody;

        var response = httpClient.SendAsync(requestBook).Result;

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Bookshelf");
        }
        else
        {
            throw new Exception("Failed to create book");
        }
    }

}