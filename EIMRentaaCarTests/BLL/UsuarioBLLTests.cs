using Microsoft.VisualStudio.TestTools.UnitTesting;
using EIMRentaaCar.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using EIMRentaaCar.Models;

namespace EIMRentaaCar.BLL.Tests
{
    [TestClass()]
    public class UsuarioBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Usuarios usuarios = new Usuarios(0, "Martin", "lamatriz7777@gmail.com", "Ma12", "1456", "1456", "Empleado", DateTime.Now);
            bool paso = false;
            paso = UsuarioBLL.Guardar(usuarios);
            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Usuarios usuarios = new Usuarios(2, "Martins", "lamatriz7777@gmail.com", "Ma12", "1456", "1456", "Empleado", DateTime.Now);
            bool paso = false;
            paso = UsuarioBLL.Modificar(usuarios);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;
            paso = UsuarioBLL.Eliminar(2);
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
            List<Usuarios> usuario = new List<Usuarios>();
            usuario = UsuarioBLL.GetList(u => true);
            Assert.IsNotNull(usuario);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            var paso = UsuarioBLL.Existe(1);
            Assert.IsNotNull(paso);
        }
     
    }
}