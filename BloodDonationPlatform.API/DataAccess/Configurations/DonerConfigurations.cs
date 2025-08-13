namespace BloodDonationPlatform.API.DataAccess.Configurations;
using BloodDonationPlatform.API.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class DonerConfigurations : IEntityTypeConfiguration<Donor>
{
    public void Configure(EntityTypeBuilder<Donor> builder) // Fixed method name
    {

        builder.HasOne(d => d.BloodType)
         .WithMany(bt => bt.Donors)
         .HasForeignKey(d => d.BloodTypeId)
         .OnDelete(DeleteBehavior.Restrict); 


        builder.HasOne(d => d.Area)
        .WithMany(a => a.Donors)
        .HasForeignKey(d => d.AreaId)
        .OnDelete(DeleteBehavior.Restrict); 
        builder.Property(D => D.SSN)
            .HasMaxLength(14);

        builder.Property(d => d.PhoneNumber)
            .HasMaxLength(12);
           
        builder.HasMany(d => d.DonationRequests)
               .WithOne(ddr => ddr.Donor)
               .HasForeignKey(ddr => ddr.DonorId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}

