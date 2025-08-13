using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Models;

namespace BloodDonationPlatform.API.DataAccess.Repositories
{
    internal class AdminRepository : BaseRepository<Admin>, IAdminRepository
    {
        public AdminRepository(BloodDonationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
