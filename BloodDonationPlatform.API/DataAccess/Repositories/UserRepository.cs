using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Models.User;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationPlatform.API.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly BloodDonationDbContext _context;
        public UserRepository(BloodDonationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        public async Task<User> GetByIdentifierAsync(string identifier, string password)
        {
            return await _context.Users
                       .Include(u => u.Hospital)
                       .Include(u => u.Donor)
                       .FirstOrDefaultAsync(u => u.Identifier == identifier && u.Password == password);
        }
    }
}
