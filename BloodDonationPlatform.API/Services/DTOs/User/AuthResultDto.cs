using BloodDonationPlatform.API.DataAccess.Models.Users;

namespace BloodDonationPlatform.API.Services.DTOs.User
{
    public class AuthResultDto
    {
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public UserRoles Role { get; set; }
        public int? HospitalId { get; set; }
        public int? DonorId { get; set; }
    }
}
