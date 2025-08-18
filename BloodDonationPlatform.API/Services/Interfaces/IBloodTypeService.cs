using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.Services.DTOs.BloodType;

namespace BloodDonationPlatform.API.Services.Interfaces
{
    public interface IBloodTypeService
    {
        Task<BloodTypeDto?> GetBloodTypeByIdAsync(int id);
        Task<IEnumerable<BloodTypeDto>> GetAllBloodTypesAsync();
    }
}
