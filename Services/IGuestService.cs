using DBConnectionG3.Models;
using DBConnectionG3.Models.dtos;

namespace DBConnectionG3.Services
{
    public interface IGuestService
    {
        Task<IEnumerable<Guest>> GetAll();
        Task<Guest?> GetById(Guid id);
        Task<Guest> Create(CreateGuestDto dto);
        Task<bool> Delete(Guid id);
    }
}
