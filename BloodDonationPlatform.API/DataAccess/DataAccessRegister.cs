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
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IDonationRequestRepository, DonationRequestRepository>();
            services.AddScoped<IHospitalRepository, HospitalRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IDonorDonationRequestRepository, DonorDonationRequestRepository>();
            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            services.AddScoped<IDbInitializer, DbInitiaLizer>();

            // Add DbContext to dependency injection
            services.AddDbContext<BloodDonationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
