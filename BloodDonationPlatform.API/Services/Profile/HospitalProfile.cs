namespace BloodDonationPlatform.API.Services.Profile;
    using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.Services.DTOs;
using System.Collections.Generic;
using AutoMapper;


public class HospitalProfile : Profile
{
  public HospitalProfile()
  {
        CreateMap<Hospital, HospitalDTO>();
        CreateMap<HospitalDTO, Hospital>();
    }
}


