using LocaFilms.Enums;
using System.Text.Json.Serialization;

namespace LocaFilms.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public MovieStatusEnum Status { get; set; }
        public decimal CostPerDay { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }

        [JsonIgnore]
        public IList<MovieRentals> MovieRentals { get; set; }
    }
}
