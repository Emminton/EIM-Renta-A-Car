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
    public class ImportadoresBLL
    {
        public static bool Guardar(Importadores importadores)
        {
            if (!Existe(importadores.ImportadorId))// si no existe se inserta
                return Insertar(importadores);
            else
                return Modificar(importadores);
        }

        private static bool Insertar(Importadores importadores)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Importadores.Add(importadores);
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

        public static bool Modificar(Importadores importadores)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(importadores).State = EntityState.Modified;
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
                var aux = contexto.Importadores.Find(id);
                if (aux != null)
                {
                    contexto.Importadores.Remove(aux);//remueve la informacion de la entidad relacionada
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

        public static Importadores Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Importadores importadores;

            try
            {
                importadores = contexto.Importadores.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return importadores;
        }

        public static List<Importadores> GetList(Expression<Func<Importadores, bool>> expression)
        {
            List<Importadores> lista = new List<Importadores>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Importadores.Where(expression).ToList();
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
                encontrado = contexto.Importadores.Any(i => i.ImportadorId == id);
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
