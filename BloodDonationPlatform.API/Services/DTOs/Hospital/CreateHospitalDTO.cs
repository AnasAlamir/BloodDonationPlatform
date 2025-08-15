namespace BloodDonationPlatform.API.Services.DTOs
{
    public class CreateHospitalDTO
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int AreaId { get; set; }
        public int MinimumBloodQuantityByLiter { get; set; }
        public int CreatedBy { get; set; }
    }
}
