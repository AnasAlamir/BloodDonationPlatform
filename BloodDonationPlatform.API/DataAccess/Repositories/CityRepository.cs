using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationPlatform.API.DataAccess.Repositories
{
    internal class CityRepository : ICityRepository
    {
        private readonly BloodDonationDbContext _context;
        private readonly DbSet<City> _dbContext;

        public CityRepository(BloodDonationDbContext context)
        {
            _context = context;
            _dbContext = _context.Set<City>();
        }

        public IEnumerable<City> GetAll()
        {
            return _dbContext.AsEnumerable();
        }

        public City? GetById(int id)
        {
            return _dbContext.Find(id);
        }
    }
}
