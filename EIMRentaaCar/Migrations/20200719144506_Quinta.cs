using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EIMRentaaCar.Migrations
{
    public partial class Quinta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BancoAsociados",
                columns: table => new
                {
                    BancoAsociadoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Telefono = table.Column<string>(maxLength: 10, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PaginaWeb = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BancoAsociados", x => x.BancoAsociadoId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 40, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Cedula = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(maxLength: 10, nullable: false),
                    Direccion = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Importadores",
                columns: table => new
                {
                    ImportadorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Telefono = table.Column<string>(maxLength: 10, nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Importadores", x => x.ImportadorId);
                });

            migrationBuilder.CreateTable(
                name: "PagoRentas",
                columns: table => new
                {
                    PagoRentaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RentaId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagoRentas", x => x.PagoRentaId);
                });

            migrationBuilder.CreateTable(
                name: "PagoVentas",
                columns: table => new
                {
                    PagoVentaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VentaId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagoVentas", x => x.PagoVentaId);
                });

            migrationBuilder.CreateTable(
                name: "Rentas",
                columns: table => new
                {
                    RentaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VehiculoId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    Marca = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    Vin = table.Column<int>(nullable: false),
                    FechaRenta = table.Column<DateTime>(nullable: false),
                    TiempoRenta = table.Column<int>(maxLength: 30, nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentas", x => x.RentaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 30, nullable: false),
                    Password = table.Column<string>(maxLength: 60, nullable: false),
                    ConfirmarPassword = table.Column<string>(maxLength: 60, nullable: false),
                    Roles = table.Column<string>(nullable: false),
                    FechaIngreso = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    VehiculoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    Estado = table.Column<string>(nullable: false),
                    Tipo = table.Column<string>(nullable: false),
                    Modelo = table.Column<string>(nullable: false),
                    Marca = table.Column<string>(nullable: false),
                    Vin = table.Column<string>(nullable: false),
                    Año = table.Column<int>(nullable: false),
                    PrecioVenta = table.Column<decimal>(nullable: false),
                    PrecioPorDia = table.Column<decimal>(nullable: false),
                    Kilometraje = table.Column<int>(nullable: false),
                    ImportadorId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.VehiculoId);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    VentaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(nullable: false),
                    VehiculoId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    Cuotas = table.Column<int>(nullable: false),
                    MontoTotal = table.Column<decimal>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    MontoCuotas = table.Column<decimal>(nullable: false),
                    FechaVenta = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.VentaId);
                });

            migrationBuilder.CreateTable(
                name: "PagoDetalles",
                columns: table => new
                {
                    PagoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PagoRentaId = table.Column<int>(nullable: false),
                    PagoVentaId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    Cuotas = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagoDetalles", x => x.PagoId);
                    table.ForeignKey(
                        name: "FK_PagoDetalles_PagoRentas_PagoRentaId",
                        column: x => x.PagoRentaId,
                        principalTable: "PagoRentas",
                        principalColumn: "PagoRentaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PagoDetalles_PagoVentas_PagoVentaId",
                        column: x => x.PagoVentaId,
                        principalTable: "PagoVentas",
                        principalColumn: "PagoVentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuotaDetalles",
                columns: table => new
                {
                    CuotaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VentaId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    Pagada = table.Column<bool>(nullable: false),
                    Numero = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuotaDetalles", x => x.CuotaId);
                    table.ForeignKey(
                        name: "FK_CuotaDetalles_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "VentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "ConfirmarPassword", "Email", "FechaIngreso", "Nombre", "Password", "Roles", "UserName" },
                values: new object[] { 1, "MQAyADMANAA=", "Admin@gamil.com", new DateTime(2020, 7, 19, 10, 45, 6, 352, DateTimeKind.Local).AddTicks(9168), "Admistrador", "MQAyADMANAA=", "Administrador", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_CuotaDetalles_VentaId",
                table: "CuotaDetalles",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_PagoDetalles_PagoRentaId",
                table: "PagoDetalles",
                column: "PagoRentaId");

            migrationBuilder.CreateIndex(
                name: "IX_PagoDetalles_PagoVentaId",
                table: "PagoDetalles",
                column: "PagoVentaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BancoAsociados");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "CuotaDetalles");

            migrationBuilder.DropTable(
                name: "Importadores");

            migrationBuilder.DropTable(
                name: "PagoDetalles");

            migrationBuilder.DropTable(
                name: "Rentas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "PagoRentas");

            migrationBuilder.DropTable(
                name: "PagoVentas");
        }
    }
}
