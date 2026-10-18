using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CINEMA_System_APi.Models
{
    public class Movie
    {
        [Key]
        public int id { get; set; }
        [Required , MaxLength(200)]
        public string Title { get; set; }
        [Required , MaxLength(100)]
        public string Director { get; set; }
        [Required, Range(30 , 300)]
        public int Duration { get; set; }
        [Required , Range(1950,2026)]
        public int ReleaseYear { get; set; }
        [Range(0,10)]
        public decimal Rating { get; set; }
        [Range(1,int.MaxValue)]
        public int TicketPrice { get; set; }
        [Range(0,int.MaxValue)]
        public int AvailableSeats { get; set; }



        public int GenerId { get; set; }
        [ForeignKey(nameof(GenerId))]
        public Gener Gener { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    }
}
