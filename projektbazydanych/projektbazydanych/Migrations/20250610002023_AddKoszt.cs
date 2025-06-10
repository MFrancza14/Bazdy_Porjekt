using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projektbazydanych.Migrations
{
    /// <inheritdoc />
    public partial class AddKoszt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Koszt",
                table: "Wypozyczenia",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Koszt",
                table: "Wypozyczenia");
        }
    }
}
