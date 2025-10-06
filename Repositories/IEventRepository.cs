using DBConnectionG3.Models;

namespace DBConnectionG3.Repositories;

public interface IEventRepository
{
    Task<List<Event>> ListAsync(int page = 1, int limit = 10);
    Task<int> CountAsync();
    Task<Event?> GetAsync(Guid id);
    Task AddAsync(Event ev);
    Task<bool> DeleteAsync(Guid id);
}