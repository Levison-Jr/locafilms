using LocaFilms.Enums;
using LocaFilms.Models;

namespace LocaFilms.Dtos.Response
{
    public record RentalDto(
        string UserId,
        int MovieId,
        DateTime RentalStartDate,
        DateTime RentalEndDate,
        RentalStatusEnum RentalStatus,
        PaymentStatusEnum PaymentStatus,
        MovieModel Movie);
}
