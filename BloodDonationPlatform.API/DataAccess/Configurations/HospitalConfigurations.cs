using BloodDonationPlatform.API;
using BloodDonationPlatform.API.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonationPlatform.API.DataAccess.Configurations
{
    public class HospitalConfigurations : IEntityTypeConfiguration<Hospital>
    {
        public void Configure(EntityTypeBuilder<Hospital> builder)
        {
            builder.Property(d => d.PhoneNumber)
            .HasMaxLength(12);

            builder.HasIndex(h => h.PhoneNumber)
           .IsUnique();

            builder.HasOne(h => h.Area)
                   .WithMany(a => a.Hospitals)
                   .HasForeignKey(h => h.AreaId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(h => h.DonationRequests)
                   .WithOne(dr => dr.Hospital)
                   .HasForeignKey(dr => dr.HospitalId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(h => h.Inventory)
                   .WithOne(id => id.Hospital)
                   .HasForeignKey(id => id.HospitalId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(h => h.User)
                   .WithOne(u => u.Hospital)
                   .HasForeignKey<Hospital>(h => h.UserId)
                   .OnDelete(DeleteBehavior.Restrict); // prevent SQL cascade cycle
        }
    }
}
