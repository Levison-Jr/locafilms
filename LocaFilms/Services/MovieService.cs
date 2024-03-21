using LocaFilms.Models;
using LocaFilms.Repository;
using LocaFilms.Services.Communication;

namespace LocaFilms.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieModel>> GetAllMoviesAsync()
        {
            var movies = await _movieRepository.ListAsync();
            
            return movies;
        }

        public async Task<MovieModel?> GetMovieByIdAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);

            return movie;
        }

        public async Task<MovieResponse> CreateMovieAsync(MovieModel movie)
        {
            try
            {
                await _movieRepository.AddAsync(movie);
                return new MovieResponse(movie);
            }
            catch (Exception ex)
            {
                return new MovieResponse($"Houve um erro ao tentar criar o movie. Erro: {ex.Message}");
            }
        }
    }
}
