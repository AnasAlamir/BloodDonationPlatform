
namespace BloodDonationPlatform.API.Services.DTOs.DonationRequest
{ 
public class DonationRequestForDonorDto
{
    public int RequestId { get; set; }
    public string HospitalName { get; set; }
    public string Area { get; set; }
    public DateTime CreatedAt { get; set; }
    public int NumOfLiter { get; set; }
}
}