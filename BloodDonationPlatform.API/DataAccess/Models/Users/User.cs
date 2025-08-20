namespace BloodDonationPlatform.API.DataAccess.Models.Users
{
    public class User : BaseEntity
    {
        //public string PhoneNumber { get; set; } // Email or Phone
        public string Password { get; set; }
        public UserRoles Role { get; set; }
        public Hospital Hospital { get; set; }
        public Donor Donor { get; set; }

    }
}
