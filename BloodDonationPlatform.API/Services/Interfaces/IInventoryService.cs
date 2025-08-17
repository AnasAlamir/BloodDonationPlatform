using BloodDonationPlatform.API.Services.DTOs.Inventory;

namespace BloodDonationPlatform.API.Services.Interfaces
{
    public interface IInventoryService
    {
        Task<IEnumerable<GetBloodInventoryDTO>> GetAllAsync();
        Task<GetBloodInventoryDTO> AddInventoryAsync(CreateBloodInventoryDTO dto);
        Task UpdateInventoryStatusAsync();
    }
}
