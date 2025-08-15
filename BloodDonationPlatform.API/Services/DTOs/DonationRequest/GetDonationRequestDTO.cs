namespace BloodDonationPlatform.API.Services.DTOs.DonationRequest
{
    public class GetDonationRequestDTO
    {
        public int Id { get; set; }
        public string HospitalName { get; set; }
        public string BloodType { get; set; }
        public decimal NumOfLiter { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        // This property is not used in the creation process, but it can be useful for the response DTO.
        public int HospitalId { get; set; }
        // This property is not used in the creation process, but it can be useful for the response DTO.
        public int BloodTypeId { get; set; }
    }
}
