using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonationPlatform.API.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EditRelationshipUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Donors_DonorId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Hospitals_HospitalId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DonorId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_HospitalId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DonorId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HospitalId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Hospitals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Donors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddCheckConstraint(
                name: "CK_User_Role_Valid",
                table: "Users",
                sql: "Role IN ('Donor', 'Hospital', 'SystemAdmin')");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_UserId",
                table: "Hospitals",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donors_UserId",
                table: "Donors",
                column: "UserId",
                unique: true);

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

            migrationBuilder.DropCheckConstraint(
                name: "CK_User_Role_Valid",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Hospitals_UserId",
                table: "Hospitals");

            migrationBuilder.DropIndex(
                name: "IX_Donors_UserId",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Donors");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "DonorId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HospitalId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_DonorId",
                table: "Users",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_HospitalId",
                table: "Users",
                column: "HospitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Donors_DonorId",
                table: "Users",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Hospitals_HospitalId",
                table: "Users",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "Id");
        }
    }
}
