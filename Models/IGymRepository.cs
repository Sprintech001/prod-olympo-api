using olympo_webapi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace olympo_webapi.Infrastructure
{
    public interface IGymRepository
    {
        Task<IEnumerable<Gym>> GetAllAsync();
        Task<Gym?> GetByIdAsync(int id);
        Task AddAsync(Gym gym);
        Task UpdateAsync(Gym gym);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
