namespace olympo_webapi.Models
{
	public interface IExerciseRepository
	{
		void Add(Exercise exercise);
		List<Exercise> Get();
		Exercise? GetById(int id);
		void Update(Exercise exercise);
		void Delete(int id);
		bool Exists(int id);
	}
}
