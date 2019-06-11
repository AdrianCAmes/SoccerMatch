using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoccerMatch_TF.Models;

namespace SoccerMatch_TF.Controllers
{
    public class HomeController : Controller
    {
        AplicacionDbContext db = new AplicacionDbContext();
        public IActionResult Index()
        {
            var data = db.Calle;
            return View(data);
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
