using LocaFilms.Models;

namespace LocaFilms.Repository
{
    public interface IMovieRepository
    {
        Task<IEnumerable<MovieModel>> ListAsync();
        Task<MovieModel?> GetMovieById(int id);
    }
}
