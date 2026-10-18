using System.ComponentModel.DataAnnotations;

namespace CINEMA_System_APi.DTOs.MovieDTOs
{
    public class MovieDTO
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public int Duration { get; set; }
        public int ReleaseYear { get; set; }
        public decimal Rating { get; set; }
        public int TicketPrice { get; set; }
        public int AvailableSeats { get; set; }

    }
}
