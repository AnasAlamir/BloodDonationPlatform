using AutoMapper;
using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.Services.DTOs.Inventory;

public class BloodInventoryProfile : Profile
{
    public BloodInventoryProfile()
    {
        CreateMap<Inventory, GetBloodInventoryDTO>()
                .ForMember(dest => dest.BloodTypeName,
                    opt => opt.MapFrom(src => src.BloodType.Name))
                .ForMember(dest => dest.Status,
                    opt => opt.MapFrom(src => src.StatusInventory.ToString()));
        CreateMap<UpdateBloodInventoryDTO, Inventory>();
    }
}
