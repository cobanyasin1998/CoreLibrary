using ErrorHandling.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorHandling.Web.Controllers
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
            int val1 = 5;
            int val2 = 0;
            int res = val1 / val2;//throw divideByZeroException
            return View();
        }

        public IActionResult Privacy()
        {
            throw new FileNotFoundException();
            return View();
        }


        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {

            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ViewBag.Path = exception.Path;
            ViewBag.Message = exception.Error.Message;


            return View();
        }
    }
}
