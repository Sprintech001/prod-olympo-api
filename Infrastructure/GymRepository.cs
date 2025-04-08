using Microsoft.EntityFrameworkCore;
using olympo_webapi.Infrastructure;
using olympo_webapi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace olympo_webapi.Infrastructure
{
    public class GymRepository : IGymRepository
    {
        private readonly ConnectionContext _context;

        public GymRepository(ConnectionContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Gym>> GetAllAsync()
        {
            return await _context.Gyms.ToListAsync();
        }

        public async Task<Gym?> GetByIdAsync(int id)
        {
            return await _context.Gyms.FindAsync(id);
        }

        public async Task AddAsync(Gym gym)
        {
            await _context.Gyms.AddAsync(gym);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Gym gym)
        {
            _context.Gyms.Update(gym);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var gym = await GetByIdAsync(id);
            if (gym != null)
            {
                _context.Gyms.Remove(gym);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Gyms.AnyAsync(g => g.Id == id);
        }
    }
}
