using System.Collections.Generic;
using System.Linq;
using Entity_Framework.Database;
using Entity_Framework.Models;
using Microsoft.AspNetCore.Mvc;

namespace Entity_Framework.Controllers
{
    public class OrdenController : Controller
    {
        
        private HeroeDbContext _heroeDbContext;

        public OrdenController(HeroeDbContext heroeDbContext)
        {
            this._heroeDbContext = heroeDbContext;
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