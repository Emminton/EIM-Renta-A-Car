using Microsoft.VisualStudio.TestTools.UnitTesting;
using EIMRentaaCar.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using EIMRentaaCar.Models;

namespace EIMRentaaCar.BLL.Tests
{
    [TestClass()]
    public class RentasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Rentas rentas = new Rentas();
            rentas.RentaId = 0;
            rentas.VehiculoId = 1;
            rentas.UsuarioId = 1;
            rentas.FechaRenta = DateTime.Now;
            rentas.Balance = 150000;
            rentas.ClienteId = 1;
            rentas.TiempoRenta = 4;
            rentas.PagoDetalle.Add(new PagoDetalles
            {
                PagoId = 0,
                RentaId = 1,
                UsuarioId = 1,
                Monto = 1222,
                Balance = 1234,
                Pagada = false,
                Dias = 4
            }) ;
            Assert.IsTrue(RentasBLL.Guardar(rentas));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Rentas rentas = new Rentas();
            rentas.RentaId = 1;
            rentas.VehiculoId = 1;
            rentas.UsuarioId = 1;
            rentas.FechaRenta = DateTime.Now;
            rentas.Balance = 15000;
            rentas.ClienteId = 1;
            rentas.TiempoRenta = 4;
            rentas.PagoDetalle.Add(new PagoDetalles
            {
                PagoId = 1,
                RentaId = 1,
                UsuarioId = 1,
                Monto = 1222,
                Balance = 1234,
                Pagada = false,
                Dias = 4
            });
            Assert.IsTrue(RentasBLL.Modificar(rentas));
        }
    

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = RentasBLL.Eliminar(1);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            var paso = RentasBLL.Buscar(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var lista = new List<Rentas>();
            lista = RentasBLL.GetList(r => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            var paso = RentasBLL.Existe(1);
            Assert.IsNotNull(paso);
        }
    }
}