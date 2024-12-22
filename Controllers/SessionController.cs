using Microsoft.AspNetCore.Mvc;
using olympo_webapi.Models;


namespace olympo_webapi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SessionController : ControllerBase
	{
		private readonly ISessionRepository _sessionRepository;

		public SessionController(ISessionRepository sessionRepository)
		{
			_sessionRepository = sessionRepository;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Session>>> Get()
		{
			var sessions = await _sessionRepository.GetAsync();

			if (sessions == null || !sessions.Any())
			{
				return NotFound("No sessions found.");
			}

			return Ok(sessions);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Session>> GetById(int id)
		{
			var session = await _sessionRepository.GetByIdAsync(id);

			if (session == null)
			{
				return NotFound($"Session with ID {id} not found.");
			}

			return Ok(session);
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Session session)
		{
			if (session == null)
			{
				return BadRequest("Session data is required.");
			}

			await _sessionRepository.AddAsync(session);

			return CreatedAtAction(nameof(GetById), new { id = session.Id }, session);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] Session updatedSession)
		{
			if (updatedSession == null || id != updatedSession.Id)
			{
				return BadRequest("Invalid session data or mismatched ID.");
			}

			try
			{
				await _sessionRepository.UpdateAsync(updatedSession);
				return NoContent();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var session = await _sessionRepository.GetByIdAsync(id);
			if (session == null)
			{
				return NotFound($"Session with ID {id} not found.");
			}

			await _sessionRepository.DeleteAsync(id);

			return NoContent();
		}
	}
}
