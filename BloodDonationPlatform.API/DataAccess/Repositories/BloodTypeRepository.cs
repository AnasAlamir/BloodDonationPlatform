using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BloodDonationPlatform.API.DataAccess.Repositories
{
    internal class BloodTypeRepository : IBloodTypeRepository
    {
        private readonly BloodDonationDbContext _context;
        private readonly DbSet<BloodType> _dbContext;

        public BloodTypeRepository(BloodDonationDbContext context)
        {
            _context = context;
            _dbContext = _context.Set<BloodType>();
        }

        public async Task<IEnumerable<BloodType>> GetAllAsync()
        {
            return await _dbContext.ToListAsync();
        }

        public async Task<BloodType?> GetByIdAsync(int id)
        {
            return await _dbContext.FindAsync(id);
        }

    }
}
