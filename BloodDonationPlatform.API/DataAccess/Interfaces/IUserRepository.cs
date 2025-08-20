using BloodDonationPlatform.API.DataAccess.Contracts;
using BloodDonationPlatform.API.DataAccess.Models.Users;

namespace BloodDonationPlatform.API.DataAccess.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByPhoneNumberAndPasswordAsync(string phoneNumber, string password);
    }
}
