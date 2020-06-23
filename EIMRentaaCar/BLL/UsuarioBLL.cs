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
    public class UsuarioBLL
    {
        public static bool Guardar(Usuarios usuario)
        {
            if (!Existe(usuario.UsuarioId))// si no existe se inserta
                return Insertar(usuario);
            else
                return Modificar(usuario);
        }

        private static bool Insertar(Usuarios usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                usuario.Clave = Usuarios.Encriptar(usuario.Clave);
                usuario.ConfirmarClave = Usuarios.Encriptar(usuario.ConfirmarClave);
                contexto.Usuarios.Add(usuario);
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

        public static bool Modificar(Usuarios usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                usuario.Clave = Usuarios.Encriptar(usuario.Clave);
                usuario.ConfirmarClave = Usuarios.Encriptar(usuario.ConfirmarClave);
                contexto.Entry(usuario).State = EntityState.Modified;
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
                var aux = contexto.Usuarios.Find(id);
                if (aux != null)
                {
                    contexto.Usuarios.Remove(aux);//remueve la informacion de la entidad relacionada
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

        public static Usuarios Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Usuarios usuarios;

            try
            {
                usuarios = contexto.Usuarios.Find(id);
                usuarios.Clave = Usuarios.DesEncriptar(usuarios.Clave);
                usuarios.ConfirmarClave = Usuarios.DesEncriptar(usuarios.ConfirmarClave);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return usuarios;
        }

        public static List<Usuarios> GetList(Expression<Func<Usuarios, bool>> expression)
        {
            List<Usuarios> lista = new List<Usuarios>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Usuarios.Where(expression).ToList();
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
                encontrado = contexto.Usuarios.Any(u => u.UsuarioId == id);
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
