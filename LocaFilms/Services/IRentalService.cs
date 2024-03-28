using LocaFilms.Models;
using LocaFilms.Services.Communication;

namespace LocaFilms.Services
{
    public interface IRentalService
    {
        Task<RentalResponse> CreateRental(MovieRentals movieRental);
        Task<RentalResponse> UpdateRental(MovieRentals movieRental);
    }
}
