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

        public static bool Guardar(Rentas rentas)
        {
            if (!Existe(rentas.RentaId))// si no existe se inserta
                return Insertar(rentas);
            else
                return Modificar(rentas);
        }

        private static bool Insertar(Rentas rentas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Rentas.Add(rentas);
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

        public static bool Modificar(Rentas rentas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(rentas).State = EntityState.Modified;
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
            Rentas rentas;

            try
            {
                rentas = contexto.Rentas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return rentas;
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
                encontrado = contexto.Rentas.Any(c => c.RentaId == id);
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
