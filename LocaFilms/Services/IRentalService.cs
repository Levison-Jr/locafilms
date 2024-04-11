using LocaFilms.Models;
using LocaFilms.Services.Communication;

namespace LocaFilms.Services
{
    public interface IRentalService
    {
        Task<IEnumerable<MovieRentals>> GetByUserId(int userId);
        Task<MovieRentals?> GetByUserMovieIds(int userId, int movieId);
        Task<RentalResponse> CreateRental(MovieRentals movieRental);
        Task<RentalResponse> UpdateRental(MovieRentals movieRental);
        Task<RentalResponse> DeleteRental(int userId, int movieId);
    }
}
