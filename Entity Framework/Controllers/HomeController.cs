using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Entity_Framework.Models;
using Entity_Framework.Database;

namespace Entity_Framework.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HeroeDbContext _heroeDbContext;

        public HomeController(ILogger<HomeController> logger, HeroeDbContext heroeDbContext)
        {
            _logger = logger;
            _heroeDbContext = heroeDbContext;
        }

        public IActionResult SetupUniversos() {
            
            var universos = new List<Universo>(){
                new Universo {
                    Nombre = "Marvel"
                },
                new Universo {
                    Nombre = "Dc"
                }
            };
            
            _heroeDbContext.Universos.AddRange(universos);
            _heroeDbContext.SaveChanges();
            return Json("ok");
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
    }
}
