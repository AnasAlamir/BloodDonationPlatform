using AutoMapper;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.Services.DTOs.DonationRequest;
namespace BloodDonationPlatform.API.Services.MappingProfiles
{
    public class DonationRequestProfile : Profile
    {
        public DonationRequestProfile()
        {
            // Mapping from CreateDonationRequestDTO to DonationRequest
            CreateMap<CreateDonationRequestDTO, DonationRequest>();

            // Mapping from DonationRequest to GetHospitalDonationRequestDTO
            CreateMap<DonationRequest, GetHospitalDonationRequestDTO>()
            .ForMember(dest => dest.BloodTypeName,
                opt => opt.MapFrom(src => src.BloodType != null ? src.BloodType.Name : null))
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => src.StatesRequest.ToString()));
        }
    }
}
