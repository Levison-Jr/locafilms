using LocaFilms.Dtos.Request;
using LocaFilms.Dtos.Response;
using LocaFilms.Models;
using LocaFilms.Services.Communication;
using Microsoft.AspNetCore.Identity;

namespace LocaFilms.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly AspNetUserManager<UserModel> _aspNetUserManager;
        public IdentityService(AspNetUserManager<UserModel> aspNetUserManager)
        {
            _aspNetUserManager = aspNetUserManager;
        }

        public async Task<UserResponse> Register(CreateUserDto createUserDto)
        {
            var user = new UserModel()
            {
                Email = createUserDto.Email,
                UserName = createUserDto.Email,
                EmailConfirmed = true
            };

            try
            {
                var result = await _aspNetUserManager.CreateAsync(user, createUserDto.Password ?? "");

                if (!result.Succeeded)
                {
                    return new UserResponse($"Não foi possível cadastrar o usuário. ${result.Errors.Select(e => e.Description).First()}");
                }

                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"Não foi possível cadastrar o usuário. ${ex.Message}");
            }
        }
    }
}
