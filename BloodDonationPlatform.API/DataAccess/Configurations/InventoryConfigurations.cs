namespace BloodDonationPlatform.API.DataAccess.Configurations
{
    using BloodDonationPlatform.API.DataAccess.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection.Emit;

    public class InventoryConfigurations : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {

            builder.HasOne(id => id.BloodType)
                   .WithMany(bt => bt.Inventory)
                   .HasForeignKey(id => id.BloodTypeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(id => id.Hospital)
                   .WithMany(h => h.Inventory)
                   .HasForeignKey(id => id.HospitalId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(i => i.CurrentQuantity)
                   .IsRequired()
                   .HasDefaultValue(10);

            //builder.Property(o => o.StatusInventory)
            //    .HasConversion(s => s.ToString(), s => Enum.Parse<StatusInventory>(s));

            builder.Property(i => i.StatusInventory)
                .HasConversion<int>() // store enum as int
                .HasComputedColumnSql(@"
                CASE
                    WHEN [ExpirationDate] < GETUTCDATE() THEN 4
                    WHEN [CurrentQuantity] <= 0 THEN 3
                    WHEN [CurrentQuantity] < [MinimunQuantity] THEN 2
                    ELSE 1
                END", stored: false);
        }
    }
}

