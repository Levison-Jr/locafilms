using LocaFilms.Models;

namespace LocaFilms.Repository
{
    public interface IRentalRepository
    {
        Task AddAsync(UserModel user, MovieModel movie);
        Task UpdateAsync(UserModel user, MovieModel movie);
    }
}
