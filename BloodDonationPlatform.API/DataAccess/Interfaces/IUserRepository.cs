using BloodDonationPlatform.API.DataAccess.Models.User;

namespace BloodDonationPlatform.API.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdentifierAsync(string identifier, string password);
    }
}
