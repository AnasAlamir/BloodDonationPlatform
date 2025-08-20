using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonationPlatform.API.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EditConfigurationHospitalandDoner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donors_Users_UserId",
                table: "Donors");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_Users_UserId",
                table: "Hospitals");

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_Users_UserId",
                table: "Donors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_Users_UserId",
                table: "Hospitals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donors_Users_UserId",
                table: "Donors");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_Users_UserId",
                table: "Hospitals");

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_Users_UserId",
                table: "Donors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_Users_UserId",
                table: "Hospitals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
