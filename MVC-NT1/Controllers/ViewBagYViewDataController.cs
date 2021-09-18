using Microsoft.AspNetCore.Mvc;
using MVC_NT1.Models;

namespace MVC_NT1.Controllers
{
    public class ViewBagYViewDataController : Controller
    {
        //En este ejemplo vemos como pasar un view data a la vista
        public IActionResult EjemploViewData() {
            ViewData["Message"] = "Este es un mensaje pasado por ViewData";
            ViewBag.Nombe = "Javi";

            var order = new OrderViewModel
            {
                Id = 1, 
                Name = "Javi", 
                Total = 100
            };

            ViewData["order"] = order;
            ViewBag.Order = order;
            return View();
        }
        /*
        ViewData es un objeto de diccionario fuertemente tipado en el que se introducen 
        los datos a través de la conocida sintaxis "key/value".
        ViewData deriva de la clase ViewDataDictionary.
        Uso y asignación al objetos: ViewData["Message"]= "Este es un mensaje pasado por ViewData"
        Lectura del objeto en la vista: @ViewData["Message"]
        */
        
        /*
        ViewBag
        El objeto ViewBag es un objeto de tipo dinámico (dynamic) que le permite 
        crear propiedades al vuelo.
        Uso y asignación al objetos ViewBag.Nombre = Javi
        Lectura del objeto en la vista: @ViewBag.Nombre
        */   
    }
}