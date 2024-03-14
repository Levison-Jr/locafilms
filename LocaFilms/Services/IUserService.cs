using LocaFilms.Models;
using LocaFilms.Services.Communication;

namespace LocaFilms.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task<CreateUserResponse> CreateUserAsync(UserModel user);
    }
}
