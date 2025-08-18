namespace BloodDonationPlatform.API.Services.DTOs.Inventory
{
    public class GetBloodInventoryDTO
    {
        public int Id { get; set; }
        public string BloodTypeName { get; set; }
        public int CurrentQuantity { get; set; } 
        public DateTime ExpirationDate { get; set; }
        public string Status { get; set; }
    }
    }

