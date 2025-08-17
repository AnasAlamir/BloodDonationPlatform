using Azure.Core;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.Services.DTOs.DonationRequest;

namespace BloodDonationPlatform.API.Services.Interfaces
{
    public interface IDonationRequestService
    {
        Task<int> CreateDonationRequestAsync(CreateDonationRequestDTO dto);
        Task<bool> ApproveRequestAsync(DonorActionDto dto);
        Task<bool> RejectRequestAsync(DonorActionDto dto);

        Task<List<RequestDashboardDto>> GetDashboardRequestsAsync();
    }
}
