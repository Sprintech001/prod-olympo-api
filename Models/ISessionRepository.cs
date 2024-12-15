namespace olympo_webapi.Models
{
	public interface ISessionRepository
	{
		void Add(Session session);
		List<Session> Get();
		Session? GetById(int id);
		void Update(Session session);
		void Delete(int id);
		bool Exists(int id);
	}
}
