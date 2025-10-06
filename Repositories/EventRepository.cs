using DBConnectionG3.Data;
using DBConnectionG3.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DBConnectionG3.Repositories;

public class EventRepository : IEventRepository
{
    private readonly AppDbContext _db;

    public EventRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Event>> ListAsync(int page = 1, int limit = 10)
    {
        page = page < 1 ? 1 : page;
        limit = limit < 1 ? 10 : limit > 100 ? 100 : limit;

        return await _db.Events.AsNoTracking()
            .OrderBy(e => e.Date)
            .Skip((page - 1) * limit)
            .Take(limit)
            .ToListAsync();
    }

    public Task<int> CountAsync() => _db.Events.CountAsync();

    public Task<Event?> GetAsync(Guid id) => _db.Events.FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(Event ev)
    {
        await _db.Events.AddAsync(ev);
        // NO SaveChanges aquí (lo hace el Service)
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var ev = await _db.Events.FirstOrDefaultAsync(x => x.Id == id);
        if (ev is null) return false;
        _db.Events.Remove(ev);
        // NO SaveChanges aquí (lo hace el Service)
        return true;
    }
}