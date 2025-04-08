using Microsoft.EntityFrameworkCore;
using olympo_webapi.Infrastructure;
using olympo_webapi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olympo_webapi.Infrastructure
{
    public class GymUserRepository : IGymUserRepository
    {
        private readonly ConnectionContext _context;

        public GymUserRepository(ConnectionContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GymUser>> GetAllAsync()
        {
            return await _context.GymUsers
                .Include(gu => gu.Gym)
                .Include(gu => gu.User)
                .ToListAsync();
        }

        public async Task<GymUser?> GetByIdAsync(int id)
        {
            return await _context.GymUsers
                .Include(gu => gu.Gym)
                .Include(gu => gu.User)
                .FirstOrDefaultAsync(gu => gu.Id == id);
        }

        public async Task<IEnumerable<GymUser>> GetByUserIdAsync(int userId)
        {
            return await _context.GymUsers
                .Include(gu => gu.Gym)
                .Where(gu => gu.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<GymUser>> GetByGymIdAsync(int gymId)
        {
            return await _context.GymUsers
                .Include(gu => gu.User)
                .Where(gu => gu.GymId == gymId)
                .ToListAsync();
        }

        public async Task AddAsync(GymUser gymUser)
        {
            await _context.GymUsers.AddAsync(gymUser);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int userId, int gymId)
        {
            var entity = await _context.GymUsers
                .FirstOrDefaultAsync(x => x.UserId == userId && x.GymId == gymId);

            if (entity != null)
            {
                _context.GymUsers.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.GymUsers.AnyAsync(gu => gu.Id == id);
        }
    }
}
