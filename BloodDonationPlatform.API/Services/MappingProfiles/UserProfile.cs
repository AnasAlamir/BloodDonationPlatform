using AutoMapper;
using BloodDonationPlatform.API.DataAccess.Models.User;
using BloodDonationPlatform.API.Services.DTOs.User;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, AuthResultDto>()
            .ForMember(dest => dest.DisplayName, opt =>
                opt.MapFrom(src => src.Role == UserRoles.Hospital
                    ? src.Hospital.Name
                    : src.Role == UserRoles.Donor
                        ? src.Donor.Name
                        : "Unknown"));
    }
}
