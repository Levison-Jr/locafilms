using LocaFilms.Models;

namespace LocaFilms.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieModel>> GetAllMoviesAsync();
        Task<MovieModel?> GetMovieByIdAsync(int id);
    }
}
