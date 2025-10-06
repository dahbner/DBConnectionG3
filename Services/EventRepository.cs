// Services/EventService.cs
using DBConnectionG3.Data;
using DBConnectionG3.Models;
using DBConnectionG3.Models.dtos;
using DBConnectionG3.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace DBConnectionG3.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _repo;
    private readonly AppDbContext _db;

    public EventService(IEventRepository repo, AppDbContext db)
    {
        _repo = repo;
        _db = db;
    }

    public async Task<(List<Event> data, int total, int page, int limit)> GetAll(int page, int limit)
    {
        var data = await _repo.ListAsync(page, limit);
        var total = await _repo.CountAsync();
        return (data, total, page, limit);
    }

    public Task<Event?> GetById(Guid id) => _repo.GetAsync(id);

    public async Task<Event> Create(CreateEventDto dto)
    {
        var ev = new Event
        {
            Title = dto.Title,
            Date = dto.Date,
            Capacity = dto.Capacity
        };
        await _repo.AddAsync(ev);
        await _db.SaveChangesAsync();
        return ev;
    }

    public async Task<Event?> Update(Guid id, UpdateEventDto dto)
    {
        var ev = await _repo.GetAsync(id);
        if (ev is null) return null;

        if (dto.Title is not null) ev.Title = dto.Title;
        if (dto.Date is not null) ev.Date = dto.Date.Value;
        if (dto.Capacity is not null) ev.Capacity = dto.Capacity.Value;

        await _db.SaveChangesAsync();
        return ev;
    }

    public async Task<bool> Delete(Guid id)
    {
        var ok = await _repo.DeleteAsync(id);
        if (!ok) return false;
        await _db.SaveChangesAsync();
        return true;
    }
}
