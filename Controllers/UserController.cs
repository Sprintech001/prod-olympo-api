using Microsoft.AspNetCore.Mvc;
using olympo_webapi.Models;

namespace olympo_webapi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserRepository _userRepository;

		public UserController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<User>>> Get()
		{
			var users = await _userRepository.GetAsync();

			if (users == null || !users.Any())
			{
				return NotFound("No users found.");
			}

			return Ok(users);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<User>> GetById(int id)
		{
			var user = await _userRepository.GetByIdAsync(id);

			if (user == null)
			{
				return NotFound($"User with ID {id} not found.");
			}

			return Ok(user);
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] User user)
		{
			if (user == null)
			{
				return BadRequest("User data is required.");
			}

			await _userRepository.AddAsync(user);

			return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] User updatedUser)
		{
			if (updatedUser == null || id != updatedUser.Id)
			{
				return BadRequest("Dados de usuário inválidos ou ID incompatível.");
			}

			try
			{
				var existingUser = await _userRepository.GetByIdAsync(id);
				if (existingUser == null)
				{
					return NotFound($"Usuário com ID {id} não encontrado.");
				}

				existingUser.Name = updatedUser.Name;
				existingUser.Email = updatedUser.Email;
				existingUser.Photo = updatedUser.Photo;
				existingUser.Password = updatedUser.Password;

				await _userRepository.UpdateAsync(existingUser);

				return NoContent();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var user = await _userRepository.GetByIdAsync(id);
			if (user == null)
			{
				return NotFound($"User with ID {id} not found.");
			}

			await _userRepository.DeleteAsync(id);

			return NoContent();
		}
	}
}
