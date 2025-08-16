using Azure.Core;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.Services.DTOs.DonationRequest;

namespace BloodDonationPlatform.API.Services.Interfaces
{
    public interface IDonationRequestService
    {
        Task<IEnumerable<GetHospitalDonationRequestDTO>> GetAllActiveAsync();
        Task<IEnumerable<GetHospitalDonationRequestDTO>> GetAllCompletedAsync();
        Task<GetHospitalDonationRequestDTO> CreateAsync(CreateDonationRequestDTO dto);
        Task<int> GetOpenRequestsCountAsync();
        Task<int> GetPendingRequestsCountAsync();
        //Task<GetDonationRequestDTO?> GetByIdAsync(int id);
        //Task<bool> UpdateStatusAsync(UpdateDonationRequestStatusDTO dto);
    }
}