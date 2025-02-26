using System.ComponentModel.DataAnnotations;

namespace DecoStation.Models
{
    public class Pedido
    {
        [Display(Name = "Núm. pedido")]
        public int Id { get; set; }
        [Display(Name = "Fecha de envío")]
        [DataType(DataType.Date)]
        public DateTime? DeliveryTime { get; set; }
        [Display(Name = "Condición del Pedido")]
        public DateTime? Confirmed { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Confirmado")]
        public DateTime? Prepared { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Preparado")]
        public DateTime? Delivered { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Pagado")]
        public DateTime? Paid { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Devuelto")]
        public DateTime? Returned { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Anulado")]
        public DateTime? Cancelled { get; set; }
        public int UserId { get; set; }
        public Usuario? User { get; set; }
        public int ConditionId { get; set; }
        public Estado? Condition { get; set; }
        public ICollection<Detalle>? Detalles { get; set; }

    }
}
