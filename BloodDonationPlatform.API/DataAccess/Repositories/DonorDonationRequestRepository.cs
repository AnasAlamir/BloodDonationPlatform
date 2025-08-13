using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Models;

namespace BloodDonationPlatform.API.DataAccess.Repositories
{
    internal class DonorDonationRequestRepository : BaseRepository<DonorDonationRequest>, IDonorDonationRequestRepository
    {
        public DonorDonationRequestRepository(BloodDonationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
