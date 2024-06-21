﻿using LocaFilms.Enums;
using System.ComponentModel.DataAnnotations;

namespace LocaFilms.Dtos.Request
{
    public record UpdateUserDto
    {
        [Required(ErrorMessage = "O campo 'FirstName' é obrigatório.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "O campo 'LastName' é obrigatório.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "O campo 'UserName' é obrigatório.")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "O campo 'Email' é obrigatório.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo 'PhoneNumber' é obrigatório.")]
        public string? PhoneNumber { get; set; }
    }
}
