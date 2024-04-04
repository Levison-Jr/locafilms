using LocaFilms.Models;
using System.Collections;

namespace LocaFilms.Repository
{
    public interface IRentalRepository
    {
        Task<IEnumerable<MovieRentals>> GetByUserIdAsync(int id);
        Task AddAsync(MovieRentals movieRental);
        Task UpdateAsync(MovieRentals movieRental);
    }
}
