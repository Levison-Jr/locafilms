using LocaFilms.Enums;
using LocaFilms.Models;

namespace LocaFilms.Dtos
{
    public record UserDto(
        int Id,
        string Name,
        string Username,
        string Email,
        string Phone,
        PerfilEnum Perfil,
        bool IsActive,
        DateTime RegistrationDate,
        decimal Balance);
}
