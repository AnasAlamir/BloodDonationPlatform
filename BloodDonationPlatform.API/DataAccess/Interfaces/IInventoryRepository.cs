using BloodDonationPlatform.API.DataAccess.Contracts;
using BloodDonationPlatform.API.DataAccess.Models;

namespace BloodDonationPlatform.API.DataAccess.Interfaces
{
    public interface IInventoryRepository : IBaseRepository<Inventory>
    {
        public Task InsertRangeAsync(IEnumerable<Inventory> inventories);
    }
}
