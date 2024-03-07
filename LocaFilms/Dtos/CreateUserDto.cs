using LocaFilms.Enums;

namespace LocaFilms.Dtos
{
    public record CreateUserDto(
        string Name,
        string Username,
        string Password,
        string Email,
        string Phone,
        PerfilEnum Perfil);
}
