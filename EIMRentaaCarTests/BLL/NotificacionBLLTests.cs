using Microsoft.VisualStudio.TestTools.UnitTesting;
using EIMRentaaCar.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using EIMRentaaCar.Models;

namespace EIMRentaaCar.BLL.Tests
{
    [TestClass()]
    public class NotificacionBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Notificaciones notificaciones = new Notificaciones(0, 1, "Info", "Test", DateTime.Now);
            bool paso = false;
            paso = NotificacionBLL.Guardar(notificaciones);
            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Notificaciones notificaciones = new Notificaciones(1, 1, "Info", "Test Run", DateTime.Now);
            bool paso = false;
            paso = NotificacionBLL.Modificar(notificaciones);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;
            paso = NotificacionBLL.Eliminar(1);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            List<Notificaciones> notificaciones = new List<Notificaciones>();
            notificaciones = NotificacionBLL.GetList(n => true);
            Assert.IsNotNull(notificaciones);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            var paso = ClientesBLL.Existe(1);
            Assert.IsNotNull(paso); ;
        }

        [TestMethod()]
        public void MensajeTest()
        {
            Notificaciones ntf = new Notificaciones(0, 1, "Info", "Hi!", DateTime.Now);
            ntf.visto = false;
            bool paso = NotificacionBLL.Guardar(ntf);

            Assert.AreEqual(paso, true);
        }
    }
}