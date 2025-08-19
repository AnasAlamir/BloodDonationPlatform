using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationPlatform.API.DataAccess.Repositories
{
    internal class DonorRepository : BaseRepository<Donor>, IDonorRepository
    {
        public DonorRepository(BloodDonationDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<Donor?> GetByIdAsync(int id)
        {
            return await _entity
                    .Include(r => r.BloodType)
                    .Include(r => r.Area)
                    .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
