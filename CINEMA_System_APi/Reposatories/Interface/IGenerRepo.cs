using CINEMA_System_APi.DTOs.GenerDTOs;
using CINEMA_System_APi.Models;

namespace CINEMA_System_APi.Reposatories.Interface
{
    public interface IGenerRepo : IGenericRepo<Gener>
    {
        Task<GenerWithMovieDTO> GenerWithMovieDTO(int id);
    }
}
