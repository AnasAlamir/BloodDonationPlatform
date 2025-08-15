namespace BloodDonationPlatform.API.Services.DTOs.DonorDonationRequest
{
    public class UpdateDonorDonationRequestStatusDTO
    {
        public int DonorId { get; set; }
        public int DonationRequestId { get; set; }
        public bool DonorApprovalStatus { get; set; }
        public DateTime LastDateOfDonation { get; set; }
    }
}
