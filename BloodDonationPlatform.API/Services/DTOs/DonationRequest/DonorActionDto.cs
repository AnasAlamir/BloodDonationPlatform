namespace BloodDonationPlatform.API.Services.DTOs.DonationRequest
{
    public class DonorActionDto
    {
        public int DonorId { get; set; }
        public int RequestId { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? ActionDate { get; set; } = DateTime.UtcNow;
    }
}
