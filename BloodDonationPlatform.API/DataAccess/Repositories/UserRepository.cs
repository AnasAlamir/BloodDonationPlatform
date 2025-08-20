using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationPlatform.API.DataAccess.Repositories
{
    internal class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BloodDonationDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<User?> GetByPhoneNumberAndPasswordAsync(string phoneNumber, string password)
        {
            return await _entity
                       .Include(u => u.Hospital)
                       .Include(u => u.Donor)
                       .FirstOrDefaultAsync(u =>
                     u.Password == password &&
                     (
                         (u.Hospital != null && u.Hospital.PhoneNumber == phoneNumber) ||
                         (u.Donor != null && u.Donor.PhoneNumber == phoneNumber)
                     ));
        }
    }
}
