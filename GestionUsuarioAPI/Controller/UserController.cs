using GestionUsuarioAPI.Data.Repositories;
using GestionUsuarioAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionUsuarioAPI.Controller;

    [Route("api/User")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet ()]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsers()
        {
            return Ok(await _userRepository.GetAllUsers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUser(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUser(Usuario user)
        {
            var newUser = await _userRepository.AddUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = newUser.IdUser }, newUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, Usuario user)
        {
            if (id != user.IdUser)
            {
                return BadRequest();
            }

            await _userRepository.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);
            return NoContent();
        }
    }
