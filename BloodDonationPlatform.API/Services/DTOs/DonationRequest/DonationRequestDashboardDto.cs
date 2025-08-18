namespace BloodDonationPlatform.API.Services.DTOs.DonationRequest
{
    public class RequestDashboardDto
    {
        public string RequestCode { get; set; }
        public string BloodType { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
