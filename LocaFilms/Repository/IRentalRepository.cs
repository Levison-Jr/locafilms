using LocaFilms.Models;
using System.Collections;

namespace LocaFilms.Repository
{
    public interface IRentalRepository
    {
        Task<IEnumerable<MovieRentals>> GetByUserIdAsync(int id);
        Task<MovieRentals?> GetByUserMovieIds(int userId, int movieId);
        Task AddAsync(MovieRentals movieRental);
        Task UpdateAsync(MovieRentals movieRental);
        Task DeleteAsync(MovieRentals movieRental);
    }
}
