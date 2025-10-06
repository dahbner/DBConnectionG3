// Controllers/EventsController.cs
using DBConnectionG3.Models.dtos;
using DBConnectionG3.Services;
using Microsoft.AspNetCore.Mvc;

namespace DBConnectionG3.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventService _service;

    public EventsController(IEventService service)
    {
        _service = service;
    }

    // GET /api/events?page=1&limit=10
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int limit = 10)
    {
        var (data, total, p, l) = await _service.GetAll(page, limit);
        return Ok(new { data, meta = new { page = p, limit = l, total } });
    }

    // GET /api/events/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetOne(Guid id)
    {
        var ev = await _service.GetById(id);
        return ev is null
            ? NotFound(new { error = "Event not found", status = 404 })
            : Ok(ev);
    }

    // POST /api/events
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEventDto dto)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var ev = await _service.Create(dto);
        return CreatedAtAction(nameof(GetOne), new { id = ev.Id }, ev);
    }

    // PUT /api/events/{id}
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEventDto dto)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var ev = await _service.Update(id, dto);
        return ev is null
            ? NotFound(new { error = "Event not found", status = 404 })
            : Ok(ev);
    }

    // DELETE /api/events/{id}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var ok = await _service.Delete(id);
        return ok ? NoContent() : NotFound(new { error = "Event not found", status = 404 });
    }
}
