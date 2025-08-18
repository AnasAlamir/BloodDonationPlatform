using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonationPlatform.API.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeStatusInventoryToBeComputed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StatusInventory",
                table: "Inventories",
                type: "int",
                nullable: false,
                computedColumnSql: "\r\n                CASE\r\n                    WHEN [ExpirationDate] < GETUTCDATE() THEN 4\r\n                    WHEN [CurrentQuantity] <= 0 THEN 3\r\n                    WHEN [CurrentQuantity] < [MinimunQuantity] THEN 2\r\n                    ELSE 1\r\n                END",
                stored: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StatusInventory",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComputedColumnSql: "\r\n                CASE\r\n                    WHEN [ExpirationDate] < GETUTCDATE() THEN 4\r\n                    WHEN [CurrentQuantity] <= 0 THEN 3\r\n                    WHEN [CurrentQuantity] < [MinimunQuantity] THEN 2\r\n                    ELSE 1\r\n                END");
        }
    }
}
