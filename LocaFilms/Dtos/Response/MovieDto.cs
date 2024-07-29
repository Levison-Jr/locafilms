using LocaFilms.Enums;

namespace LocaFilms.Dtos.Response
{
    public record MovieDto(
        int Id,
        string Title,
        string Description,
        string Category,
        MovieStatusEnum Status,
        decimal CostPerDay,
        DateTime RegistrationDateTime,
        DateTime LastModifiedDateTime);
}
