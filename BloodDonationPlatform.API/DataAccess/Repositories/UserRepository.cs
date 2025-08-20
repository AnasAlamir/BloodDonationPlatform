using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Migrations;
using BloodDonationPlatform.API.DataAccess.Models.User;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BloodDonationPlatform.API.DataAccess.Repositories
{
    internal class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BloodDonationDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<User> GetByIdentifierAsync(string identifier, string password)
        {
            IQueryable<User> query = _entity
        .Include(u => u.Hospital)
        .Include(u => u.Donor);

            if (identifier.Contains("@"))
            {
                return await query.FirstOrDefaultAsync(u =>
                    u.Identifier == identifier &&
                    u.Password == password &&
                    u.Hospital != null);
            }
            else
            {
                return await query.FirstOrDefaultAsync(u =>
                    u.Identifier == identifier &&
                    u.Password == password &&
                    u.Donor != null);
            }
        }
    }
}
