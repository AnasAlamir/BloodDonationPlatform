using AutoMapper;
using BloodDonationPlatform.API.Services.Interfaces;
using BloodDonationPlatform.API.Services.MappingProfiles;
using BloodDonationPlatform.API.Services.Services;

namespace BloodDonationPlatform.API.Services
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IDonorService, DonorService>();
            services.AddScoped<IBloodTypeService, BloodTypeService>();
            services.AddScoped<IHospitalService, HospitalService>();
            services.AddScoped<IAreaService, AreaService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IDonationRequestService, DonationRequestService>();

            services.AddScoped<IUserService, UserService>();

            services.AddAutoMapper(cfg => cfg.AddProfile<HospitalProfile>(), typeof(HospitalProfile));
            services.AddAutoMapper(cfg => cfg.AddProfile<DonationRequestProfile>(), typeof(DonationRequestProfile));
            services.AddAutoMapper(cfg => cfg.AddProfile<DonorDonationRequestProfile>(), typeof(DonorDonationRequestProfile));
            services.AddAutoMapper(cfg => cfg.AddProfile<BloodTypeProfile>(), typeof(BloodTypeProfile));
            services.AddAutoMapper(cfg => cfg.AddProfile<AreaProfile>(), typeof(AreaProfile));
            services.AddAutoMapper(cfg => cfg.AddProfile<DonorProfile>(), typeof(DonorProfile));
            services.AddAutoMapper(cfg => cfg.AddProfile<UserProfile>(), typeof(UserProfile));
            return services;
        }
    }
}
