using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC_NT1.Controllers
{
    public class PrimerosPasosController : Controller
    {
        //https://localhost:5001/PrimerosPasos/getNombre?name=juan&apellido=pedro
        public string getNombre(string name, string apellido) {
            return $"Su nombre es: {name} y su apellido {apellido}";
        }   
    }
}