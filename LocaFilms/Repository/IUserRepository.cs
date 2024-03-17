using LocaFilms.Models;

namespace LocaFilms.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> ListAsync();
        Task<UserModel?> GetByIsAsync(int id);
        Task AddAsync(UserModel user);
        Task UpdateAsync(UserModel user);
    }
}
