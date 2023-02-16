using ErrorHandling.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ErrorHandling.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            int v1 = 5;
            int v2 = 0;

            int sonuc = v1 / v2;
            return View();
        }

        public IActionResult Privacy()
        {
            throw new FileNotFoundException();
            return View();
        }

        [AllowAnonymous]//bunu da biz ekledik ki yetki falan verirseniz hatayı herkes görsün
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();//uygulamanın herhangi bir yerinde gelen hatayı yakaladık.
            ViewBag.path= exception?.Path.ToString();//hatayı hangi sayfada aldığımızı söyler.
            ViewBag.message=exception?.Error;//hata mesajını alırız.
            return View();
        }
    }
}