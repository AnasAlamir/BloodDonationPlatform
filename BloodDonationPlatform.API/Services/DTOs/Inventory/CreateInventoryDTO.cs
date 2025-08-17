namespace BloodDonationPlatform.API.Services.DTOs.Inventory
{
    public class CreateBloodInventoryDTO
    {
        public int BloodTypeId { get; set; }
        public int HospitalId { get; set; }
        public int Quantity { get; set; }

    }
}
