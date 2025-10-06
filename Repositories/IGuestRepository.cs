using DBConnectionG3.Models;

namespace DBConnectionG3.Repositories
{
    public interface IGuestRepository
    {
        Task<IEnumerable<Guest>> GetAll();
        Task<Guest?> GetById(Guid id);
        Task Add(Guest guest);
        Task Delete(Guid id);
    }
}
