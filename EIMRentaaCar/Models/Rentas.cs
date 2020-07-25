using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EIMRentaaCar.Models
{
    public class Rentas
    {
        [Key]       
        [Range(0, 100000000, ErrorMessage = "El campo Id no puede ser menor que cero")]
        public int RentaId { get; set; }
   
        public int VehiculoId { get; set; }

        public int ClienteId { get; set; }

        public int UsuarioId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd,mm,yyyy}")]
        public DateTime FechaRenta { get; set; }

        [Required(ErrorMessage = "El campo Tiempo de renta no debe estar vació")]
        [Range(1, 30, ErrorMessage = "La Renta debe de ser 1 a 30 Dias!!!!  Despues de la fecha, debe de hacer una nueva Renta")]     
        public int TiempoRenta { get; set; }

        public decimal  Balance { get; set; }

        [ForeignKey("RentaId")]
        public virtual List<PagoDetalles> PagoDetalle { get; set; }

        public Rentas()
        {
            RentaId = 0;
            VehiculoId = 0;        
            FechaRenta = DateTime.Now;
            ClienteId = 0;
            TiempoRenta = 0;
            PagoDetalle = new List<PagoDetalles>();
        }
    }
}
