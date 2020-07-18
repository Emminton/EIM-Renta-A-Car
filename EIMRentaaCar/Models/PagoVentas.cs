using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EIMRentaaCar.Models
{
    public class PagoVentas
    {
        [Key]
        [Required(ErrorMessage = "El campo Id debe ser un numero")]
        [Range(0, 100000000, ErrorMessage = "El campo Id no puede ser menor que cero")]
        public int PagoVentaId { get; set; }

        [ForeignKey("VentaId")]
        public int VentaId { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío.")]
        [DisplayFormat(DataFormatString = "{0:dd,mm,yyyy}")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo monto no debe estar vació")]
        public decimal Monto { get; set; }

        [ForeignKey("PagoVentaId")]
        public virtual List<PagoDetalles> PagoDetalles { get; set; }

        public PagoVentas()
        {
            PagoVentaId = 0;
            VentaId = 0;
            UsuarioId = 0;
            Fecha = DateTime.Now;
            Monto = 0.0m;
            PagoDetalles = new List<PagoDetalles>();
        }
    }
}
