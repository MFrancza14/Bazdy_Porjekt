using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projektbazydanych.Migrations
{
    /// <inheritdoc />
    public partial class AddCenaZaGodzine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CenaZaGodzine",
                table: "Pojazdy",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CenaZaGodzine",
                table: "Pojazdy");
        }
    }
}
