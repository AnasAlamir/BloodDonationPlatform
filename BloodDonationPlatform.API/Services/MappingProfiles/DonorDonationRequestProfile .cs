using AutoMapper;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.Services.DTOs.DonorDonationRequest;
using BloodDonationPlatform.API.Services.DTOs.Hospital;

public class DonorDonationRequestProfile : Profile
{
    public DonorDonationRequestProfile()
    {
        //related to donor
        CreateMap<DonorDonationRequest, GetDonorDonationRequestDTO>()
         .ForMember(dest => dest.DonorDonationRequestId,
            opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.HospitalName,
            opt => opt.MapFrom(src => src.DonationRequest.Hospital.Name))
        .ForMember(dest => dest.BloodTypeName,
            opt => opt.MapFrom(src => src.DonationRequest.BloodType.Name))
        .ForMember(dest => dest.AreaName,
            opt => opt.MapFrom(src => src.DonationRequest.Hospital.Area.Name))
        .ForMember(dest => dest.DateOfCreation,
            opt => opt.MapFrom(src => src.DonationRequest.CreatedAt))
        .ForMember(dest => dest.DonorApprovalStatus,
            opt => opt.MapFrom(src => src.DonorApprovalStatus));
    }
}
