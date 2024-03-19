using LocaFilms.Models;
using LocaFilms.Services.Communication;

namespace LocaFilms.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task<UserModel?> GetUserByIdAsync(int id);
        Task<UserResponse> CreateUserAsync(UserModel user);
        Task<UserResponse> UpdateUserAsync(int id, UserModel user);
        Task<UserResponse> DeleteUserAsync(int id);
    }
}
