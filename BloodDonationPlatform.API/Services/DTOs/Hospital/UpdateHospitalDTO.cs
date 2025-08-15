namespace BloodDonationPlatform.API.Services.DTOs
{
    public class UpdateHospitalDTO
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int AreaId { get; set; }
        public int MinimumBloodQuantityByLiter { get; set; }
    }
}
