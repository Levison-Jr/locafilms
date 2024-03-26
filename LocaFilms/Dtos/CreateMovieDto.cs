using LocaFilms.Enums;
using System.ComponentModel.DataAnnotations;

namespace LocaFilms.Dtos
{
    public record CreateMovieDto
    {
        [Required(ErrorMessage = "O campo 'Title' é obrigatório.")]
        public string? Title { get; init; }

        [Required(ErrorMessage = "O campo 'Description' é obrigatória.")]
        public string? Description { get; init; }

        [EnumDataType(typeof(CategoryEnum), ErrorMessage = "O valor para Category é inválido.")]
        public CategoryEnum Category { get; init; }

        [Required(ErrorMessage = "O campo 'CostPerDay' é obrigatório.")]
        [Range(0.01, 100, ErrorMessage = "O valor para 'CostPerDay' deve estar entre 0.01 e 100")]
        public decimal CostPerDay { get; init; }

        [Required(ErrorMessage = "O campo 'NumberPhysicalMedia' é obrigatório.")]
        [Range(1, 100, ErrorMessage = "O valor para 'NumberPhysicalMedia' deve estar entre 1 e 100")]
        public int NumberPhysicalMedia { get; init; }
    }
}
