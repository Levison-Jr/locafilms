using LocaFilms.Enums;

namespace LocaFilms.Models
{
    public class MovieRentals
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public RentalStatusEnum RentalStatus { get; set; }
        public PaymentStatusEnum PaymentStatus { get; set; }

        public UserModel User { get; set; }
        public MovieModel Movie { get; set; }
    }
}
