namespace BloodDonationPlatform.API.DataAccess.Models
{
    public class Area : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Donor> Donors { get; set; }
        // Navigation property for related donation requests
        public ICollection<Hospital> Hospitals { get; set; }

    }
}