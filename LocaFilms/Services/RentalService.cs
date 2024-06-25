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

        public async Task<IEnumerable<MovieRentals>> GetByUserId(string userId)
        {
            return await _rentalRepository.GetByUserIdAsync(userId);
        }

        public async Task<MovieRentals?> GetByUserMovieIds(string userId, int movieId)
        {
            return await _rentalRepository.GetByUserMovieIds(userId, movieId);
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

        public async Task<RentalResponse> UpdateRental(MovieRentals movieRental)
        {
            MovieRentals? rentalToUpdate = null;

            if (rentalToUpdate == null)
                return new RentalResponse($"Não existe um aluguel do usuário com id {movieRental.UserId} para o filme com id {movieRental.MovieId}");

            rentalToUpdate.RentalEndDate = movieRental.RentalEndDate;
            rentalToUpdate.RentalStatus = movieRental.RentalStatus;
            rentalToUpdate.PaymentStatus = movieRental.PaymentStatus;

            try
            {
                await _rentalRepository.UpdateAsync(rentalToUpdate);
                return new RentalResponse(rentalToUpdate);
            }
            catch (Exception ex)
            {
                return new RentalResponse($"Não foi possível atualizar o MovieRental. Erro: {ex.Message}");
            }
        }

        public async Task<RentalResponse> DeleteRental(string userId, int movieId)
        {
            var rentalToDelete = await _rentalRepository.GetByUserMovieIds(userId, movieId);

            if (rentalToDelete == null)
                return new RentalResponse($"Não existe um aluguel do usuário com id {userId} para o filme com id {movieId}");

            try
            {
                await _rentalRepository.DeleteAsync(rentalToDelete);
                return new RentalResponse(rentalToDelete);
            }
            catch (Exception ex)
            {
                return new RentalResponse($"Não foi possível deletar o MovieRental. Erro: {ex.Message}");
            }
        }
    }
}
