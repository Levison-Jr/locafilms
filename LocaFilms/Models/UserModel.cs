using LocaFilms.Enums;

namespace LocaFilms.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public PerfilEnum Perfil { get; set; }
        public DateTime RegistrationDate { get; set; }
        public decimal Balance { get; set; }

        public IList<MovieRentals> MovieRentals { get; set; }
    }
}
