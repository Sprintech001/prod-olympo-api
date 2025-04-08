using Microsoft.AspNetCore.Mvc;
using olympo_webapi.Models;
using olympo_webapi.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace olympo_webapi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SessionController : ControllerBase
	{
		private readonly ISessionRepository _sessionRepository;
		private readonly ConnectionContext _context;

		public SessionController(ISessionRepository sessionRepository, ConnectionContext context)
		{
			_sessionRepository = sessionRepository;
			_context = context;
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
		public async Task<ActionResult<Session>> GetSessionById(int id)
		{
			var session = await _context.Sessions
				.Include(s => s.User)
				.Include(s => s.Exercise)
				.FirstOrDefaultAsync(s => s.Id == id);

			if (session == null)
			{
				return NotFound();
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
			await _context.Entry(session).Reference(s => s.User).LoadAsync();
			await _context.Entry(session).Reference(s => s.Exercise).LoadAsync();

			return CreatedAtAction(nameof(GetSessionById), new { id = session.Id }, session);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] Session? updatedSession)
		{
			if (updatedSession == null)
			{
				return BadRequest("Dados inválidos: O corpo da requisição está vazio.");
			}

			if (updatedSession.Id == null || id != updatedSession.Id)
			{
				return BadRequest("O ID da sessão no corpo da requisição não corresponde ao ID da URL.");
			}

			var exists = await _sessionRepository.ExistsAsync(id);
			if (!exists)
			{
				return NotFound($"Sessão com ID {id} não encontrada.");
			}

			try
			{
				await _sessionRepository.UpdateAsync(updatedSession);
				return NoContent();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
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