namespace BloodDonationPlatform.API.DataAccess.Models
{
    public class Inventory : BaseEntity
    {
        public int BloodTypeId { get; set; }
        public int HospitalId { get; set; }
        public int CurrentQuantity { get; set; }
        public int MinimunQuantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public StatusInventory StatusInventory { get; set; }
        public BloodType BloodType { get; set; }
        public Hospital Hospital { get; set; }
    }
}
