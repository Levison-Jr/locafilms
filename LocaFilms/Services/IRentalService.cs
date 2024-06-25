using LocaFilms.Models;
using LocaFilms.Services.Communication;

namespace LocaFilms.Services
{
    public interface IRentalService
    {
        Task<IEnumerable<MovieRentals>> GetByUserId(string userId);
        Task<MovieRentals?> GetByUserMovieIds(string userId, int movieId);
        Task<RentalResponse> CreateRental(MovieRentals movieRental);
        Task<RentalResponse> UpdateRental(MovieRentals movieRental);
        Task<RentalResponse> DeleteRental(string userId, int movieId);
    }
}
