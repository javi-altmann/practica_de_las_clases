using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC_NT1.Controllers
{
    public class DerivadosActionResult : Controller
    {
        public ViewResult ViewResult() {
            return View();
        }

        //Se le puede pasar directo HTMl o javascript
        public ContentResult ContentResult() {
            return Content("<h1> Esto es un ContentResult <h1>");
        }

        //FileResult es un tipo que se utiliza para devolver el archivo al navegador. Así lo mostraría en el navegador
        public FileResult FileResult() {
            return File("~/Files/text.txt", "text/plain");
        }

        //Descargar file
        public FileResult FileResultExport()  
        {  
            return File(Url.Content("~/Files/text.txt"), "text/plain", "testFile.txt");  
        }  

        public JsonResult JsonResult()  
        {  
            return Json(new { Name = "Javi", ID = 1 });  
        }   

        //Redirige a la URL especificada
        public RedirectResult RedirectResult()  
        {  
            return Redirect("https://www.google.com/");  
        }  

         //Redirige al controller especificado
        public RedirectToRouteResult RedirectToRouteResult ()  
        {  
            return RedirectToRoute(new { controller = "PrimerosPasos", action = "JsonResult" });  
        }
        
        public ObjectResult StatusCodeResponse()  
        {  
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Status code 500" });
        } 
    }
}