using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EIMRentaaCar.Models
{
    public class Ventas
    {
		[Key]
		[Required(ErrorMessage = "El campo Id debe ser un numero")]
		[Range(0, 100000000, ErrorMessage = "El campo Id no puede ser menor que cero")]
		public int VentaId { get; set; }
		[Required(ErrorMessage = "El campo cliente no debe estar vació")]
		public int ClienteId { get; set; }
		[Required(ErrorMessage = "El campo vehiculo no debe estar vació")]
		public int VehiculoId { get; set; }
        public int UsuarioId { get; set; }
		[Range(0, 100000000, ErrorMessage = "El campo cuotas no puede ser menor que cero")]
		public int Cuotas { get; set; }

		[Range(0, 100000000, ErrorMessage = "El campo monto total no puede ser menor que cero")]
		[Required(ErrorMessage = "El campo Monto total no debe estar vació")]
		public decimal MontoTotal { get; set; }

		[Required(ErrorMessage = "El campo Balance no debe estar vació")]
		[Range(0, 100000000, ErrorMessage = "El campo balance no puede ser menor que cero")]
		public decimal Balance { get; set; }

		[Required(ErrorMessage = "El campo Moton cuotas no debe estar vació")]
		[Range(0, 100000000, ErrorMessage = "El campo Monto no puede ser menor que cero")]
		public decimal MontoCuotas { get; set; }

		[DataType(DataType.DateTime)]
		[Required(ErrorMessage = "El campo fecha no puede estar vacío.")]
		[DisplayFormat(DataFormatString = "{0:dd,mm,yyyy}")]
		public DateTime FechaVenta { get; set; }
	
		[ForeignKey("VentaId")]
		public virtual List<CuotaDetalles> CuotaDetalles { get; set; }

		public Ventas()
		{
			VentaId = 0;
			ClienteId = 0;
			VehiculoId = 0;
			Cuotas = 0;
			MontoTotal = 0.0m;
			Balance = 0.0m;
			MontoCuotas = 0.0m;
			FechaVenta = DateTime.Now;
			CuotaDetalles = new List<CuotaDetalles>();
		}

        public Ventas(int ventaId, int clienteId, int vehiculoId, int usuarioId, int cuotas, decimal montoTotal, decimal balance, decimal montoCuotas, DateTime fechaVenta, List<CuotaDetalles> cuotaDetalles)
        {
            VentaId = ventaId;
            ClienteId = clienteId;
            VehiculoId = vehiculoId;
            UsuarioId = usuarioId;
            Cuotas = cuotas;
            MontoTotal = montoTotal;
            Balance = balance;
            MontoCuotas = montoCuotas;
            FechaVenta = fechaVenta;
            CuotaDetalles = cuotaDetalles ?? throw new ArgumentNullException(nameof(cuotaDetalles));
        }
    }
}
