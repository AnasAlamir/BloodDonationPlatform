using BloodDonationPlatform.API.Services.Interfaces;
using BloodDonationPlatform.API.Services.MappingProfiles;
using BloodDonationPlatform.API.Services.Services;

namespace BloodDonationPlatform.API.Services
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            //services.AddScoped<IDonorService, DonorService>();
            services.AddScoped<IHospitalService, HospitalService>();
            services.AddAutoMapper(cfg => cfg.AddProfile<HospitalProfile>(), typeof(HospitalProfile));
            return services;
        }
    }
}
