namespace BloodDonationPlatform.API.DataAccess.Models
{
    public class DonationRequest : BaseEntity
    {

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int HospitalId { get; set; }
        public int BloodTypeId { get; set; }
        public int NumOfLiter { get; set; }
        public StatesRequest StatesRequest { get; set; } = StatesRequest.Pending;


        public Hospital Hospital { get; set; }
        public BloodType BloodType { get; set; }
        public ICollection<DonorDonationRequest> DonorRequests { get; set; }
      
    }
}
