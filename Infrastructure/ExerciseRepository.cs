using Microsoft.EntityFrameworkCore;
using olympo_webapi.Models;

namespace olympo_webapi.Infrastructure
{
	public class ExerciseRepository : IExerciseRepository
	{
		private readonly ConnectionContext _context;

		public ExerciseRepository(ConnectionContext context)
		{
			_context = context;
		}

		public void Add(Exercise exercise)
		{
			_context.Exercises.Add(exercise);
			_context.SaveChanges();
		}

		public List<Exercise> Get()
		{
			return _context.Exercises.ToList();
		}

		public Exercise? GetById(int id)
		{
			return _context.Exercises.Find(id);
		}

		public void Update(Exercise exercise)
		{
			_context.Exercises.Update(exercise);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			var exercise = _context.Exercises.Find(id);
			if (exercise != null)
			{
				_context.Exercises.Remove(exercise);
				_context.SaveChanges();
			}
		}

		public bool Exists(int id)
		{
			return _context.Exercises.Any(e => e.Id == id);
		}
	}
}
