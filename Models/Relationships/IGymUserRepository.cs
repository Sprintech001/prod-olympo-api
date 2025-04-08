using olympo_webapi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace olympo_webapi.Models
{
    public interface IGymUserRepository
    {
        Task<IEnumerable<GymUser>> GetAllAsync();
        Task<GymUser?> GetByIdAsync(int id);
        Task<IEnumerable<GymUser>> GetByUserIdAsync(int userId);
        Task<IEnumerable<GymUser>> GetByGymIdAsync(int gymId);
        Task AddAsync(GymUser gymUser);
        Task DeleteAsync(int userId, int gymId);
        Task<bool> ExistsAsync(int id);
    }
}
