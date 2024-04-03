using LocaFilms.Models;

namespace LocaFilms.Repository
{
    public interface IRentalRepository
    {
        Task AddAsync(MovieRentals movieRental);
        Task UpdateAsync(MovieRentals movieRental);
    }
}
