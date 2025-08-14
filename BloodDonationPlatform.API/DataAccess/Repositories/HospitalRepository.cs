using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Models;

namespace BloodDonationPlatform.API.DataAccess.Repositories
{
    internal class HospitalRepository : BaseRepository<Hospital>, IHospitalRepository 
    {
        public HospitalRepository(BloodDonationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
