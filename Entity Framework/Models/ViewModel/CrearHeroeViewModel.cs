using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Entity_Framework.Models.ViewModel
{
    public class CrearHeroeViewModel
    {
        [Required(ErrorMessage = "El {0} es requerido")]
		[MaxLength(40, ErrorMessage = "El maximo permitido para el {0} es {1}")]
        public string Nombre { get; set; }

		[Required(ErrorMessage = "El {0} es requerido")]
		[MaxLength(200, ErrorMessage = "El maximo permitido para el {0} es {1}")]        
        public string Descripcion { get; set; }
        
        public string Imagen { get; set; }

        public int OrdenImagen { get; set; }
        
        public int Universo { get; set; }
        public IEnumerable<SelectListItem> Universos { get; set; }        
    }
}