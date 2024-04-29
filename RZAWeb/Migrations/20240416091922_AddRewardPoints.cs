using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RZAWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddRewardPoints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsAdmin",
                table: "ApplicationUser",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "RewardPoints",
                table: "ApplicationUser",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RewardPoints",
                table: "ApplicationUser");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAdmin",
                table: "ApplicationUser",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}
