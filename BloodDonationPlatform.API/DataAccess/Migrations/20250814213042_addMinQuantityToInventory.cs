using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonationPlatform.API.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addMinQuantityToInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Inventories",
                newName: "CurrentQuantity");

            migrationBuilder.AddColumn<int>(
                name: "MinimunQuantity",
                table: "Inventories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinimunQuantity",
                table: "Inventories");

            migrationBuilder.RenameColumn(
                name: "CurrentQuantity",
                table: "Inventories",
                newName: "Quantity");
        }
    }
}
