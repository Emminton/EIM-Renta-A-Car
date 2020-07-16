using EIMRentaaCar.DAL;
using EIMRentaaCar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EIMRentaaCar.BLL
{
    public class VentasBLL
    {
        public static bool Guardar(Ventas ventas)
        {
            if (!Existe(ventas.VentaId))// si no existe se inserta
                return Insertar(ventas);
            else
                return Modificar(ventas);
        }

        private static bool Insertar(Ventas ventas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var vehiculo = VehiculosBLL.Buscar(ventas.VehiculoId);

                if (vehiculo != null)
                {
                    vehiculo.Estado = "Vendido";    //Cambiando el estado del vehículo a vendido
                    VehiculosBLL.Modificar(vehiculo);
                }

                contexto.Ventas.Add(ventas);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Ventas ventas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {              

                foreach (CuotaDetalles item in ventas.CuotaDetalles)
                {
                    contexto.Entry(item).State = EntityState.Modified;
                }

                contexto.Entry(ventas).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var aux = contexto.Ventas.Find(id);

                if (aux != null)
                {
                    var auxVehiculo = contexto.Vehiculos.Find(aux.VehiculoId);
                    if (auxVehiculo != null)
                    {
                         auxVehiculo.Estado = "Disponible";
                        VehiculosBLL.Modificar(auxVehiculo);
                    }
                    contexto.Ventas.Remove(aux);//remueve la informacion de la entidad relacionada
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Ventas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ventas ventas;

            try
            {
                ventas = contexto.Ventas.Where(v => v.VentaId == id)
                                 .Include(v => v.CuotaDetalles)
                                 .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return ventas;
        }

        public static List<Ventas> GetList(Expression<Func<Ventas, bool>> expression)
        {
            List<Ventas> lista = new List<Ventas>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Ventas.Where(expression).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return lista;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Ventas.Any(v => v.VentaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
    }
}
