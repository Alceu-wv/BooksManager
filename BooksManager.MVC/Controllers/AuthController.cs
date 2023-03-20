using BooksManager.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Formatting;


namespace BooksManager.MVC.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public ViewResult Login() => View();


        [HttpGet]
        public ViewResult Register() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User model)
        {

            var httpClient = new HttpClient();
            var response = httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Post, "https://localhost:7233/api/User")
            {
                Content = new ObjectContent<User>(model, new JsonMediaTypeFormatter())
            }).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Create", "Library");
            }
            else
            {
                ModelState.AddModelError("", "Erro ao realizar o cadastro. Verifique os dados inseridos e tente novamente");
                return View(model);
            }
        }
    }
}
