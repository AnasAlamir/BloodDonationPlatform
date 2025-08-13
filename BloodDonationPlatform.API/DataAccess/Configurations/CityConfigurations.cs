using BloodDonationPlatform.API.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonationPlatform.API.DataAccess.Configurations
{
    public class CityConfigurations : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            // Seed data for blood types
            builder.HasData(
                new City { Id = 1, Name = "Cairo" },
                new City { Id = 2, Name = "Giza" },
                new City { Id = 3, Name = "Alexanderia" },
                new City { Id = 4, Name = "Aswan" }             
            );

            builder.HasMany(c => c.Area)
                   .WithOne(d => d.City)
                   .HasForeignKey(d => d.CityId)
                   .OnDelete(DeleteBehavior.NoAction);


            builder.HasMany(bt => bt.Admin)
                   .WithOne(dr => dr.City)
                   .HasForeignKey(dr => dr.CityId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

