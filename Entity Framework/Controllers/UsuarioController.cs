using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Entity_Framework.Database;
using Entity_Framework.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Entity_Framework.Controllers
{
    public class UsuarioController : Controller
    {
        private HeroeDbContext _heroeDbContex;
 
        public UsuarioController(HeroeDbContext heroeDbContex)
        {
            _heroeDbContex = heroeDbContex;
        }

        public IActionResult CrearUsuario() {
            string pass = "javier1234";
                var usuario = new Usuario {
                    Nombre = "Javi", 
                    User = "javi",
                    Contraseña = Encoding.UTF8.GetBytes(pass),
                    Rol = Rol.Administrador,
                };
                _heroeDbContex .Add(usuario);
                _heroeDbContex .SaveChanges();
                return Json("ok");
        }
        
        [HttpGet]
        public IActionResult Ingresar(string returnUrl) {
            TempData["UrlIngreso"] = returnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult Ingresar(string usuario, string pass) {

            // Validamos que hayan ingresado el usuario y contraseña
            if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(pass)) {
                // Verificamos que exista el usuario
                var user =  _heroeDbContex.Usuarios.FirstOrDefault(u => u.User == usuario);
                if (user != null) {
                    // Validamos que coincida la contraseña
                    var contraseña = Encoding.UTF8.GetBytes(pass);

                    if (contraseña.SequenceEqual(user.Contraseña)) {

                        // Creamos los Claims (credencial de acceso con informacion del usuario)
                        ClaimsIdentity identidad = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

                        // Agregamos a la credencial el nombre de usuario
                        identidad.AddClaim(new Claim(ClaimTypes.Name, usuario));
                        // Agregamos a la credencial el nombre del estudiante/administrador
                        identidad.AddClaim(new Claim(ClaimTypes.GivenName, user.Nombre));
                        // Agregamos a la credencial el Rol
                        identidad.AddClaim(new Claim(ClaimTypes.Role, user.Rol.ToString()));

                        ClaimsPrincipal principal = new ClaimsPrincipal(identidad);

                        // Ejecutamos el Login
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                                                
                        // Redirigimos a la pagina principal
                        return RedirectToAction("Index", "Home");
                    }                    
                }
            }

            ViewBag.ErrorEnLogin = "Verifique el usuario y contraseña";
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Salir()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult AccesoDenegado()
        {
            return View();
        }

    }
}