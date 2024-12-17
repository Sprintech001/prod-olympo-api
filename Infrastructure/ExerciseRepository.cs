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

		public async Task AddAsync(Exercise exercise)
		{
			await _context.Exercises.AddAsync(exercise);
			await _context.SaveChangesAsync();
		}

		public async Task<List<Exercise>> GetAsync()
		{
			return await _context.Exercises.Include(e => e.sessions).ToListAsync();
		}

		public async Task<Exercise?> GetByIdAsync(int id)
		{
			return await _context.Exercises.Include(e => e.sessions)
										   .FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task UpdateAsync(Exercise exercise)
		{
			_context.Exercises.Update(exercise);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var exercise = await _context.Exercises.FindAsync(id);
			if (exercise != null)
			{
				_context.Exercises.Remove(exercise);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<bool> ExistsAsync(int id)
		{
			return await _context.Exercises.AnyAsync(e => e.Id == id);
		}

		public void Add(Exercise exercise)
		{
			_context.Exercises.Add(exercise);
			_context.SaveChanges();
		}

		public List<Exercise> Get()
		{
			return _context.Exercises.Include(e => e.sessions).ToList();
		}

		public Exercise? GetById(int id)
		{
			return _context.Exercises.Include(e => e.sessions)
									 .FirstOrDefault(e => e.Id == id);
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
