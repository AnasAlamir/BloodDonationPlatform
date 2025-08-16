using BloodDonationPlatform.API.Services.DTOs.DonorDonationRequest;

namespace BloodDonationPlatform.API.Services.Interfaces
{
    public interface IDonorDonationRequestService
    {
        Task<IEnumerable<GetDonorDonationRequestDTO>> GetAllAsync();
        //Task<bool> DeleteAsync(int id);
        Task<CreateDonorDonationRequestDTO> CreateAsync(CreateDonorDonationRequestDTO dto);
        Task<bool> UpdateStatusAsync(UpdateDonorDonationRequestStatusDTO dto);
        Task<GetDonorDonationRequestDTO> GetByIdAsync(int id);
        Task AutoAssignEligibleDonorsAsync(int donationRequestId);
    }
}
