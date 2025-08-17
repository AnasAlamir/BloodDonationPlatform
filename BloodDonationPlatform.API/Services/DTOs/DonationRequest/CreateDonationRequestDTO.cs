namespace BloodDonationPlatform.API.Services.DTOs.DonationRequest
{
    public class CreateDonationRequestDTO
    {
        public int HospitalId { get; set; }
        public int BloodTypeId { get; set; }
        public int NumOfLiter { get; set; }
    }
}
