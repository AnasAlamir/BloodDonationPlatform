using BloodDonationPlatform.API.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonationPlatform.API.DataAccess.Configurations
{
    public class AreaConfigurations : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            // Seed data for blood types
            builder.HasData(
                new Area { Id = 1, CityId = 1, Name = "Maadi" },
                new Area { Id = 2, CityId = 1, Name = "Helwan" },
                new Area { Id = 3, CityId = 1, Name = "Ramses" },
                new Area { Id = 4, CityId = 2, Name = "El Omarania" },
                new Area { Id = 5, CityId = 3, Name = "Naga Elarab" }
            );
            builder.HasOne(d => d.City)
                .WithMany(bt => bt.Area)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(bt => bt.Hospitals)
                .WithOne(dr => dr.Area)
                .HasForeignKey(dr => dr.AreaId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(bt => bt.Donors)
                .WithOne(dr => dr.Area)
                .HasForeignKey(dr => dr.AreaId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

