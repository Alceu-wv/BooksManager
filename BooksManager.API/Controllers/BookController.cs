﻿using Microsoft.AspNetCore.Mvc;

namespace BooksManager.API.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
