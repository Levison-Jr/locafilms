using LocaFilms.Enums;
using LocaFilms.Models;

namespace LocaFilms.Dtos
{
    public record RentalDto(
        int UserId,
        int MovieId,
        DateTime RentalStartDate,
        DateTime RentalEndDate,
        RentalStatusEnum RentalStatus,
        PaymentStatusEnum PaymentStatus,
        MovieModel Movie);
}
