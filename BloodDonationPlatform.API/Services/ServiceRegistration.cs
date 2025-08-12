using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Repositories;
using BloodDonationPlatform.API.DataAccess.UnitOfWork;
using BloodDonationPlatform.API.Services.Interfaces;
using BloodDonationPlatform.API.Services.Services;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationPlatform.API.Services
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IDonorService, DonorService>();
            return services;
        }
    }
}
