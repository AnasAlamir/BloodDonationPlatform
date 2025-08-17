namespace BloodDonationPlatform.API.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BloodDonationPlatform.API.DataAccess.Models;

public class DonationRequestConfigurations : IEntityTypeConfiguration<DonationRequest>
{
    public void Configure(EntityTypeBuilder<DonationRequest> builder)
    {
        builder.HasOne(dr => dr.Hospital)
               .WithMany(h => h.DonationRequests)
               .HasForeignKey(dr => dr.HospitalId)
               .OnDelete(DeleteBehavior.Cascade)    ;

        builder.HasOne(dr => dr.BloodType)
               .WithMany(bt => bt.DonationRequests)
               .HasForeignKey(dr => dr.BloodTypeId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(dr => dr.DonorRequests)
               .WithOne(ddr => ddr.DonationRequest)
               .HasForeignKey(ddr => ddr.DonationRequestId) 
               .OnDelete(DeleteBehavior.Cascade);

        builder.Property(o => o.StatesRequest)
               .HasConversion(s => s.ToString(), s => Enum.Parse<StatesRequest>(s));
    }
}
