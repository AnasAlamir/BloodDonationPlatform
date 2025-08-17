using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationPlatform.API.DataAccess.Repositories
{
    internal class AreaRepository : IAreaRepository
    {
        private readonly BloodDonationDbContext _context;
        private readonly DbSet<Area> _dbContext;

        public AreaRepository(BloodDonationDbContext context)
        {
            _context = context;
            _dbContext = _context.Set<Area>();
        }

        public async Task<IEnumerable<Area>> GetAllAsync()
        {
            return await _dbContext.Include(a => a.City).ToListAsync();
        }

        public async Task<Area?> GetByIdAsync(int id)
        {
            return await _dbContext
                .Include(a => a.City)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
