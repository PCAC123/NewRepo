using BlazorAPI.IRepo;
using BlazorAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _usersRepository.GetAllUsersAsync();
            return Ok(users);
        }
        [HttpGet("{id}")]   
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _usersRepository.GetUserByIdAsync(id);
            if (user== null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpGet("{email}/{password}")]
        public async Task<ActionResult<User>> GetUserByEmailAndPassword(string email, string password)
        {
            var user = await _usersRepository.GetUserByEmailAndPasswordAsync(email, password);
            if (user == null) return NotFound();
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] User user)
        {
            await _usersRepository.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id , [FromBody] User user)
        {
            if (user == null) return NotFound();
            if (id != user.UserId) return BadRequest("ID không khớp");
            var existingUser = await _usersRepository.GetUserByIdAsync(id);
            if (existingUser == null) return NotFound();
            await _usersRepository.UpdateUserAsync(user);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _usersRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            await _usersRepository.RemoveUserAsync(id);
            return NoContent();
        }
    }
}
