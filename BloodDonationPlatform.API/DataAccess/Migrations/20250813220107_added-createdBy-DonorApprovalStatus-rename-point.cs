using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonationPlatform.API.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedcreatedByDonorApprovalStatusrenamepoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Point",
                table: "Donors",
                newName: "TotalPoints");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Hospitals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "DonorApprovalStatus",
                table: "DonorDonationRequests",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "DonorApprovalStatus",
                table: "DonorDonationRequests");

            migrationBuilder.RenameColumn(
                name: "TotalPoints",
                table: "Donors",
                newName: "Point");
        }
    }
}
