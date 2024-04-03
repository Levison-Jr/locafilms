using LocaFilms.Enums;

namespace LocaFilms.Dtos
{
    public record RentalDto(
        int UserId,
        int MovieId,
        DateTime RentalStartDate,
        DateTime RentalEndDate,
        RentalStatusEnum RentalStatus,
        PaymentStatusEnum PaymentStatus);
}
