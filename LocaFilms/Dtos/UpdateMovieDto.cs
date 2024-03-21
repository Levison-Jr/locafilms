using LocaFilms.Enums;

namespace LocaFilms.Dtos
{
    public record UpdateMovieDto(
        string Title,
        string Description,
        CategoryEnum Category,
        bool IsAvailable,
        decimal CostPerDay,
        int NumberPhysicalMedia);
}
