using EIMRentaaCar.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EIMRentaaCar.DAL
{
    public class Contexto : IdentityDbContext
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server = .\SqlExpress; Database = EIM.db; Trusted_Connection = True; ");
            optionsBuilder.UseSqlite(@"Data Source=Data\EIM.db");
        }

    }
}
