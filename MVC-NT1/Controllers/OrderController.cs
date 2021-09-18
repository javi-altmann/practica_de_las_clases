using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using MVC_NT1.Models;

namespace MVC_NT1.Controllers {
    public class OrderController : Controller {
       
        //En este ejemplo vemos hacer un redirect a otra vista
        public IActionResult EjemploRedirectAOtraView() {
            return View ("Views/Home/Privacy.cshtml");
        }

        //Enseñar definición del viewmodel (https://docs.microsoft.com/es-es/aspnet/core/mvc/views/overview?view=aspnetcore-5.0)
        //Explicar que en una vista se le puede pasar solo un model(salvo que uses vistas parciales, etc) por eso son muy útiles los ViewModel
        // Ver como pasar un model de la vista al controller
        public IActionResult NewOrder() {
            var orderViewModel = new OrderViewModel {
                Id = 1,
                Name = "Javi",
                Total = 10
            };

            return View();
        }

        //Ejemplo de como recorrer una lista y como usar el @ para codigo en las vistas
        public IActionResult OrderList() {
            var orderListViewModel = new List<OrderViewModel> {
                new OrderViewModel {
                Id = 1,
                Name = "Javi",
                Total = 10
                },
                new OrderViewModel {
                Id = 2,
                Name = "Pedro",
                Total = 20
                },
            };

            return View (orderListViewModel);
        }
    }
}
