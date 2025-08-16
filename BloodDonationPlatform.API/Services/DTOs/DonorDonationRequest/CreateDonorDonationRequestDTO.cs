namespace BloodDonationPlatform.API.Services.DTOs.DonorDonationRequest
{
    public class CreateDonorDonationRequestDTO
    {
            public int DonorId { get; set; }
            public int DonationRequestId { get; set; }
            public DateTime LastDateOfDonation { get; set; }
        }

    }

