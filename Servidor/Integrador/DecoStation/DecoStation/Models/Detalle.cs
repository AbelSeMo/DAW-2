using System.ComponentModel.DataAnnotations;

namespace DecoStation.Models
{
    public class Detalle
    {
        public int Id { get; set; }

        [Display(Name = "Productos")]
        public ICollection<Producto>? Products { get; set; }

        [Display(Name = "Cantidad")]
        public int? Quantity { get; set; }
        public int OrderId { get; set; }

        [Display(Name = "Subtotal")]
        [DataType(DataType.Currency, ErrorMessage = "Formato de subtotal a pagar no válido.")]
        [Range(0, double.MaxValue, ErrorMessage = "El subtotal debe ser un valor positivo.")]
        [Required(ErrorMessage = "El subtotal es un campo requerido.")]
        public decimal? Summary { get; set; }
        
        public Pedido? Order { get; set; }
    }
}
