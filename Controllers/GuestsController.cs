using DBConnectionG3.Models.dtos;
using DBConnectionG3.Services;
using Microsoft.AspNetCore.Mvc;

namespace DBConnectionG3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestsController : ControllerBase
    {
        private readonly IGuestService _service;

        public GuestsController(IGuestService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var guests = await _service.GetAll();
            return Ok(guests);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var guest = await _service.GetById(id);
            return guest == null
                ? NotFound(new { error = "Guest not found", status = 404 })
                : Ok(guest);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGuestDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var guest = await _service.Create(dto);
            return CreatedAtAction(nameof(GetOne), new { id = guest.Id }, guest);
        }
    }
}