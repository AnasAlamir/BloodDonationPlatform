namespace BloodDonationPlatform.API.DataAccess.Models
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Area> Area { get; set; }
        public ICollection<Admin> Admin { get; set; }
    }
}