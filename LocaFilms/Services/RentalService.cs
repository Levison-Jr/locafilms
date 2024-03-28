using LocaFilms.Models;
using LocaFilms.Repository;
using LocaFilms.Services.Communication;

namespace LocaFilms.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        public RentalService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;            
        }

        public Task<RentalResponse> CreateRental(MovieRentals movieRental)
        {
            throw new NotImplementedException();
        }

        public Task<RentalResponse> UpdateRental(MovieRentals movieRental)
        {
            throw new NotImplementedException();
        }
    }
}
