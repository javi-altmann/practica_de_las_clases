using System.ComponentModel.DataAnnotations;

namespace Entity_Framework.Models
{
    public class Imagen
    {
        public int Id { get; set; }

        [Required]   
        public string Url { get; set; }
        
        public int Orden { get; set; }
        
        
    }
}