using Azure.Core;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.Services.DTOs.DonationRequest;
using BloodDonationPlatform.API.Services.DTOs.DonorDonationRequest;

namespace BloodDonationPlatform.API.Services.Interfaces
{
    public interface IDonationRequestService
    {
        Task<GetHospitalDonationRequestDTO> CreateDonationRequestAsync(CreateHospitalDonationRequestDTO dto);
        Task<IEnumerable<GetHospitalDonationRequestDTO>> GetAllActiveRequestsByHospitalIdAsync(int hospitalId);
        Task<IEnumerable<GetHospitalDonationRequestDTO>> GetAllCompletedRequestsByHospitalIdAsync(int hospitalId);
        Task<int> GetOpenRequestsCountByHospitalIdAsync(int hospitalId);
        Task<int> GetCompletedRequestsCountByHospitalIdAsync(int hospitalId);
        Task<IEnumerable<GetDonorDonationRequestDTO>> GetAllRequestsByDonorIdAsync(int donorId);
        Task<bool> ApproveDonationRequestByDonorDonationRequestIdAsync(int donorDonationRequestId);
        Task<bool> RejectDonationRequestByDonorDonationRequestIdAsync(int donorDonationRequestId);

        //Task<List<RequestDashboardDto>> GetDashboardRequestsAsync();
        //////////Task<GetDonationRequestDTO?> GetBloodTypeByIdAsync(int id);
        //////////Task<bool> UpdateStatusAsync(UpdateDonationRequestStatusDTO dto);
    }
}

