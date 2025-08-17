using AutoMapper;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.Services.DTOs.Area;
using BloodDonationPlatform.API.Services.DTOs.BloodType;
using BloodDonationPlatform.API.Services.DTOs.DonationRequest;
using BloodDonationPlatform.API.Services.DTOs.Hospital;
namespace BloodDonationPlatform.API.Services.MappingProfiles
{
    public class AreaProfile : Profile
    {
        public AreaProfile()
        {

            CreateMap<Area, AreaDto>()
                .ForMember(dest => dest.CityName,
                    opt => opt.MapFrom(src => src.City.Name));
        }
    }
}
