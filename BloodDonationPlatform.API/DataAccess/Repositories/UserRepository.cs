using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Models.User;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationPlatform.API.DataAccess.Repositories
{
    internal class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BloodDonationDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<User> GetByIdentifierAsync(string identifier, string password)
        {
            return await _entity
                       .Include(u => u.Hospital)
                       .Include(u => u.Donor)
                       .FirstOrDefaultAsync(u => u.Identifier == identifier && u.Password == password);
        }
    }
}
