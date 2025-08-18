using BloodDonationPlatform.API.Services.DTOs.Inventory;

namespace BloodDonationPlatform.API.Services.Interfaces
{
    public interface IInventoryService 
    {
        Task<IEnumerable<GetBloodInventoryDTO>> GetAllInventoriesByHospitalIdAsync(int hospitalId);
        //Task<GetBloodInventoryDTO> AddInventoryAsync(CreateBloodInventoryDTO dto);
        Task<GetBloodInventoryDTO?> UpdateInventoryByIdAsync(int inventoryId, UpdateBloodInventoryDTO dto);
        //Task UpdateInventoryStatusAsync();
    }
}
