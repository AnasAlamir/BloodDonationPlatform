using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationPlatform.API.DataAccess.Repositories
{
    internal class InventoryRepository : BaseRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(BloodDonationDbContext dbContext) : base(dbContext)
        {
        }
        public async Task InsertRangeAsync(IEnumerable<Inventory> inventories)
        {
            await _entity.AddRangeAsync(inventories);
        }
        public async Task<IEnumerable<Inventory>> GetAllByHospitalIdAsync(int id)
        {
            return await _entity
                .Include(i => i.BloodType)
                .Where(i => i.HospitalId == id)
                .ToListAsync();
        }
        public override async Task<Inventory?> GetByIdAsync(int id)
        {
            return await _entity
                    .Include(r => r.BloodType)
                    .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
