using LocaFilms.Models;
using System.Collections;

namespace LocaFilms.Repository
{
    public interface IRentalRepository
    {
        Task<IEnumerable<MovieRentals>> GetByUserIdAsync(string id);
        Task<MovieRentals?> GetByUserMovieIds(string userId, int movieId);
        Task AddAsync(MovieRentals movieRental);
        Task UpdateAsync(MovieRentals movieRental);
        Task DeleteAsync(MovieRentals movieRental);
    }
}
