using LocaFilms.Contexts;
using LocaFilms.Models;

namespace LocaFilms.Repository
{
    public class RentalRepository : BaseRepository, IRentalRepository
    {
        public RentalRepository(AppDbContext appDbContext) : base(appDbContext)
        {}

        public async Task AddAsync(MovieRentals movieRental)
        {
            await _appDbContext.MovieRentals.AddAsync(movieRental);
            await _appDbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(MovieRentals movieRental)
        {
            throw new NotImplementedException();
        }
    }
}
