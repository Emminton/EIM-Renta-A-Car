using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EIMRentaaCar.Models
{
    public class PagoRentas
    {
        [Key]
        [Required(ErrorMessage = "El campo Id debe ser un numero")]
        [Range(0, 100000000, ErrorMessage = "El campo Id no puede ser menor que cero")]
        public int PagoRentaId { get; set; }

        public int RentaId { get; set; }

        public int UsuarioId { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío.")]
        [DisplayFormat(DataFormatString = "{0:dd,mm,yyyy}")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo monto no debe estar vació")]  
        public decimal Monto { get; set; }
       
        public PagoRentas()
        {
            PagoRentaId = 0;
            RentaId = 0;
            Fecha = DateTime.Now;
            Monto = 0;
           
        }
    }
}
