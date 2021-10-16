using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_Framework.Models
{
    public class OrdenHeroe
    {
        public int Id { get; set; }
        
        [ForeignKey(nameof(Heroe))]
        public int HeroeId { get; set; }

        public Heroe Heroe { get; set; }
        
        [ForeignKey(nameof(Orden))]
        public int OrdenId { get; set; }    

        public Orden Orden { get; set; }
           
        public int Cantidad { get; set; }

        public double Descuento { get; set; }
         
    }
}