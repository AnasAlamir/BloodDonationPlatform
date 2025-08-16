using BloodDonationPlatform.API.Services.DTOs.DonorDonationRequest;

namespace BloodDonationPlatform.API.Services.Interfaces
{
    public interface IDonorDonationRequestService
    {
        Task<IEnumerable<GetDonorDonationRequestDTO>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
        Task<CreateDonorDonationRequestDTO> CreateAsync(CreateDonorDonationRequestDTO dto);
        Task AutoAssignEligibleDonorsAsync(int donationRequestId);
    }
}
