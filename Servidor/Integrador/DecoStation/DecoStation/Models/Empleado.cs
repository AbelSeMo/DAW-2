using System.ComponentModel.DataAnnotations;

namespace DecoStation.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        [Display(Name = "Nombre Completo")]
        [Required(ErrorMessage = "El nombre completo del empleado es un campo requerido.")]
        public string? FullName { get; set; }
        [Display(Name = "Correo electrónico")]
        [EmailAddress(ErrorMessage = "Dirección de correo electrónico invalida")]
        [Required(ErrorMessage = "El email del empleado es un campo requerido.")]
        public string? Email { get; set; }
        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "La dirección del empleado es un campo requerido.")]
        public string? Direction { get; set; }
        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de nacimiento del empleado es un campo requerido.")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Número de teléfono")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Puesto")]
        [Required(ErrorMessage = "El puesto del empleado es un campo requerido.")]
        public string? Place { get; set; }

        [Display(Name = "Salario")]
        [DataType(DataType.Currency, ErrorMessage = "Formato de salario no válido.")]
        [Range(0, double.MaxValue, ErrorMessage = "El salario debe ser un valor positivo.")]
        [Required(ErrorMessage = "El salario es un campo requerido.")]
        public decimal? Salary { get; set; }
    }
}
