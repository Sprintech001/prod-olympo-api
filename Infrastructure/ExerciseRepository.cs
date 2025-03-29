using Microsoft.EntityFrameworkCore;
using olympo_webapi.Models;
using System.Linq.Expressions;

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
			return await _context.Exercises.Include(e => e.Sessions).ToListAsync();
		}

		public async Task<Exercise?> GetByIdAsync(int id)
		{
			return await _context.Exercises.Include(e => e.Sessions)
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

		public async Task<IEnumerable<Exercise>> GetAsync(Expression<Func<Exercise, bool>> predicate)
		{
			return await _context.Exercises.Where(predicate).ToListAsync();
		}

		public Task<IEnumerable<Exercise>> GetAsync(Func<Exercise, bool> predicate)
		{
			return Task.FromResult(_context.Exercises.Include(e => e.Sessions).AsEnumerable().Where(predicate));
		}
	}
}
