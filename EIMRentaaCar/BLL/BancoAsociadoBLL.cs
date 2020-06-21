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
    public class BancoAsociadoBLL
    {
        public static bool Guardar(BancosAsociados bancos)
        {
            if (!Existe(bancos.BancoAsociadoId))// si no existe se inserta
                return Insertar(bancos);
            else
                return Modificar(bancos);
        }

        private static bool Insertar(BancosAsociados bancos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.BancoAsociados.Add(bancos);
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

        public static bool Modificar(BancosAsociados bancos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(bancos).State = EntityState.Modified;
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
                var aux = contexto.BancoAsociados.Find(id);
                if (aux != null)
                {
                    contexto.BancoAsociados.Remove(aux);//remueve la informacion de la entidad relacionada
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

        public static BancosAsociados Buscar(int id)
        {
            Contexto contexto = new Contexto();
            BancosAsociados bancos;

            try
            {
                bancos = contexto.BancoAsociados.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return bancos;
        }

        public static List<BancosAsociados> GetList(Expression<Func<BancosAsociados, bool>> bancos)
        {
            List<BancosAsociados> lista = new List<BancosAsociados>();
            Contexto db = new Contexto();

            try
            {
                lista = db.BancoAsociados.Where(bancos).ToList();
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
                encontrado = contexto.BancoAsociados.Any(b => b.BancoAsociadoId == id);
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
