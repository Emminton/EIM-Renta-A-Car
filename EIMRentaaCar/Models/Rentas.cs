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
        [Required(ErrorMessage = "El campo Id debe ser un numero")]
        [Range(0, 100000000, ErrorMessage = "El campo Id no puede ser menor que cero")]
        public int RentaId { get; set; }

        [ForeignKey("VehiculoId")]
        public int VehiculoId { get; set; }

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage ="No puede estar vació el campo marca")]
        [RegularExpression(@"\S(.*)\S", ErrorMessage = "Debe ser un texto.")]
        public string Marca { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío.")]
        [DisplayFormat(DataFormatString = "{0:dd,mm,yyyy}")]
        public DateTime FechaRenta { get; set; }

        [Required(ErrorMessage = "El campo Tiempo de renta no debe estar vació")]
        //[RegularExpression("^[0-9]", ErrorMessage = "Debe ser numeros")]
        public int TiempoRenta { get; set; }


        public Rentas()
        {
            RentaId = 0;
            VehiculoId = 0;
            Marca = string.Empty;
            FechaRenta = DateTime.Now;
            ClienteId = 0;
            TiempoRenta = 0;

        }
    }
}
