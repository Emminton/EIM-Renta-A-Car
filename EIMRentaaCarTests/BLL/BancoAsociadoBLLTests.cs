using EIMRentaaCar.BLL;
using EIMRentaaCar.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace EIMRentaaCar.BLL.Tests
{
    [TestClass()]
    public class BancoAsociadoBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            BancosAsociados bancos = new BancosAsociados(0, 1, "Banreserve", DateTime.Now, "8099556378", "BancoReserva@gmail.com", "https://www.banreservas.com/");
            bool paso = false;
            paso = BancoAsociadoBLL.Guardar(bancos);
            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            BancosAsociados bancos = new BancosAsociados(1, 1, "Banreserva", DateTime.Now, "8099556378", "BancoReserva@gmail.com", "https://www.banreservas.com/");
            bool paso = false;
            paso = BancoAsociadoBLL.Modificar(bancos);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;
            paso = BancoAsociadoBLL.Eliminar(1);
            Assert.AreEqual(paso,paso); 
        }

        [TestMethod()]
        public void BuscarTest()
        {           
            var paso = BancoAsociadoBLL.Buscar(1);
            Assert.AreEqual(paso,paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<BancosAsociados> bancos = new List<BancosAsociados>();
            bancos = BancoAsociadoBLL.GetList(b => true);
            Assert.IsNotNull(bancos);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            var paso = BancoAsociadoBLL.Existe(1);
            Assert.IsNotNull(paso);
        }
    }
}