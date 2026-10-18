using CINEMA_System_APi.Data;
using CINEMA_System_APi.DTOs.GenerDTOs;
using CINEMA_System_APi.DTOs.MovieDTOs;
using CINEMA_System_APi.Models;
using CINEMA_System_APi.Reposatories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CINEMA_System_APi.Reposatories.Implmentation
{
    public class GenerRepo : GenericRepo<Gener>, IGenerRepo
    {
        private readonly AppDbContext _context;
        public GenerRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<GenerWithMovieDTO> GenerWithMovieDTO(int id)
        {
            var items = _context.Geners
                .Include(g => g.Movies)
                .Where(g => g.id == id)
                .Select(g => new GenerWithMovieDTO
            {
                id = g.id,
                Name = g.Name,
                Movies = g.Movies.Select(m => new MovieDTO
                {
                    id = m.id,
                    Title = m.Title,
                    Duration = m.Duration,
                    AvailableSeats = m.AvailableSeats,
                }).ToList()
            }).FirstOrDefaultAsync();


            return items;
        }
    }
}
