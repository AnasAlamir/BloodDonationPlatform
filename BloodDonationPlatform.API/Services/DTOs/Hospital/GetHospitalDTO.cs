using BloodDonationPlatform.API.DataAccess.Models;

namespace BloodDonationPlatform.API.Services.DTOs
{
    public class GetHospitalDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string AreaName { get; set; }
        public int MinimumBloodQuantityByLiter { get; set; }
    }
}
