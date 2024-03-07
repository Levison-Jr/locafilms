namespace LocaFilms.Dtos
{
    public record CreateMovieDto(
        string Title,
        string Description,
        string Category,
        decimal CostPerDay,
        int NumberPhysicalMedia);
}
