using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IWebHostEnvironment Env { get; }

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            Env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var sourcefolder = Path.Combine(Env.ContentRootPath, "wwwroot");
            if (!Directory.Exists(sourcefolder))
                Directory.CreateDirectory(sourcefolder);
            var destinationfolder = Path.Combine(Env.ContentRootPath, "testc");
            if (!Directory.Exists(destinationfolder))
                Directory.CreateDirectory(destinationfolder);
            byte[] imgdata = System.IO.File.ReadAllBytes(sourcefolder + "/img/oip.jpg");
            System.IO.File.WriteAllBytes(destinationfolder + "/Foo.jpg", imgdata.ToArray());
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
