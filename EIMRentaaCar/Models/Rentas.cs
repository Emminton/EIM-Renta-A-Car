using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public int RentaId { get; set; }


        public int VehiculoId { get; set; }

        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
 

        public DateTime FechaRenta { get; set; }
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
            Balance = 0;
            PagoDetalle = new List<PagoDetalles>();
        }
    }
}
