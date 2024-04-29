using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RZAWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangingtoApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotelBookingID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ZooBookingID",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HotelBookingID",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ZooBookingID",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
