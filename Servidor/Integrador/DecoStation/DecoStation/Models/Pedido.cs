using System.ComponentModel.DataAnnotations;

namespace DecoStation.Models
{
    public class Pedido
    {
        [Display(Name = "Núm. pedido")]
        public int Id { get; set; }
        [Display(Name = "Fecha de envío")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de envío es un campo requerido")]
        public DateTime? DeliveryTime { get; set; }
        [Display(Name = "Condición del Pedido")]
        [Required(ErrorMessage = "El condición del pedido es un campo requerido.")]
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
        public int ConditionId { get; set; }
        [Display(Name = "Usuario")]
        public Usuario? User { get; set; }
        [Display(Name = "Estado del Pedido")]
        public Estado? Condition { get; set; }
        public ICollection<Detalle>? Detalles { get; set; }

    }
}
