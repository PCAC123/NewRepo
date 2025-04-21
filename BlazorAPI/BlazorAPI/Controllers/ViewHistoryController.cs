
using BlazorAPI.IRepo;
using BlazorAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewHistoryController : ControllerBase
    {
        private readonly IViewsHistoryRepository _repository;

        public ViewHistoryController(IViewsHistoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewHistory>>> GetAll()
        {
            var views = await _repository.GetAllViewsAsync();
            return Ok(views);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<ViewHistory>>> GetByUserId(int userId)
        {
            var views = await _repository.GetViewsByUserIdAsync(userId);
            return Ok(views);
        }

        
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ViewHistory history)
        {
            await _repository.AddViewAsync(history);
            return Ok(history);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.DeleteViewAsync(id);
            return NoContent();
        }
    }
}
