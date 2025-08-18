namespace BloodDonationPlatform.API.Services.DTOs.Doner
{
    public class DonorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BloodType { get; set; }
        public string Area { get; set; }
        public int TotalPoints { get; set; }
    }
}
