namespace BloodDonationPlatform.API.DataAccess.Models.User
{
    public class User : BaseEntity
    {
        public string Identifier { get; set; } // Email or Phone
        public string? Password { get; set; }
        public UserRoles Role { get; set; }
        public int? HospitalId { get; set; }
        public Hospital Hospital { get; set; }

        public int? DonorId { get; set; }
        public Donor Donor { get; set; }

    }
}
