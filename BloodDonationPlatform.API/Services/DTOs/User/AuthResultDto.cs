using BloodDonationPlatform.API.DataAccess.Models.User;

namespace BloodDonationPlatform.API.Services.DTOs.User
{
    public class AuthResultDto
    {
        public string Identifier { get; set; }
        public UserRoles Role { get; set; }
        public string DisplayName { get; set; }
    }
}
