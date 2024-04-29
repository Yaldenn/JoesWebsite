using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RZAWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateHotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookHotelTickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FamilyRooms = table.Column<int>(type: "int", nullable: true),
                    DoubleRooms = table.Column<int>(type: "int", nullable: true),
                    SingleRooms = table.Column<int>(type: "int", nullable: true),
                    BookingTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookHotelTickets", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookHotelTickets");
        }
    }
}
