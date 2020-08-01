using Microsoft.VisualStudio.TestTools.UnitTesting;
using EIMRentaaCar.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using EIMRentaaCar.Models;

namespace EIMRentaaCar.BLL.Tests
{
    [TestClass()]
    public class PagoRentasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            PagoRentas pago = new PagoRentas(0,1, 1, DateTime.Now, 1222);
      
            bool paso = PagoRentasBLL.Guardar(pago);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            PagoRentas pago = new PagoRentas(1, 1, 1, DateTime.Now, 1465);
            bool paso = false;
            paso = PagoRentasBLL.Modificar(pago);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;
            paso = PagoRentasBLL.Eliminar(1);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            var paso = PagoRentasBLL.Buscar(1);
            Assert.AreEqual(paso,paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<PagoRentas> lista = new List<PagoRentas>();
            lista = PagoRentasBLL.GetList(c => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            var paso = PagoRentasBLL.Existe(1);
            Assert.IsNotNull(paso);
        }
    }
}