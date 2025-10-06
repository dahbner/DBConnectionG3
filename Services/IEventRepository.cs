using DBConnectionG3.Models;
using DBConnectionG3.Models.dtos;

namespace DBConnectionG3.Services;

public interface IEventService
{
    Task<(List<Event> data, int total, int page, int limit)> GetAll(int page, int limit);
    Task<Event?> GetById(Guid id);
    Task<Event> Create(CreateEventDto dto);
    Task<Event?> Update(Guid id, UpdateEventDto dto);
    Task<bool> Delete(Guid id);
}