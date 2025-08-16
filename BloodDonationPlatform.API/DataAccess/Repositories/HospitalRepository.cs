using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationPlatform.API.DataAccess.Repositories
{
    internal class HospitalRepository : BaseRepository<Hospital>, IHospitalRepository
    {
        public HospitalRepository(BloodDonationDbContext dbContext) : base(dbContext){ }
        public async Task<Hospital?> GetByIdWithAreaInventoryIncludedAsync(int id)
        {
            return await _entity
                .Include(h => h.Area)
                .Include(h => h.Inventory)
                .FirstOrDefaultAsync(h => h.Id == id);
        }
        public override async Task<IEnumerable<Hospital>> GetAllAsync()
        {
            return await _entity
                .Include(h => h.Area)
                .Include(h => h.Inventory)
                .ToListAsync();
        }
    }
}
