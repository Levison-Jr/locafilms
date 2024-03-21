using LocaFilms.Contexts;
using LocaFilms.Models;
using Microsoft.EntityFrameworkCore;

namespace LocaFilms.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        { }

        public async Task<IEnumerable<UserModel>> ListAsync()
        {
            return await _appDbContext.Users.ToListAsync();
        }

        public async Task<UserModel?> GetByIdAsync(int id)
        {
            UserModel? user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task AddAsync(UserModel user)
        {
            await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserModel user)
        {
            _appDbContext.Users.Update(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserModel user)
        {
            _appDbContext.Users.Remove(user);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
