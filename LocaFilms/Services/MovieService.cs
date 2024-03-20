using LocaFilms.Models;
using LocaFilms.Repository;

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
            var movie = await _movieRepository.GetMovieById(id);

            return movie;
        }
    }
}
