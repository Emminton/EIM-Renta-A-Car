using EIMRentaaCar.DAL;
using EIMRentaaCar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
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
                usuario.Password = Encriptar(usuario.Password);
                usuario.ConfirmarPassword = Encriptar(usuario.ConfirmarPassword);
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
                usuario.Password = Encriptar(usuario.Password);
                usuario.ConfirmarPassword = Encriptar(usuario.ConfirmarPassword);
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
                usuarios = contexto.Usuarios.Where(A => A.UsuarioId == id).FirstOrDefault();
                usuarios.Password = DesEncriptar(usuarios.Password);
                usuarios.ConfirmarPassword = DesEncriptar(usuarios.ConfirmarPassword);
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

        public static string Encriptar(string cadena)
        {
            if (!string.IsNullOrEmpty(cadena))
            {
                string resultado = string.Empty;
                byte[] encryted = Encoding.Unicode.GetBytes(cadena);
                resultado = Convert.ToBase64String(encryted);

                return resultado;
            }
            return string.Empty;
        }

        public static string DesEncriptar(string cadenaDesencriptada)
        {
            if (!string.IsNullOrEmpty(cadenaDesencriptada))
            {
                string resultado = string.Empty;
                byte[] decryted = Convert.FromBase64String(cadenaDesencriptada);
                resultado = System.Text.Encoding.Unicode.GetString(decryted);

                return resultado;
            }

            return string.Empty;
        }

    }
}
