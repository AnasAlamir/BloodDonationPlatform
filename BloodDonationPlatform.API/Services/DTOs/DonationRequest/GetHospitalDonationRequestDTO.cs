namespace BloodDonationPlatform.API.Services.DTOs.DonationRequest
{
    public class GetHospitalDonationRequestDTO
    {
        public int Id { get; set; }
        public string BloodTypeName { get; set; }
        public decimal NumOfLiter { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    //public class GetHospitalDonationRequestsDTO
    //{
    //    public IEnumerable<GetHospitalDonationRequestDTO> GetHospitalDonationRequestDTOs { get; set; }
    //    public int PendingRequestsCount { get; set; }
    //    public int CompletedRequestsCount { get; set; }
    //}
}
