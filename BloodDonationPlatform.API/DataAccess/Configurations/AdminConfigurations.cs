    namespace BloodDonationPlatform.API.DataAccess.Configurations;
using BloodDonationPlatform.API.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class AdminConfigurations : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.HasOne(a => a.City)
               .WithMany(c => c.Admin)
               .HasForeignKey(a => a.CityId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}

