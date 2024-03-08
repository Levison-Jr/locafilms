namespace LocaFilms.Models
{
    public class MovieRentals
    {
        public int UserId { get; set; }
        public UserModel User { get; set; }

        public int MovieId { get; set; }
        public MovieModel Movie { get; set; }
    }
}
