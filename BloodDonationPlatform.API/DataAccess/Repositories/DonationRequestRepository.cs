using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationPlatform.API.DataAccess.Repositories
{
    internal class DonationRequestRepository : BaseRepository<DonationRequest>, IDonationRequestRepository
    {
        public DonationRequestRepository(BloodDonationDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<IEnumerable<DonationRequest>> GetAllAsync()
        {
            return await _entity
                    .Include(r => r.BloodType)
                    .ToListAsync();
        }
        public override async Task<DonationRequest?> GetByIdAsync(int id)
        {
            return await _entity
                    .Include(r => r.BloodType)
                    .FirstOrDefaultAsync(r => r.Id == id); ;
        }

        //public async Task<int> CountAsync(Predicate<DonationRequest> predicate)
        //{
        //    return await _entity.CountAsync();
        //}
    }
}
