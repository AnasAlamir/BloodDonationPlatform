using BloodDonationPlatform.API.DataAccess.DataContext;
using BloodDonationPlatform.API.DataAccess.Interfaces;
using BloodDonationPlatform.API.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Threading.Tasks;
namespace BloodDonationPlatform.API.DataAccess.Repositories
{
    public class DbInitiaLizer : IDbInitializer
    {
        public DbInitiaLizer(BloodDonationDbContext context)
        {
            _Context = context;
        }

        private readonly BloodDonationDbContext _Context;

        public async Task InitializeAsync()
        {
            if (_Context.Database.GetPendingMigrations().Any())
            {
              await  _Context.Database.MigrateAsync();

            }

            if (!_Context.Hospitals.Any())
            {
                var FilePath = await File.ReadAllTextAsync( @"../BloodDonationPlatform.API\Seeding\Hospital.Json");
                var Hospitals = JsonSerializer.Deserialize<List<Hospital>>(FilePath);
                if (Hospitals != null && Hospitals.Any())
                {
                    await _Context.Hospitals.AddRangeAsync(Hospitals);
                    await _Context.SaveChangesAsync();
                }
            }
        }
    }
}
