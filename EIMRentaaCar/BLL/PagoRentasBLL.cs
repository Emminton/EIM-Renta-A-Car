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
    public class PagoRentasBLL
    {
        public static bool Guardar(PagoRentas pagoRentas)
        {
            if (!Existe(pagoRentas.PagoRentaId))// si no existe se inserta
                return Insertar(pagoRentas);
            else
                return Modificar(pagoRentas);
        }

        private static bool Insertar(PagoRentas pagoRentas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.PagoRentas.Add(pagoRentas);
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

        public static bool Modificar(PagoRentas pagoRentas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Database.ExecuteSqlRaw($"Delete From RentaDetalles Where PagoRentaId = { pagoRentas.PagoRentaId}");

                foreach (PagoDetalles item in pagoRentas.RentaDetalles)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Entry(pagoRentas).State = EntityState.Modified;
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
                var aux = contexto.PagoRentas.Find(id);
                if (aux != null)
                {
                    contexto.PagoRentas.Remove(aux);//remueve la informacion de la entidad relacionada
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

        public static PagoRentas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            PagoRentas pagoRentas;

            try
            {
                pagoRentas = contexto.PagoRentas
                    .Where(p => p.PagoRentaId == id)
                    .Include(p => p.RentaDetalles)
                    .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return pagoRentas;
        }

        public static List<PagoRentas> GetList(Expression<Func<PagoRentas, bool>> persona)
        {
            List<PagoRentas> lista = new List<PagoRentas>();
            Contexto db = new Contexto();

            try
            {
                lista = db.PagoRentas.Where(persona).ToList();
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
                encontrado = contexto.PagoRentas.Any(p => p.PagoRentaId == id);
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
