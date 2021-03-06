﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EIMRentaaCar.Migrations
{
    public partial class EM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BancoAsociados",
                columns: table => new
                {
                    BancoAsociadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Telefono = table.Column<string>(maxLength: 10, nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Importadores", x => x.ImportadorId);
                });

            migrationBuilder.CreateTable(
                name: "Notificaciones",
                columns: table => new
                {
                    NotificacionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(nullable: false),
                    Asunto = table.Column<string>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    visto = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificaciones", x => x.NotificacionId);
                });

            migrationBuilder.CreateTable(
                name: "PagoRentas",
                columns: table => new
                {
                    PagoRentaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentaId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VentaId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehiculoId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    FechaRenta = table.Column<DateTime>(nullable: false),
                    TiempoRenta = table.Column<int>(nullable: false),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(nullable: false),
                    Estado = table.Column<string>(nullable: false),
                    Tipo = table.Column<string>(nullable: false),
                    Modelo = table.Column<string>(nullable: false),
                    Marca = table.Column<string>(nullable: false),
                    Vin = table.Column<string>(nullable: false),
                    Año = table.Column<int>(nullable: false),
                    PrecioVenta = table.Column<decimal>(nullable: false),
                    ITBIS = table.Column<double>(nullable: false),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentaId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    Pagada = table.Column<bool>(nullable: false),
                    Dias = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagoDetalles", x => x.PagoId);
                    table.ForeignKey(
                        name: "FK_PagoDetalles_Rentas_RentaId",
                        column: x => x.RentaId,
                        principalTable: "Rentas",
                        principalColumn: "RentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuotaDetalles",
                columns: table => new
                {
                    CuotaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                values: new object[] { 1, "MQAyADMANAA=", "Admin@gamil.com", new DateTime(2020, 8, 4, 13, 36, 53, 775, DateTimeKind.Local).AddTicks(5685), "Admistrador", "MQAyADMANAA=", "Administrador", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_CuotaDetalles_VentaId",
                table: "CuotaDetalles",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_PagoDetalles_RentaId",
                table: "PagoDetalles",
                column: "RentaId");
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
                name: "Notificaciones");

            migrationBuilder.DropTable(
                name: "PagoDetalles");

            migrationBuilder.DropTable(
                name: "PagoRentas");

            migrationBuilder.DropTable(
                name: "PagoVentas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Rentas");
        }
    }
}
