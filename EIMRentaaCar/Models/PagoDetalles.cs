using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EIMRentaaCar.Models
{
    public class PagoDetalles
    {
        [Key]
        [Required(ErrorMessage = "El campo Id debe ser un numero")]
        [Range(0, 100000000, ErrorMessage = "El campo Id no puede ser menor que cero")]
        public int PagoId { get; set; }

        [ForeignKey("PagoRentaId")]
        public int PagoRentaId { get; set; }

        [ForeignKey("PagoVentaId")]
        public int PagoVentaId { get; set; }

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío.")]
        [DisplayFormat(DataFormatString = "{0:dd,mm,yyyy}")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage ="El campo monto no debe estar vació")]
        [RegularExpression("^[0-9]",ErrorMessage ="Debe ser numeros")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El campo cuota no debe estar vació")]
        [RegularExpression("^[0-9]", ErrorMessage = "Debe ser numeros")]
        public decimal Cuotas { get; set; }

        public PagoDetalles()
        {
            PagoId = 0;
            PagoRentaId = 0;
            PagoVentaId = 0;
            ClienteId = 0;
            Fecha = DateTime.Now;
            Monto = 0.0m;
            Cuotas = 0.0m;
        }
    }
}
