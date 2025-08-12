using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Repositories;
using BloodDonationPlatform.API.DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationPlatform.API.DataAccess
{
    public static class DataAccessRegister
    {
        public static IServiceCollection RegisterDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDonorRepository, DonorRepository>();
            services.AddScoped<IBloodTypeRepository, BloodTypeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            // Add DbContext to dependency injection
            services.AddDbContext<BloodDonationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
