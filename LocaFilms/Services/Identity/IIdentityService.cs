using LocaFilms.Dtos.Request;
using LocaFilms.Dtos.Response;
using LocaFilms.Services.Communication;

namespace LocaFilms.Services.Identity
{
    public interface IIdentityService
    {
        Task<UserResponse> Register(CreateUserDto createUserDto); 
    }
}
