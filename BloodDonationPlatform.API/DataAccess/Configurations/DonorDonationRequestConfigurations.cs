namespace BloodDonationPlatform.API.DataAccess.Configurations;
using BloodDonationPlatform.API.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


    public class DonorDonationRequestConfigurations : IEntityTypeConfiguration<DonorDonationRequest>
    {
     public void Configure(EntityTypeBuilder<DonorDonationRequest> builder)
     {

        builder.HasOne(ddr => ddr.Donor)
               .WithMany(d => d.DonationRequests)
               .HasForeignKey(ddr => ddr.DonorId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ddr => ddr.DonationRequest)
         .WithMany(dr => dr.DonorRequests)
         .HasForeignKey(ddr => ddr.DonationRequestId)
         .OnDelete(DeleteBehavior.Cascade);

    }

}

