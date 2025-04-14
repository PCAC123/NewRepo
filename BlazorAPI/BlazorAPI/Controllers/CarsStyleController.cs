using BlazorAPI.IRepo;
using BlazorAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsStyleController : ControllerBase
    {
        private readonly ICarsStyleRepository _repository;

        public CarsStyleController(ICarsStyleRepository repository)
        {
            _repository = repository;
        }

        // GET: api/CarsStyle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarStyle>>> GetAll()
        {
            var styles = await _repository.GetAllStylesAsync();
            return Ok(styles);
        }

        // GET: api/CarsStyle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarStyle>> GetById(int id)
        {
            var style = await _repository.GetStyleByIdAsync(id);
            if (style == null)
                return NotFound();

            return Ok(style);
        }

        // POST: api/CarsStyle
        [HttpPost]
        public async Task<ActionResult> Create(CarStyle style)
        {
            await _repository.AddStyleAsync(style);
            return CreatedAtAction(nameof(GetById), new { id = style.StyleId }, style);
        }

        // PUT: api/CarsStyle/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CarStyle style)
        {
            if (id != style.StyleId)
                return BadRequest("ID không khớp");

            await _repository.UpdateStyleAsync(style);
            return NoContent();
        }

        // DELETE: api/CarsStyle/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.RemoveStyleAsync(id);
            return NoContent();
        }
    }
}
