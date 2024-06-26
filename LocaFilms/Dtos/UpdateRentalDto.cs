﻿using LocaFilms.Enums;
using System.ComponentModel.DataAnnotations;

namespace LocaFilms.Dtos
{
    public record UpdateRentalDto
    {
        [Required(ErrorMessage = "O campo UserId é obrigatório.")]
        public int? UserId { get; set; }

        [Required(ErrorMessage = "O campo MovieId é obrigatório.")]
        public int? MovieId { get; set; }

        [Required(ErrorMessage = "O campo RentalEndDate é obrigatório.")]
        public DateTime? RentalEndDate { get; set; }

        [EnumDataType(typeof(RentalStatusEnum), ErrorMessage = "O valor para RentalStatus é inválido.")]
        public RentalStatusEnum RentalStatus { get; set; }

        [EnumDataType(typeof(PaymentStatusEnum), ErrorMessage = "O valor para PaymentStatus é inválido.")]
        public PaymentStatusEnum PaymentStatus { get; set; }
    }
}
