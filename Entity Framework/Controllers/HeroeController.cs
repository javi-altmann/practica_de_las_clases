using System.Collections.Generic;
using System.Linq;

using Entity_Framework.Database;
using Entity_Framework.Models;
using Entity_Framework.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework.Controllers {
    public class HeroeController : Controller {
        private HeroeDbContext _heroeDbContext;
        public HeroeController (HeroeDbContext heroeDbContext) {
            this._heroeDbContext = heroeDbContext;
        }

        //[Authorize(Roles = "Administrador")]
        [Authorize(Policy = "PolicyAdmin")]
        [Authorize]
        [HttpGet]
        public IActionResult Create() {

            /*if(User.Identity.IsAuthenticated){
                var claims = User.Claims.ToList();
            } */

            var universos = _heroeDbContext.Universos
                .Select (x => new SelectListItem {
                    Text = x.Nombre,
                    Value = x.Id.ToString()
                })
                .ToList();
            var UniversoVm = new CrearHeroeViewModel {
                Universos = universos
            };

            return View (UniversoVm);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create (CrearHeroeViewModel heroeVm) {
            if (ModelState.IsValid) {
                var imagenes = new List<Imagen> {
                    new Imagen {
                    Url = heroeVm.Imagen,
                    Orden = heroeVm.OrdenImagen
                    }
                };

                var universoSeleccionado = _heroeDbContext.Universos
                                            .Where(x => x.Id == heroeVm.Universo)
                                            .FirstOrDefault();

                var heroe = new Heroe {
                    Nombre = heroeVm.Nombre,
                    Descripcion = heroeVm.Descripcion,
                    Imagenes = imagenes,
                    Universo = universoSeleccionado
                };

                _heroeDbContext.Heroes.Add(heroe);
                _heroeDbContext.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult GetAll() {
            var heroesComplete = _heroeDbContext.Heroes
                .Include(x => x.Imagenes)
                .Include(x => x.Universo)
                .ToList();

            var heroes = heroesComplete.Select(x => new GaleriaViewModel {
                IdHeroe = x.Id, 
                Nombre = x.Nombre,
                Descripcion = x.Descripcion, 
                Imagen = x.Imagenes.FirstOrDefault().Url
            }).ToList();  

            return View(heroes);
        }
    }
}
