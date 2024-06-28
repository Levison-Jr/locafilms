using LocaFilms.Dtos.Request;
using LocaFilms.Models;
using LocaFilms.Services.Communication;
using LocaFilms.Services.Identity.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace LocaFilms.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly AspNetUserManager<UserModel> _aspNetUserManager;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly JwtOptions _jwtOptions;
        public IdentityService(AspNetUserManager<UserModel> aspNetUserManager,
                               SignInManager<UserModel> signInManager,
                               IOptions<JwtOptions> jwtOptions)
        {
            _aspNetUserManager = aspNetUserManager;
            _signInManager = signInManager;
            _jwtOptions = jwtOptions.Value;
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
