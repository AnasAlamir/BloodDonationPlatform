using BloodDonationPlatform.API.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
namespace BloodDonationPlatform.API.DataAccess.DataContext
{
    internal class BloodDonationDbContext : DbContext
    {
        public BloodDonationDbContext(DbContextOptions<BloodDonationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed blood types
            var bloodTypes = new List<BloodType>
            {
                new BloodType { Id = 1, Name = "A+" },
                new BloodType { Id = 2, Name = "A-" },
                new BloodType { Id = 3, Name = "B+" },
                new BloodType { Id = 4, Name = "B-" },
                new BloodType { Id = 5, Name = "AB+" },
                new BloodType { Id = 6, Name = "AB-" },
                new BloodType { Id = 7, Name = "O+" },
                new BloodType { Id = 8, Name = "O-" }
            };

            modelBuilder.Entity<BloodType>().HasData(bloodTypes);
        }

        public DbSet<Donor> Donors { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
    }
}
