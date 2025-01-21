using System.ComponentModel.DataAnnotations;

namespace DecoStation.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        [Display(Name = "Fecha de envío")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de envío es un campo requerido")]
        public DateTime? DeliveryTime { get; set; }
        [Display(Name = "Condición del Pedido")]
        [Required(ErrorMessage = "El condición del pedido es un campo requerido.")]
        public int ConditionId { get; set; }

        public int ClientId { get; set; }
        public Cliente? Client { get; set; }
        public Estado? Condition { get; set; }
    }
}
