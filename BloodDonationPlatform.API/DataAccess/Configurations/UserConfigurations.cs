using BloodDonationPlatform.API.DataAccess.Models;
using BloodDonationPlatform.API.DataAccess.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.Property(u => u.Role)
    .HasConversion<string>() // يحوّل الـ Enum لـ string في DB
    .IsRequired()
    .HasMaxLength(50);

        builder.HasCheckConstraint("CK_User_Role_Valid",
            "Role IN ('Donor', 'Hospital', 'SystemAdmin')");

    }
}
