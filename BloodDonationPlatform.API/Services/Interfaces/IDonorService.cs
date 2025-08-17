using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.Services.DTOs.DonationRequest;
using BloodDonationPlatform.API.Services.DTOs.Doner;

namespace BloodDonationPlatform.API.Services.Interfaces
{
    public interface IDonorService
    {

        Task<DonorDto?> GetDonorByIdAsync(int donorId);
        Task<List<RequestDashboardDto>> GetRequestsForDonorAsync(int donorId);
    }
}

