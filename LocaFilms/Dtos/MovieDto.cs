using LocaFilms.Enums;
using LocaFilms.Models;

namespace LocaFilms.Dtos
{
    public record MovieDto(
        int Id,
        string Title,
        string Description,
        CategoryEnum Category,
        bool IsAvailable,
        decimal CostPerDay,
        int NumberPhysicalMedia,
        DateTime RegistrationDateTime,
        DateTime LastModifiedDateTime);
}
