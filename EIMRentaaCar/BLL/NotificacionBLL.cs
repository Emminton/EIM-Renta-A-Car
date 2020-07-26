using EIMRentaaCar.DAL;
using EIMRentaaCar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace EIMRentaaCar.BLL
{
    public class NotificacionBLL
    {
        public static bool Guardar(Notificaciones notificaciones)
        {
            if (!Existe(notificaciones.NotificacionId))// si no existe se inserta
                return Insertar(notificaciones);
            else
                return Modificar(notificaciones);
        }

        private static bool Insertar(Notificaciones notificaciones)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Notificaciones.Add(notificaciones);
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

        public static bool Modificar(Notificaciones notificaciones)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(notificaciones).State = EntityState.Modified;
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
                var aux = contexto.Notificaciones.Find(id);
                if (aux != null)
                {
                    contexto.Notificaciones.Remove(aux);//remueve la informacion de la entidad relacionada
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

        public static Notificaciones Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Notificaciones notificaciones;

            try
            {
                notificaciones = contexto.Notificaciones.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return notificaciones;
        }

        public static List<Notificaciones> GetList(Expression<Func<Notificaciones, bool>> expression)
        {
            List<Notificaciones> lista = new List<Notificaciones>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Notificaciones.Where(expression).ToList();
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
                encontrado = contexto.Notificaciones.Any(n => n.NotificacionId == id);
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

        public static void Mensaje(int id,string titulo, string asunto) // esto me permite crear la notificaciones
        {
               Notificaciones ntf = new Notificaciones(0, id, titulo, asunto, DateTime.Now);
               ntf.visto = false;
               Guardar(ntf); 
        }
    }
}
