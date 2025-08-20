using AutoMapper;
using BloodDonationPlatform.API.DataAccess.Models.Users;
using BloodDonationPlatform.API.Services.DTOs.User;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, AuthResultDto>()
            .ForMember(dest => dest.UserId, opt =>
                opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.PhoneNumber, opt =>
                opt.MapFrom(src => src.Role == UserRoles.Hospital
                    ? src.Hospital.PhoneNumber
                    : src.Role == UserRoles.Donor
                        ? src.Donor.PhoneNumber
                        : null))
            .ForMember(dest => dest.Role, opt =>
                opt.MapFrom(src => src.Role));


        //CreateMap<User, AuthResultDto>()
        //    .ForMember(dest => dest.DisplayName, opt =>
        //        opt.MapFrom(src => src.Role == UserRoles.Hospital
        //            ? src.Hospital.Name
        //            : src.Role == UserRoles.Donor
        //                ? src.Donor.Name
        //                : "Unknown"));
    }
}
