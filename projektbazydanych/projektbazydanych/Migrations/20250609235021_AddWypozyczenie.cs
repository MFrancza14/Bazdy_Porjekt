using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projektbazydanych.Migrations
{
    /// <inheritdoc />
    public partial class AddWypozyczenie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wypozyczenia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Klient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pojazd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataStart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Czas = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wypozyczenia", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wypozyczenia");
        }
    }
}
