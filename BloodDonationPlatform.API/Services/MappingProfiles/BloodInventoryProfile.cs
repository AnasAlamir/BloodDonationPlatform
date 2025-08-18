using AutoMapper;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.Services.DTOs.Hospital;
using BloodDonationPlatform.API.Services.DTOs.Inventory;

public class BloodInventoryProfile : Profile
{
    public BloodInventoryProfile()
    {
        CreateMap<Inventory, GetBloodInventoryDTO>();
        CreateMap<CreateBloodInventoryDTO, Inventory>();
    }
}
