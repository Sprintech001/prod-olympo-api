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

		public void Add(Session session)
		{
			_context.Sessions.Add(session);
			_context.SaveChanges();
		}

		public List<Session> Get()
		{
			return _context.Sessions.ToList();
		}

		public Session? GetById(int id)
		{
			return _context.Sessions.Find(id);
		}

		public void Update(Session session)
		{
			_context.Sessions.Update(session);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			var session = _context.Sessions.Find(id);
			if (session != null)
			{
				_context.Sessions.Remove(session);
				_context.SaveChanges();
			}
		}

		public bool Exists(int id)
		{
			return _context.Sessions.Any(e => e.Id == id);
		}
	}
}
