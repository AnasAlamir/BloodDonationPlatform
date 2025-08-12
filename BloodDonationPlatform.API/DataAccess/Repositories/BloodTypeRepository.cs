using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationPlatform.API.DataAccess.Repositories
{
    internal class BloodTypeRepository : IBloodTypeRepository
    {
        private readonly BloodDonationDbContext _context;
        private readonly DbSet<BloodType> _dbContext;

        public BloodTypeRepository(BloodDonationDbContext context)
        {
            _context = context;
            _dbContext = _context.Set<BloodType>();
        }

        public IEnumerable<BloodType> GetAll()
        {
            return _dbContext.AsEnumerable();
        }

        public BloodType? GetById(int id)
        {
            return _dbContext.Find(id);
        }
    }
}
