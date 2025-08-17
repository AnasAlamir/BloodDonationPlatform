using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.Services.DTOs.Area;
using BloodDonationPlatform.API.Services.DTOs.BloodType;

namespace BloodDonationPlatform.API.Services.Interfaces
{
    public interface IAreaService
    {
        Task<AreaDto?> GetByIdAsync(int id);
        Task<IEnumerable<AreaDto>> GetAllAsync();
    }
}
