using BloodDonationPlatform.API.DataAccess.Contracts;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.DataAccess.Repositories;

namespace BloodDonationPlatform.API.DataAccess.Interfaces
{
    public interface IHospitalRepository : IBaseRepository<Hospital>
    {
        Task<Hospital?> GetByIdWithAreaInventoryIncludedAsync(int id);
    }
}
