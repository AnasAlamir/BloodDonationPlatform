namespace BloodDonationPlatform.API.Services.DTOs.Inventory
{
    public class UpdateBloodInventoryDTO
    {
        public int CurrentQuantity { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}
