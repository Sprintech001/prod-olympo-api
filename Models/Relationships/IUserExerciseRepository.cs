using olympo_webapi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace olympo_webapi.Models
{
    public interface IUserExerciseRepository
    {
        Task<IEnumerable<UserExercise>> GetAllAsync();
        Task<UserExercise?> GetByIdAsync(int id);
        Task<IEnumerable<UserExercise>> GetByUserIdAsync(int userId);
        Task<IEnumerable<UserExercise>> GetByExerciseIdAsync(int exerciseId);
        Task AddAsync(UserExercise userExercise);
        Task DeleteAsync(int userId, int exerciseId);
        Task<bool> ExistsAsync(int id);
        Task<IEnumerable<Session>> GetSessionsByUserAndExerciseAsync(int userId, int exerciseId);
    }
}
