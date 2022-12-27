﻿using HangFire.Web.BackroundJobs;
using HangFire.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HangFire.Web.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
        public IActionResult SignUp()
        {
            //üye kayıt işlemi burada gerçekleştiriliyor.
            //kayıt olan kullanıcının userID bilgisini al
            FireAndForgetJobs.EmailSendToUserJob("1234","Hangfire test sitemize hoş geldiniz");
            return View();
        }
    }
}