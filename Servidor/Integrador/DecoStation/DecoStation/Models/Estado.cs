﻿using System.ComponentModel.DataAnnotations;

namespace DecoStation.Models
{
    public class Estado
    {
        public int Id { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La descripción del estado es un campo requerido.")]
        public string? Description { get; set; }

        public ICollection<Pedido>? Pedidos { get; set; }
    }
}
