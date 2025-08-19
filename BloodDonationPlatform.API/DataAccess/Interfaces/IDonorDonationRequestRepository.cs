using BloodDonationPlatform.API.DataAccess.Contracts;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.DataAccess.Repositories;

namespace BloodDonationPlatform.API.DataAccess.Interfaces
{
    public interface IDonorDonationRequestRepository : IBaseRepository<DonorDonationRequest>
    {
        Task InsertRangeAsync(IEnumerable<DonorDonationRequest> donorDonationRequests);
        Task<IEnumerable<DonorDonationRequest>> GetAllByDonorIdAsync(int id);
        Task<DonorDonationRequest?> GetDonorDonationRequestByIdAsync(int donorDonationRequestId);
    }
}
