using System.Collections.Generic;
using System.Threading.Tasks;

namespace olympo_webapi.Models
{
    public interface IExerciseDayRepository
    {
        Task<IEnumerable<ExerciseDay>> GetAllAsync();  
        Task<ExerciseDay> GetByIdAsync(int id);
        Task<IEnumerable<ExerciseDay>> GetByUserIdAsync(int userId);  
        Task AddAsync(ExerciseDay exerciseDay); 
        Task UpdateAsync(ExerciseDay exerciseDay);  
        Task DeleteAsync(int id);  
        Task<bool> ExistsAsync(int id); 
    }
}
