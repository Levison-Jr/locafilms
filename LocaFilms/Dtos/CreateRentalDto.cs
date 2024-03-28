using LocaFilms.Enums;
using System.ComponentModel.DataAnnotations;

namespace LocaFilms.Dtos
{
    public record CreateRentalDto
    {
        [Required(ErrorMessage = "O campo UserId é obrigatório.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "O campo MovieId é obrigatório.")]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "O campo RentalStartDate é obrigatório.")]
        public DateTime? RentalStartDate { get; set; }

        [Required(ErrorMessage = "O campo RentalEndDate é obrigatório.")]
        public DateTime? RentalEndDate { get; set; }
    }
}
