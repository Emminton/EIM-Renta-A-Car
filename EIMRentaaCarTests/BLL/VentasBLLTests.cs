using Microsoft.VisualStudio.TestTools.UnitTesting;
using EIMRentaaCar.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using EIMRentaaCar.Models;

namespace EIMRentaaCar.BLL.Tests
{
    [TestClass()]
    public class VentasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Ventas ventas = new Ventas();
            ventas.VentaId = 0;
            ventas.UsuarioId = 1;
            ventas.ClienteId = 1;
            ventas.Cuotas = 4;
            ventas.Balance = 14555;
            ventas.VehiculoId = 1;
            ventas.MontoCuotas = 4569;
            ventas.MontoTotal = 15000;
            ventas.FechaVenta = DateTime.Now;
            ventas.CuotaDetalles.Add(new CuotaDetalles
            {
                CuotaId = 0,
                VentaId=1,
                UsuarioId=1,
                Monto = 1000,
                Balance = 500,
                Pagada = false,
                Numero=4
            }) ;
            Assert.IsTrue(VentasBLL.Guardar(ventas));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Ventas ventas = new Ventas();
            ventas.VentaId = 1;
            ventas.UsuarioId = 1;
            ventas.ClienteId = 1;
            ventas.Cuotas = 4;
            ventas.Balance = 15555;
            ventas.VehiculoId = 1;
            ventas.MontoCuotas = 4569;
            ventas.MontoTotal = 15000;
            ventas.FechaVenta = DateTime.Now;
            ventas.CuotaDetalles.Add(new CuotaDetalles
            {
                CuotaId = 1,
                VentaId = 1,
                UsuarioId = 1,
                Monto = 1000,
                Balance = 500,
                Pagada = false,
                Numero = 4
            });
            Assert.IsTrue(VentasBLL.Modificar(ventas));
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = VentasBLL.Eliminar(1);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            var paso = VentasBLL.Buscar(1);
            Assert.AreEqual(paso, paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var lista = new List<Ventas>();
            lista = VentasBLL.GetList(v => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            var paso = VentasBLL.Existe(1);
            Assert.IsNotNull(paso);
        }
    }
}