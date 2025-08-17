using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Models;

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
    }
}
