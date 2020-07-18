using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EIMRentaaCar.Migrations
{
    public partial class segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "ConfirmarPassword", "Email", "FechaIngreso", "Nombre", "Password", "Roles", "UserName" },
                values: new object[] { 1, "MQAyADMANAA=", "Admin@gamil.com", new DateTime(2020, 7, 17, 20, 37, 10, 137, DateTimeKind.Local).AddTicks(8108), "Admistrador", "MQAyADMANAA=", "Administrador", "MA" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1);
        }
    }
}
