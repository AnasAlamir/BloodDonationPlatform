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

            //// UpdateHospitalDTO → Hospital
            //CreateMap<UpdateHospitalDTO, Hospital>()
            //.ForMember(dest => dest.Inventory,
            //    opt => opt.MapFrom((src, dest) =>
            //    {
            //        // Update existing inventories if already present
            //        if (dest.Inventory != null && dest.Inventory.Any())
            //        {
            //            foreach (var inv in dest.Inventory)
            //            {
            //                inv.MinimunQuantity = src.MinimumBloodQuantityByLiter;
            //            }
            //            return dest.Inventory;
            //        }

            //        // If no inventories, just return null
            //        return dest.Inventory;
            //    }));
            // UpdateHospitalDTO → Hospital
            CreateMap<UpdateHospitalDTO, Hospital>()
                // Do not let AutoMapper reassign/clear the collection
                .ForMember(d => d.Inventory, opt => opt.Ignore())
                // Safely mutate the tracked children
                .AfterMap((src, dest) =>
                {
                    if (dest.Inventory != null)
                    {
                        foreach (var inv in dest.Inventory)
                        {
                            inv.MinimunQuantity = src.MinimumBloodQuantityByLiter;
                            // If you ALSO want to sync current quantity, uncomment:
                            // inv.CurrentQuantity = src.MinimumBloodQuantityByLiter;
                        }
                    }

                    // AreaId is a scalar, mapping already handles it;
                    // If you had logic here, you could set dest.AreaId = src.AreaId;
                });

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


