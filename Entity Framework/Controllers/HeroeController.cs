using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using Entity_Framework.Database;
using Entity_Framework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework.Controllers
{
    public class HeroeController : Controller
    {
        private HeroeDbContext _heroeDbContext;
        public HeroeController(HeroeDbContext heroeDbContext)
        {
            this._heroeDbContext = heroeDbContext;
        }

        public IActionResult Create() {
            var imagenes = new List<Imagen> {
                new Imagen {
                    Url = "https://test.com.ar",
                    Orden = 1
                }, 
                new Imagen {
                    Url = "https://test2.com.ar",
                    Orden = 2
                }
            };

            var universoMarvel = new Universo {
                Nombre = "Marvel"
            };
    
            var universoDc = new Universo {
                Nombre = "Dc"
            };

            var heroes = new List<Heroe> {
                new Heroe { 
                Nombre = "Batman",
                Descripcion = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                Imagenes = imagenes,
                Universo = universoDc
            },
                new Heroe { 
                Nombre = "Daredevil",
                Descripcion = "Some quick example text to build on the card title and make up the bulk of the card's content.",
                Imagenes = imagenes,
                Universo = universoMarvel
            }
            };

            _heroeDbContext.Heroes.AddRange(heroes);
            _heroeDbContext.SaveChanges();

            return Json(heroes);
        }

        public IActionResult GetAll() {

            var heroesComplete = _heroeDbContext.Heroes
                                .Include(x => x.Imagenes)
                                .Include(x=> x.Universo)
                                .ToList();

            return Json(heroesComplete);
        }

        public IActionResult GetMarvel() {
            var heroesMarvel = _heroeDbContext.Heroes
                                .Include(x => x.Imagenes)
                                .Include(x=> x.Universo)
                                .Where(x=> x.Universo.Nombre == "Marvel")
                                .ToList();
            return Json(heroesMarvel);
        }

        public IActionResult SaveOrden() {
            var heroe = _heroeDbContext.Heroes.Where(x => x.Id == 1).FirstOrDefault();

            var heroe2 = _heroeDbContext.Heroes.Where(x => x.Id == 2).FirstOrDefault();

             var order = new Orden {
                Status = "Aprobado", 
                Total = 90, 
                Subtotal = 90, 
            };
                        
            var orderHeroes = new List<OrdenHeroe> {
                new OrdenHeroe {
                    Heroe = heroe, 
                    Orden = order, 
                    Cantidad = 10, 
                    Descuento = 1
                }, 
                new OrdenHeroe {
                    Heroe = heroe2, 
                    Orden = order,
                    Cantidad = 2, 
                    Descuento = 1
                }
            };
          
            _heroeDbContext.OrdenesHeroes.AddRange(orderHeroes);
           
            _heroeDbContext.SaveChanges();

            return Json("Ok");
        }
    }
}