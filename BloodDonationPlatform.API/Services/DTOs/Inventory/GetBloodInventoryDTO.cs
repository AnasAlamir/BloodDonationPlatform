namespace BloodDonationPlatform.API.Services.DTOs.Inventory
{
    public class GetBloodInventoryDTO
    {
        public int Id { get; set; }
        public string BloodType { get; set; }
        public string HospitalName { get; set; } = string.Empty;
        public int CurrentQuantity { get; set; } 
        public DateTime ExpirationDate { get; set; }
        public string Status { get; set; }
    }
    }

