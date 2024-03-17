using LocaFilms.Models;
using LocaFilms.Services.Communication;

namespace LocaFilms.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task<UserModel?> GetUserByIdAsync(int id);
        Task<SaveUserResponse> CreateUserAsync(UserModel user);
        Task<SaveUserResponse> UpdateUserAsync(int id, UserModel user);
    }
}
