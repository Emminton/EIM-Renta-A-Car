using Microsoft.VisualStudio.TestTools.UnitTesting;
using EIMRentaaCar.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using EIMRentaaCar.Models;

namespace EIMRentaaCar.BLL.Tests
{
    [TestClass()]
    public class VehiculosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Vehiculos vehiculos = new Vehiculos(0, 1, "Disponible", "jeepeta", "Hilux", "Toyota", "ZA12", 2010, 50000, 1000, 0, 1, DateTime.Now);
            bool paso = false;
            paso = VehiculosBLL.Guardar(vehiculos);
            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Vehiculos vehiculos = new Vehiculos(1, 1, "Disponible", "jeepeta", "Hilux", "Toyota", "ZA12", 2015, 50000, 1000, 0, 1, DateTime.Now);
            bool paso = false;
            paso = VehiculosBLL.Modificar(vehiculos);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;
            paso = VehiculosBLL.Eliminar(1);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            var paso = UsuarioBLL.Buscar(1);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Vehiculos> vehiculo = new List<Vehiculos>();
            vehiculo = VehiculosBLL.GetList(v => true);
            Assert.IsNotNull(vehiculo);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            var paso = VehiculosBLL.Existe(1);
            Assert.IsNotNull(paso);
        }
    }
}