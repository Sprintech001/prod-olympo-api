using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using olympo_webapi.Infrastructure;
using olympo_webapi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace olympo_webapi.Models
{
    public class ExerciseDayRepository : IExerciseDayRepository
    {
        private readonly ConnectionContext _context;

        public ExerciseDayRepository(ConnectionContext context)
        {
            _context = context;
        }

        // Retorna todos os ExerciseDays sem incluir as entidades relacionadas
        public async Task<IEnumerable<ExerciseDay>> GetAllAsync()
        {
            return await _context.ExerciseDays
                .ToListAsync(); // Não há necessidade de incluir as entidades relacionadas
        }

        // Retorna um ExerciseDay específico sem incluir as entidades relacionadas
        public async Task<ExerciseDay> GetByIdAsync(int id)
        {
            return await _context.ExerciseDays
                .FirstOrDefaultAsync(ed => ed.Id == id); // Não há necessidade de incluir as entidades relacionadas
        }

        // Retorna todos os ExerciseDays para um usuário específico, sem incluir as entidades relacionadas
        public async Task<IEnumerable<ExerciseDay>> GetByUserIdAsync(int userId)
        {
            return await _context.ExerciseDays
                .Where(ed => ed.UserId == userId)  
                .ToListAsync(); // Não há necessidade de incluir as entidades relacionadas
        }

        // Adiciona um novo ExerciseDay
        public async Task AddAsync(ExerciseDay exerciseDay)
        {
            _context.ExerciseDays.Add(exerciseDay);  
            await _context.SaveChangesAsync();       
        }

        // Atualiza um ExerciseDay existente
        public async Task UpdateAsync(ExerciseDay exerciseDay)
        {
            _context.Entry(exerciseDay).State = EntityState.Modified; 
            await _context.SaveChangesAsync();  
        }

        // Exclui um ExerciseDay pelo ID
        public async Task DeleteAsync(int id)
        {
            var exerciseDay = await _context.ExerciseDays.FindAsync(id); 
            if (exerciseDay != null)
            {
                _context.ExerciseDays.Remove(exerciseDay); 
                await _context.SaveChangesAsync(); 
            }
        }

        // Verifica se o ExerciseDay existe
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.ExerciseDays.AnyAsync(ed => ed.Id == id); 
        }
    }
}
