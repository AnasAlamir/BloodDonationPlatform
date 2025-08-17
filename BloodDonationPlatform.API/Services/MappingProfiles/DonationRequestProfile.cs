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
    //        CreateMap<DonationRequest, DonationRequestDashboardDto>()
    //        .ForMember(dest => dest.BloodTypeName,
    //            opt => opt.MapFrom(src => src.BloodType != null ? src.BloodType.Name : null))
    //        .ForMember(dest => dest.Status,
    //            opt => opt.MapFrom(src => src.StatesRequest.ToString()));
    //        CreateMap<DonorActionDto, DonorDonationRequest>()
    //.ForMember(dest => dest.LastDateOfDonation, opt => opt.MapFrom(src => DateTime.UtcNow))
    //.ForMember(dest => dest.DonorApprovalStatus, opt => opt.MapFrom(src => true));
    //        CreateMap<CreateDonationRequestDTO, DonationRequest>();

            CreateMap<DonationRequest, RequestDashboardDto>()
                .ForMember(dest => dest.RequestCode, opt => opt.MapFrom(src => $"REQ-{src.CreatedAt.Year}-{src.Id:D3}"))
                .ForMember(dest => dest.BloodType, opt => opt.MapFrom(src => src.BloodType))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.NumOfLiter))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.StatesRequest.ToString()))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));


        }
    }
}
