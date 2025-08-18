using BloodDonationPlatform.API.DataAccess.Contracts;
using BloodDonationPlatform.API.DataAccess.Models;

namespace BloodDonationPlatform.API.DataAccess.Interfaces
{
    public interface IInventoryRepository : IBaseRepository<Inventory>
    {
        Task InsertRangeAsync(IEnumerable<Inventory> inventories);
        Task<IEnumerable<Inventory>> GetAllByHospitalIdAsync(int id);
        Task<Inventory?> GetByIdAsync(int id);
    }
}
