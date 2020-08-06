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
    public class RentasBLL
    {
        public static bool Guardar(Rentas ventas)
        {
            if (!Existe(ventas.RentaId))// si no existe se inserta
                return Insertar(ventas);
            else
                return Modificar(ventas);
        }

        private static bool Insertar(Rentas ventas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var vehiculo = VehiculosBLL.Buscar(ventas.VehiculoId);

                if (vehiculo != null)
                {
                    vehiculo.Estado = "Rentado";    //Cambiando el estado del vehículo a vendido
                    VehiculosBLL.Modificar(vehiculo);
                }

                contexto.Rentas.Add(ventas);
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

        public static bool Modificar(Rentas ventas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                foreach (PagoDetalles item in ventas.PagoDetalle)
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
                var aux = contexto.Rentas.Find(id);

                if (aux != null)
                {
                    var auxVehiculo = contexto.Vehiculos.Find(aux.VehiculoId);
                    if (auxVehiculo != null)
                    {
                        auxVehiculo.Estado = "Disponible";
                        VehiculosBLL.Modificar(auxVehiculo);
                    }
                    contexto.Rentas.Remove(aux);//remueve la informacion de la entidad relacionada
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

        public static Rentas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Rentas ventas;

            try
            {
                ventas = contexto.Rentas.Where(v => v.RentaId == id)
                                 .Include(v => v.PagoDetalle)
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

        public static List<Rentas> GetList(Expression<Func<Rentas, bool>> expression)
        {
            List<Rentas> lista = new List<Rentas>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Rentas.Where(expression).ToList();
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
