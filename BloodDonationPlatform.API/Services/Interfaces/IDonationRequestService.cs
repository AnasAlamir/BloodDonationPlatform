using Azure.Core;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.Services.DTOs.DonationRequest;

namespace BloodDonationPlatform.API.Services.Interfaces
{
    public interface IDonationRequestService
    {
        Task<IEnumerable<GetHospitalDonationRequestDTO>> GetAllActiveByHospitalIdAsync(int hospitalId);
        Task<IEnumerable<GetHospitalDonationRequestDTO>> GetAllCompletedByHospitalIdAsync(int hospitalId);
        Task<GetHospitalDonationRequestDTO> CreateAsync(CreateDonationRequestDTO dto);
        Task<int> GetOpenRequestsCountByHospitalIdAsync(int hospitalId);
        Task<int> GetPendingRequestsCountByHospitalIdAsync(int hospitalId);

        //Task<GetDonationRequestDTO?> GetBloodTypeByIdAsync(int id);
        //Task<bool> UpdateStatusAsync(UpdateDonationRequestStatusDTO dto);
    }
}