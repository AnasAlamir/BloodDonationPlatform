using AutoMapper;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.Services.DTOs.BloodType;
using BloodDonationPlatform.API.Services.DTOs.DonationRequest;
using BloodDonationPlatform.API.Services.DTOs.Hospital;
namespace BloodDonationPlatform.API.Services.MappingProfiles
{
    public class BloodTypeProfile : Profile
    {
        public BloodTypeProfile()
        {

            CreateMap<BloodType, BloodTypeDto>();
        }
    }
}
