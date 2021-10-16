using System.ComponentModel.DataAnnotations;

namespace Entity_Framework.Models
{
    public class Universo
    {
        public int Id { get; set; }
        
        [Required]
        public string Nombre { get; set; }
        
    }
}