using HangFire.Web.BackroundJobs;
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

        public IActionResult PictureSave()
        {
            BackroundJobs.ReccurinJobs.ReportingJobs();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PictureSave(IFormFile picture)
        {
            
            string newFileName = string.Empty;

            if (picture!=null && picture.Length>0)
            {
                //eklenen resimlere random isim atama
                newFileName = Guid.NewGuid().ToString() + Path.GetExtension(picture.FileName);//get extension sadece uzantıyı alır. abc.jpg-->jpg alır.
                //kaydedeceğimiz path belirtelim.
                var path=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/Pictures",newFileName);

                //resmi içeri alalım
                using (var stream =  new FileStream(path,FileMode.Create))
                {
                    await picture.CopyToAsync(stream);
                }

                //jobı oluşturalım.
                string jobId = BackroundJobs.DelayedJobs.AddWaterMarkJob(newFileName, "Mehmet Tekin");
            }
            return View();
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