namespace BloodDonationPlatform.API.DataAccess.Models
{
    public class DonorDonationRequest : BaseEntity
    {

        public int Id { get; set; }

        public int DonorId { get; set; }
        public Donor Donor { get; set; }

        public int DonationRequestId { get; set; }
        public bool? DonorApprovalStatus { get; set; }
        public DonationRequest DonationRequest { get; set; }

        public DateTime LastDateOfDonation { get; set; }
    }
}
