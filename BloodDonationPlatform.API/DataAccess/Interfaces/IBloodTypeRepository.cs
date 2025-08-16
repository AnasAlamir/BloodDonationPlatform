using BloodDonationPlatform.API.DataAccess.Models;

namespace BloodDonationPlatform.API.DataAccess.Interfaces
{
    public interface IBloodTypeRepository
    {
        Task<BloodType?> GetByIdAsync(int id);
        Task<IEnumerable<BloodType>> GetAllAsync();
    }
}
