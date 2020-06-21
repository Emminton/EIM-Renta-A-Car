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
    public class VehiculosBLL
    {
        public static bool Guardar(Vehiculos vehiculos)
        {
            if (!Existe(vehiculos.VehiculoId))// si no existe se inserta
                return Insertar(vehiculos);
            else
                return Modificar(vehiculos);
        }

        private static bool Insertar(Vehiculos vehiculos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Vehiculos.Add(vehiculos);
                //contexto.Vehiculos.Find(vehiculos.VehiculoId).Tipo = Models.Enums.TipoVehiculo.Idefinido;
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

        public static bool Modificar(Vehiculos vehiculos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(vehiculos).State = EntityState.Modified;
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
                var aux = contexto.Vehiculos.Find(id);
                if (aux != null)
                {
                    contexto.Vehiculos.Remove(aux);//remueve la informacion de la entidad relacionada
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

        public static Vehiculos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Vehiculos vehiculos;

            try
            {
                vehiculos = contexto.Vehiculos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return vehiculos;
        }

        public static List<Vehiculos> GetList(Expression<Func<Vehiculos, bool>> expression)
        {
            List<Vehiculos> lista = new List<Vehiculos>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Vehiculos.Where(expression).ToList();
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
                encontrado = contexto.Vehiculos.Any(v => v.VehiculoId == id);
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
