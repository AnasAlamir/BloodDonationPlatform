namespace BloodDonationPlatform.API.DataAccess.Models
{
    public class Hospital : BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int AreaId { get; set; }
        //adminId
        public int CreatedById { get; set; }
        public Area Area { get; set; }
        public ICollection<DonationRequest> DonationRequests { get; set; }
        public ICollection<Inventory> Inventory { get; set; }
    }
}