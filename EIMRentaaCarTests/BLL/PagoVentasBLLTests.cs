using Microsoft.VisualStudio.TestTools.UnitTesting;
using EIMRentaaCar.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using EIMRentaaCar.Models;

namespace EIMRentaaCar.BLL.Tests
{
    [TestClass()]
    public class PagoVentasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            PagoVentas pago = new PagoVentas(0, 1, 1, DateTime.Now, 1000);
            bool paso = PagoVentasBLL.Guardar(pago);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            PagoVentas pago = new PagoVentas(1, 1, 1, DateTime.Now, 1465);
            bool paso = false;
            paso = PagoVentasBLL.Modificar(pago);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;
            paso = PagoVentasBLL.Eliminar(1);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            var paso = PagoVentasBLL.Buscar(1);
            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<PagoVentas> lista = new List<PagoVentas>();
            lista = PagoVentasBLL.GetList(p => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            var paso = PagoVentasBLL.Existe(1);
            Assert.IsNotNull(paso);
        }
    }
}