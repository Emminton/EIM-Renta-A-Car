using Microsoft.VisualStudio.TestTools.UnitTesting;
using EIMRentaaCar.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using EIMRentaaCar.Models;

namespace EIMRentaaCar.BLL.Tests
{
    [TestClass()]
    public class ImportadoresBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Importadores importadores = new Importadores(0,1,"NissanRD","8096637896","Nissanrd@gmail.com");
            bool paso = false;
            paso = ImportadoresBLL.Guardar(importadores);
            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Importadores importadores = new Importadores(1, 1, "NissanRD", "8096637896", "NissanDominican@gmail.com");
            bool paso = false;
            paso = ImportadoresBLL.Modificar(importadores);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;
            paso = ImportadoresBLL.Eliminar(1);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            var paso = ImportadoresBLL.Buscar(1);
            Assert.AreEqual(paso,paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Importadores> importadores = new List<Importadores>();
            importadores = ImportadoresBLL.GetList(i => true);
            Assert.IsNotNull(importadores);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            var paso = ImportadoresBLL.Existe(1);
            Assert.IsNotNull(paso);
        }
    }
}