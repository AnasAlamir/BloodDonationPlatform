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
            // Add CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()       // or .WithOrigins("https://yourflutterapp.com")
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            // Add services to the container.
            builder.Services.RegisterDataAccess(builder.Configuration);
            builder.Services.RegisterServices();

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            var app = builder.Build();

            app.UseCors("AllowAll");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
