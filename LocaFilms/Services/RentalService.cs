using LocaFilms.Models;
using LocaFilms.Repository;
using LocaFilms.Services.Communication;

namespace LocaFilms.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;

        public RentalService(
            IRentalRepository rentalRepository,
            IUserService userService,
            IMovieService movieService)
        {
            _rentalRepository = rentalRepository;
            _userService = userService;
            _movieService = movieService;
        }

        public async Task<IEnumerable<MovieRentals>> GetByUserId(int userId)
        {
            return await _rentalRepository.GetByUserIdAsync(userId);
        }

        public async Task<RentalResponse> CreateRental(MovieRentals movieRental)
        {
            var user = await _userService.GetUserByIdAsync(movieRental.UserId);
            var movie = await _movieService.GetMovieByIdAsync(movieRental.MovieId);

            if (user == null || movie == null)
                return new RentalResponse("O usuário e/ou o filme não está cadastrado.");

            try
            {
                await _rentalRepository.AddAsync(movieRental);
                return new RentalResponse(movieRental);
            }
            catch (Exception ex)
            {
                return new RentalResponse($"Não foi possível criar o MovieRental. Erro: {ex.Message}");
            }        
        }

        public Task<RentalResponse> UpdateRental(MovieRentals movieRental)
        {
            throw new NotImplementedException();
        }
    }
}
