namespace BloodDonationPlatform.API.Services.DTOs.DonorDonationRequest
{
    public class GetDonorDonationRequestDTO
    {
        public int DonorDonationRequestId { get; set; }
        public string HospitalName { get; set; }
        public string BloodTypeName { get; set; }
        public string AreaName { get; set; }
        public DateTime DateOfCreation { get; set; }
        public bool? DonorApprovalStatus { get; set; }
        //public int Id { get; set; }
        //public int DonorId { get; set; }
        //public string DonorName { get; set; }
        //public string DonorBloodType { get; set; }
        //public DateTime RequestDate { get; set; }
        //public int DonationRequestId { get; set; }
        //public string RequestStatus { get; set; }
        //public DateTime LastDateOfDonation { get; set; }
    }
}
