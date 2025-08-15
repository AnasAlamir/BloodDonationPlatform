using AutoMapper;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.Services.DTOs.Hospital;

public class HospitalProfile : Profile
{
    public HospitalProfile()
    {
        CreateMap<CreateHospitalDTO, Hospital>();
        CreateMap<Hospital, GetHospitalDTO>();
        CreateMap<UpdateHospitalDTO, Hospital>().ReverseMap();
    }
}
