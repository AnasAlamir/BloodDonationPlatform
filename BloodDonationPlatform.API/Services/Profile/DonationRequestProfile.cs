using AutoMapper;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.Services.DTOs.Hospital;

public class DonationRequestProfile : Profile
{
    public DonationRequestProfile()
    {
        CreateMap<CreateHospitalDTO, DonationRequest>();
        CreateMap<UpdateHospitalDTO, DonationRequest>().ReverseMap();
    }
}
