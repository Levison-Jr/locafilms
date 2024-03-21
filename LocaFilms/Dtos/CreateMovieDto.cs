using LocaFilms.Enums;

namespace LocaFilms.Dtos
{
    public record CreateMovieDto(
        string Title,
        string Description,
        CategoryEnum Category,
        decimal CostPerDay,
        int NumberPhysicalMedia);
}
