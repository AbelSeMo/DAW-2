using System.ComponentModel.DataAnnotations;

namespace DecoStation.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Display(Name = "Nombre Completo")]
        [Required(ErrorMessage = "El nombre completo del cliente es un campo requerido.")]
        public string? FullName { get; set; }
        [Display(Name = "Correo electrónico")]
        [EmailAddress(ErrorMessage = "Dirección de correo electrónico invalida")]
        public string? Email { get; set; }
        [Display(Name = "Dirección")]
        public string? Direction { get; set; }
        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Número de teléfono")]
        public string? PhoneNumber { get; set; }
        public ICollection<Pedido>? Orders { get; set; }

    }
}
