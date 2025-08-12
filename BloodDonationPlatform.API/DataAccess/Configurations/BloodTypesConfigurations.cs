using BloodDonationPlatform.API.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonationPlatform.API.DataAccess.Configurations
{
    public class BloodTypesConfigurations : IEntityTypeConfiguration<BloodType>
    {
        public void Configure(EntityTypeBuilder<BloodType> builder)
        {
            // Assuming blood type names are short (e.g., "A+", "O-", etc.)
            // Seed data for blood types
            builder.HasData(
                new BloodType {Id =1, Name = "A+" },
                new BloodType {Id=2, Name = "A-" },
                new BloodType {Id = 3, Name = "B+" },
                new BloodType {Id = 4, Name = "B-" },
                new BloodType {Id = 5, Name = "AB+" },
                new BloodType {Id=6, Name = "AB-" },
                new BloodType {Id=7, Name = "O+" },
                new BloodType {Id=8, Name = "O-" }
            );

            builder.HasMany(bt => bt.Donors)
          .WithOne(d => d.BloodType)
          .HasForeignKey(d => d.BloodTypeId)
          .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(bt => bt.DonationRequests)
                   .WithOne(dr => dr.BloodType)
                   .HasForeignKey(dr => dr.BloodTypeId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(bt => bt.Inventory)
                   .WithOne(id => id.BloodType)
                   .HasForeignKey(id => id.BloodTypeId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

