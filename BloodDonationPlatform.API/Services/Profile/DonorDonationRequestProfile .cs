using AutoMapper;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.Services.DTOs.DonorDonationRequest;
using BloodDonationPlatform.API.Services.DTOs.Hospital;

public class DonorDonationRequestProfile : Profile
{
    public DonorDonationRequestProfile()
    {
        CreateMap<CreateDonorDonationRequestDTO, DonorDonationRequest>();
        CreateMap<DonorDonationRequest, GetDonorDonationRequestDTO>();
    }
}
