namespace BloodDonationPlatform.API.DataAccess.Models
{
    public class Donor : BaseEntity   
    {
        public string Name { get; set; }
        public int SSN { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int BloodTypeId { get; set; }
        public int AreaId { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public int TotalPoints { get; set; }

        public BloodType BloodType { get; set; }
        public Area Area { get; set; }
        public ICollection<DonorDonationRequest> DonationRequests { get; set; }
    }
}
