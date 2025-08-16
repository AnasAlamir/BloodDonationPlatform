namespace BloodDonationPlatform.API.Services.DTOs.DonationRequest
{
    public class CreateDonationRequestDTO
    {
        public int HospitalId { get; set; }
        public int BloodTypeId { get; set; }
        public decimal NumOfLiter { get; set; }
        // This property is not used in the creation process, but it can be useful for the response DTO.
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // This property is not used in the creation process, but it can be useful for the response DTO.
        public string Status { get; set; } = "Pending";
    }
}
