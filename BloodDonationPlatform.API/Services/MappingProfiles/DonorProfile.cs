using AutoMapper;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.Services.DTOs.Doner;
using BloodDonationPlatform.API.Services.DTOs.DonorDonationRequest;
using BloodDonationPlatform.API.Services.DTOs.Hospital;

public class DonorProfile : Profile
{
    public DonorProfile()
    {
        CreateMap<DonorDto, Donor>();
    }
}
