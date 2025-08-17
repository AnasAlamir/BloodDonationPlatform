using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonationPlatform.API.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataTypeNumofLiterint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NumOfLiter",
                table: "DonationRequests",
                type: "int",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "NumOfLiter",
                table: "DonationRequests",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldPrecision: 10,
                oldScale: 2);
        }
    }
}
