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
    public class PagoVentasBLL
    {
        public static bool Guardar(PagoVentas pago)
        {
            if (!Existe(pago.PagoVentaId))// si no existe se inserta
                return Insertar(pago);
            else
                return Modificar(pago);
        }

        private static bool Insertar(PagoVentas pago)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Ventas venta = VentasBLL.Buscar(pago.VentaId);

                for (int i = 0; i < venta.CuotaDetalles.Count; i++)
                {

                    if (pago.Monto >= venta.CuotaDetalles[i].Monto && venta.CuotaDetalles[i].Pagada == false)
                    {

                        pago.Monto -= venta.CuotaDetalles[i].Balance;
                        venta.CuotaDetalles[i].Balance = 0;
                        venta.CuotaDetalles[i].Pagada = true;


                    }
                    else if (pago.Monto <= venta.CuotaDetalles[i].Monto && venta.CuotaDetalles[i].Pagada == false)
                    {
                        venta.CuotaDetalles[i].Balance -= pago.Monto;
                        break;
                    }
                }

                foreach (var item in venta.CuotaDetalles)
                {
                    venta.Balance += item.Balance;
                }


                contexto.PagoVentas.Add(pago);
                paso = contexto.SaveChanges() > 0;

                VentasBLL.Modificar(venta);
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

        public static bool Modificar(PagoVentas pago)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(pago).State = EntityState.Modified;
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
                var aux = contexto.PagoVentas.Find(id);
                if (aux != null)
                {
                    contexto.PagoVentas.Remove(aux);//remueve la informacion de la entidad relacionada
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

        public static PagoVentas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            PagoVentas pagoVentas;

            try
            {
                pagoVentas = contexto.PagoVentas.Where(v => v.PagoVentaId == id)
                    .Include(v => v.PagoDetalles)
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
            return pagoVentas;
        }

        public static List<PagoVentas> GetList(Expression<Func<PagoVentas, bool>> expression)
        {
            List<PagoVentas> lista = new List<PagoVentas>();
            Contexto db = new Contexto();

            try
            {
                lista = db.PagoVentas.Where(expression).ToList();
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
                encontrado = contexto.PagoVentas.Any(p => p.PagoVentaId == id);
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
