  using Microsoft.VisualStudio.TestTools.UnitTesting;
using EIMRentaaCar.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using EIMRentaaCar.Models;

namespace EIMRentaaCar.BLL.Tests
{
    [TestClass()]
    public class ClientesBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Clientes clientes = new Clientes(0, 1, "Elian", DateTime.Now, "40212912998", "8095567841", "Villa Aeeiba", "Elian@gmail.com");
            bool paso = ClientesBLL.Guardar(clientes);
            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Clientes clientes = new Clientes(1, 1, "Elian Rodriguez", DateTime.Now, "40212912998", "8095567841", "Villa Aeeiba", "Elian@gmail.com");
            bool paso = ClientesBLL.Modificar(clientes);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;
            paso = ClientesBLL.Eliminar(1);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            var paso = ClientesBLL.Buscar(1);
            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Clientes> clientes = new List<Clientes>();
            clientes = ClientesBLL.GetList(c => true);
            Assert.IsNotNull(clientes);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            var paso = ClientesBLL.Existe(1);
            Assert.IsNotNull(paso);
        }
    }
}