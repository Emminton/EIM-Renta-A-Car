using EIMRentaaCar.BLL;
using EIMRentaaCar.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EIMRentaaCar.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Rentas> Rentas { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<PagoRentas> PagoRentas { get; set; }
        public DbSet<PagoVentas> PagoVentas { get; set; }
        public DbSet<BancosAsociados> BancoAsociados { get; set; }
        public DbSet<Importadores> Importadores { get; set; }
        public DbSet<Vehiculos> Vehiculos { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<PagoDetalles> PagoDetalles { get; set; }
        public DbSet<CuotaDetalles> CuotaDetalles { get; set; }
        public DbSet<Notificaciones> Notificaciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer(@"Server=tcp:proyectoap2.database.windows.net,1433;Initial Catalog=EIM;Persist Security Info=False;User ID=martin;Password=admin!123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            optionsBuilder.UseSqlServer(@"Server = .\SqlExpress; Database = EIM.db; Trusted_Connection = True; ");
            //optionsBuilder.UseSqlite(@"Data Source=Data\EIM.db");
        }

        protected override void OnModelCreating(ModelBuilder model)
        {


            model.Entity<Usuarios>().HasData(new Usuarios
            {
                UsuarioId = 1,
                Nombre = "Admistrador",
                Email = "Admin@gamil.com",
                Password = UsuarioBLL.Encriptar("1234"),
                ConfirmarPassword = UsuarioBLL.Encriptar("1234"),
                Roles = "Administrador",
                FechaIngreso = DateTime.Now,
                UserName = "admin"

            });
        }
    }
}