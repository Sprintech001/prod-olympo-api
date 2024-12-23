using Microsoft.EntityFrameworkCore;
using olympo_webapi.Models;

namespace olympo_webapi.Infrastructure
{
	public class SessionRepository : ISessionRepository
	{
		private readonly ConnectionContext _context;

		public SessionRepository(ConnectionContext context)
		{
			_context = context;
		}

		public async Task AddAsync(Session session)
		{
			await _context.Sessions.AddAsync(session);
			await _context.SaveChangesAsync();
		}

		public async Task<List<Session>> GetAsync()
		{
			return await _context.Sessions.ToListAsync();
		}

		public async Task<Session?> GetByIdAsync(int id)
		{
			return await _context.Sessions.FindAsync(id);
		}

		public async Task UpdateAsync(Session session)
		{
			_context.Sessions.Update(session);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var session = await _context.Sessions.FindAsync(id);
			if (session != null)
			{
				_context.Sessions.Remove(session);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<bool> ExistsAsync(int id)
		{
			return await _context.Sessions.AnyAsync(e => e.Id == id);
		}

		public void Add(Session session)
		{
			AddAsync(session).Wait();
		}

		public List<Session> Get()
		{
			return GetAsync().Result;
		}

		public Session? GetById(int id)
		{
			return GetByIdAsync(id).Result;
		}

		public void Delete(int id)
		{
			DeleteAsync(id).Wait();
		}

		public bool Exists(int id)
		{
			return ExistsAsync(id).Result;
		}
	}
}