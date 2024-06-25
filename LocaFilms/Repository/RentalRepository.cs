using LocaFilms.Contexts;
using LocaFilms.Models;
using Microsoft.EntityFrameworkCore;

namespace LocaFilms.Repository
{
    public class RentalRepository : BaseRepository, IRentalRepository
    {
        public RentalRepository(AppDbContext appDbContext) : base(appDbContext)
        {}

        public async Task<IEnumerable<MovieRentals>> GetByUserIdAsync(string id)
        {
            return await _appDbContext.MovieRentals
                .Where(u => u.UserId  == id)
                .Include(mr => mr.Movie)
                .ToListAsync();
        }

        public async Task<MovieRentals?> GetByUserMovieIds(string userId, int movieId)
        {
            return await _appDbContext.MovieRentals.Where(mr => (mr.UserId == userId && mr.MovieId == movieId)).FirstAsync();
        }

        public async Task AddAsync(MovieRentals movieRental)
        {
            await _appDbContext.MovieRentals.AddAsync(movieRental);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(MovieRentals movieRental)
        {
            _appDbContext.MovieRentals.Update(movieRental);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(MovieRentals movieRental)
        {
            _appDbContext.MovieRentals.Remove(movieRental);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
