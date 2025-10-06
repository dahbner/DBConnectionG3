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
    }
}