using LocaFilms.Enums;
using System.ComponentModel.DataAnnotations;

namespace LocaFilms.Dtos.Request
{
    public record CreateMovieDto
    {
        [Required(ErrorMessage = "O campo 'Title' é obrigatório.")]
        public string? Title { get; init; }

        [Required(ErrorMessage = "O campo 'Description' é obrigatória.")]
        public string? Description { get; init; }

        [Required(ErrorMessage = "O campo 'Category' é obrigatória.")]
        public string? Category { get; init; }

        [Required(ErrorMessage = "O campo 'CostPerDay' é obrigatório.")]
        [Range(0.01, 100, ErrorMessage = "O valor para 'CostPerDay' deve estar entre 0.01 e 100")]
        public decimal? CostPerDay { get; init; }
    }
}
