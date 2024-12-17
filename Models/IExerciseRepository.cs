namespace olympo_webapi.Models
{
	public interface IExerciseRepository
	{
		Task AddAsync(Exercise exercise);
		Task<List<Exercise>> GetAsync();
		Task<Exercise?> GetByIdAsync(int id);
		Task UpdateAsync(Exercise exercise);
		Task DeleteAsync(int id);
		Task<bool> ExistsAsync(int id);
	}
}
