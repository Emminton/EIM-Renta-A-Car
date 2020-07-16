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

		[ForeignKey("ClienteId")]
		public int ClienteId { get; set; }

		[ForeignKey("VehiculoId")]
		public int VehiculoId { get; set; }

		public int Cuotas { get; set; }

		[Required(ErrorMessage = "El campo Monto total no debe estar vació")]
		public decimal MontoTotal { get; set; }

		[Required(ErrorMessage = "El campo Balance no debe estar vació")]
		public decimal Balance { get; set; }

		[Required(ErrorMessage = "El campo Moton cuotas no debe estar vació")]
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
	}
}
