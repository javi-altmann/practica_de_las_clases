using Microsoft.AspNetCore.Mvc;
using MVC_NT1.Models;

namespace MVC_NT1.Controllers
{
    public class RegistroController : Controller
    {
        [HttpGet]
        public IActionResult RegistrarUsuario() {
            return View();
        }
            
        [HttpPost]
        public IActionResult RegistrarUsuario(UsuarioViewModel user) {
            return View(user);
        }
    }
}
