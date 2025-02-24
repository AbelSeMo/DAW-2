using System.ComponentModel.DataAnnotations;

namespace DecoStation.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Display(Name = "Nombre Completo")]
        public string? FullName { get; set; }
        [Display(Name = "Correo electrónico")]
        [EmailAddress(ErrorMessage = "Dirección de correo electrónico invalida")]
        [Required(ErrorMessage = "El email del usuario es un campo requerido.")]
        public string? Email { get; set; }
        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "La dirección del usuario es un campo requerido.")]
        public string? Direction { get; set; }
        [Display(Name = "Código Postal")]
        [Required(ErrorMessage = "La código postal del usuario es un campo requerido.")]
        public string? CodigoPostal { get; set; }

        [Display(Name = "Número de teléfono")]
        [Required(ErrorMessage = "El número de teléfono del usuario es un campo requerido.")]
        public string? PhoneNumber { get; set; }
        public ICollection<Pedido>? Orders { get; set; }

    }
}
