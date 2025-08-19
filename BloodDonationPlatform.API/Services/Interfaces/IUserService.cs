using BloodDonationPlatform.API.Services.DTOs.User;

namespace BloodDonationPlatform.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<AuthResultDto> LoginAsync(string identifier, string password);
    }
}
