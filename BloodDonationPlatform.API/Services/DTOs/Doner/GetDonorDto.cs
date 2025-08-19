namespace BloodDonationPlatform.API.Services.DTOs.Doner
{
    public class GetDonorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SSN { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BloodTypeName { get; set; }
        public string AreaName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public int TotalPoints { get; set; }
    }
}
