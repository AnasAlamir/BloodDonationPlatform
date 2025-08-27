using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationPlatform.API.DataAccess.Repositories
{
    internal class DonorDonationRequestRepository : BaseRepository<DonorDonationRequest>, IDonorDonationRequestRepository
    {
        public DonorDonationRequestRepository(BloodDonationDbContext dbContext) : base(dbContext)
        {
        }
        public async Task InsertRangeAsync(IEnumerable<DonorDonationRequest> donorDonationRequests)
        {
            await _entity.AddRangeAsync(donorDonationRequests);
        }
        public async Task<IEnumerable<DonorDonationRequest>> GetAllByDonorIdAsync(int id)
        {
            return await _entity
                .Where(r => r.DonorId == id)               
                .Include(r => r.DonationRequest)                // include DonationRequest
                    .ThenInclude(dr => dr.Hospital)             // include Hospital
                        .ThenInclude(h => h.Area)               // include Area
                .Include(r => r.DonationRequest)                // include DonationRequest again
                    .ThenInclude(dr => dr.BloodType)            // include BloodType
                .ToListAsync();
        }
        public async Task<DonorDonationRequest?> GetDonorDonationRequestByIdAsync(int donorDonationRequestId)
        {
            return await _entity
                    .Include(dr => dr.DonationRequest)
                        .ThenInclude(dr => dr.Hospital)
                            .ThenInclude(h => h.Inventory)
                    .Include(r => r.Donor)
                    .FirstOrDefaultAsync(dr => dr.Id == donorDonationRequestId);
        }
    }
}
