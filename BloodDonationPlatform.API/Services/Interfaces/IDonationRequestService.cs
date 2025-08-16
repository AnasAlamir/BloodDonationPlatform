using Azure.Core;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.Services.DTOs.DonationRequest;

namespace BloodDonationPlatform.API.Services.Interfaces
{
    public interface IDonationRequestService
    {
        Task<IEnumerable<GetDonationRequestDTO>> GetAllAsync();
        Task<GetDonationRequestDTO> CreateAsync(CreateDonationRequestDTO dto);
        Task<GetDonationRequestDTO> GetByIdAsync(int id);
        Task<bool> UpdateStatusAsync(UpdateDonationRequestStatusDTO dto);
    }
}