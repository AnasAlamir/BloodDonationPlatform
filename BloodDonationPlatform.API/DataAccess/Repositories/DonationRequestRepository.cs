using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Models;

namespace BloodDonationPlatform.API.DataAccess.Repositories
{
    internal class DonationRequestRepository : BaseRepository<DonationRequest>, IDonationRequestRepository
    {
        public DonationRequestRepository(BloodDonationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
