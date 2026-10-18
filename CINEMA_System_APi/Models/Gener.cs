using System.ComponentModel.DataAnnotations;

namespace CINEMA_System_APi.Models
{
    public class Gener
    {
        [Key]
        public int id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
