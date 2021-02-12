using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCore.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    Nombres = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: false),
                    Cedula = table.Column<string>(type: "TEXT", unicode: false, maxLength: 15, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.Nombres);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prestamos");
        }
    }
}
