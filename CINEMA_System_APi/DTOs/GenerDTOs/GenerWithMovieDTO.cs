using CINEMA_System_APi.DTOs.MovieDTOs;

namespace CINEMA_System_APi.DTOs.GenerDTOs
{
    public class GenerWithMovieDTO
    {
        public int id { get; set; }
        public string Name { get; set; }


        public ICollection<MovieDTO> Movies { get; set; }
    }
}
