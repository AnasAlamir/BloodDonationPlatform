using BloodDonationPlatform.API.DataAccess;
using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Repositories;
using BloodDonationPlatform.API.Services;
using BloodDonationPlatform.API.Services.Interfaces;
using BloodDonationPlatform.API.Services.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;



namespace BloodDonationPlatform.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.RegisterDataAccess(builder.Configuration);
            builder.Services.RegisterServices();

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            //builder.Services.AddDbContext<BloodDonationDbContext>(options =>
            //{
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            //});


            //builder.Services.AddScoped<IHospitalService,HospitalService>();

            #region Database Initialization
            //builder.Services.AddAutoMapper(E => E.AddProfile(new HospitalProfile()));
            //builder.Services.AddScoped<IServicesManager, ServicesManager>();
            //builder.Services.AddScoped<IDbInitializer, DbInitiaLizer>();
            #endregion
            var app = builder.Build();
            //using  var scope = app.Services.CreateScope();
            //var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            //await dbInitializer.InitializeAsync();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
