using AutoMapper;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.Services.DTOs.Hospital;

namespace BloodDonationPlatform.API.Services.MappingProfiles
{ 
    public class HospitalProfile : Profile
    {
      public HospitalProfile()
      {
            // CreateHospitalDTO → Hospital
            CreateMap<CreateHospitalDTO, Hospital>();

            // UpdateHospitalDTO → Hospital
            CreateMap<UpdateHospitalDTO, Hospital>();

            // Hospital → GetHospitalDTO
            CreateMap<Hospital, GetHospitalDTO>()
                .ForMember(dest => dest.AreaName,
                    opt => opt.MapFrom(src => src.Area.Name))
                .ForMember(dest => dest.MinimumBloodQuantityByLiter,
                    opt => opt.MapFrom(src =>
                        src.Inventory.FirstOrDefault() != null
                            ? src.Inventory.First().MinimunQuantity
                            : 0));
        }
    }
}


