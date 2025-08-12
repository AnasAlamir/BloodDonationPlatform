namespace BloodDonationPlatform.API.DataAccess.Models
{
    public class Admin : BaseEntity
    {
        public string Name { get; set; }
        public int CityId { get; set; }
        public string PhoneNumber { get; set; }
        public City City { get; set; }
    }
}
