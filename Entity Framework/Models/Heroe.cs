using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity_Framework.Models
{
    public class Heroe
    {
        public int Id { get; set; }
        
        [Required]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(200)]
        public string Descripcion { get; set; }
        
        public ICollection<Imagen> Imagenes { get; set; }

        [Required]        
        public Universo Universo { get; set; }

        public ICollection<OrdenHeroe> Ordenes { get; set; }        
        
    }
}