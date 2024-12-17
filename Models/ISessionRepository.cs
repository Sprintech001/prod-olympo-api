namespace olympo_webapi.Models
{
	public interface ISessionRepository
	{
		Task AddAsync(Session session);
		Task<List<Session>> GetAsync();
		Task<Session?> GetByIdAsync(int id);
		Task UpdateAsync(Session session);
		Task DeleteAsync(int id);
		Task<bool> ExistsAsync(int id);
	}
}
