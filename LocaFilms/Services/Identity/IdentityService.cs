using LocaFilms.Dtos.Request;
using LocaFilms.Models;
using LocaFilms.Services.Communication;
using LocaFilms.Services.Identity.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
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

        private async Task<string> GerarTokenJwt(string email)
        {
            var user = await _aspNetUserManager.FindByEmailAsync(email);
            if (user == null)
                return string.Empty;

            List<Claim> claims =
            [
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                .. await _aspNetUserManager.GetClaimsAsync(user),
            ];

            var roles = await _aspNetUserManager.GetRolesAsync(user);
            foreach (var role in roles)
                claims.Add(new Claim("role", role));

            var tokenJwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: DateTime.Now.AddSeconds(_jwtOptions.AccessTokenExpiration),
                notBefore: DateTime.Now,
                signingCredentials: _jwtOptions.SigningCredentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenJwt);
        }
    }
}
