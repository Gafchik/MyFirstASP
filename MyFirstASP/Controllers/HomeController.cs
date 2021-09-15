using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyFirstASP.Models;
using MyFirstASP.Models.Users;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstASP.Controllers
{
    public class HomeController : Controller
    {
        private UserRepo userRepo = new UserRepo();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            Task.Run(() =>
            {
                 long ip = Request.HttpContext.Connection.RemoteIpAddress.Address;
              //  long ip = 1;
                 string date = DateTime.Now.Day.ToString() + ":" + DateTime.Now.Month.ToString() + ":" + DateTime.Now.Year.ToString();
                  string time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
               // string date = "test";
               // string time = "test2";
                userRepo.Autorez(new User()
                {
                    IP = ip,
                    Date = date,
                    Time = time
                });
            });
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
    }
}
