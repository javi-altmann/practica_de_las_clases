using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity_Framework.Models
{
    public class Orden
    {
        public int Id { get; set; }
        
        [Required] 
        public string Status { get; set; }

        [Required] 
        public double Total { get; set; }

        [Required]
        public double Subtotal { get; set; }
        
        public ICollection<OrdenHeroe> Heroes { get; set; } 

    }
}