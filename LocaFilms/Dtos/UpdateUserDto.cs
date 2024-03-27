using LocaFilms.Enums;
using System.ComponentModel.DataAnnotations;

namespace LocaFilms.Dtos
{
    public record UpdateUserDto
    {
        [Required(ErrorMessage = "O campo 'Name' é obrigatório.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "O campo 'Username' é obrigatório.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "O campo 'Password' é obrigatório.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "O campo 'Email' é obrigatório.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo 'Phone' é obrigatório.")]
        public string? Phone { get; set; }

        [EnumDataType(typeof(PerfilEnum), ErrorMessage = "O valor para Perfil é inválido.")]
        public PerfilEnum Perfil { get; set; }

        [Required(ErrorMessage = "O campo 'IsActive' é obrigatório.")]
        public bool? IsActive { get; set; }
    }
}
