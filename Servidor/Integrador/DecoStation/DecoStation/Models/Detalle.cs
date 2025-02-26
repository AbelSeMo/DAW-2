using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecoStation.Models
{
    public class Detalle
    {
        public int Id { get; set; }
        public int? Quantity { get; set; }

        [Column(TypeName = "decimal(11, 2)")]
        public decimal? Price { get; set; }

        public int OrderId { get; set; }
        public Pedido? Order { get; set; }
        public int ProductId { get; set; }
        public Producto? Producto { get; set; }
    }
}
