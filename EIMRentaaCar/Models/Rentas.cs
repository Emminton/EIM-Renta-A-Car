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
        public int UsuarioId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Vin { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío.")]
        [DisplayFormat(DataFormatString = "{0:dd,mm,yyyy}")]
        public DateTime FechaRenta { get; set; }

        [Required(ErrorMessage = "El campo Tiempo de renta no debe estar vació")]
        [MinLength(1, ErrorMessage = "El campo lo minimo debe terner 3 caracteres.")]
        [MaxLength(30, ErrorMessage = "El nombre es muy largo.")]
        public int TiempoRenta { get; set; }
        public string Nombre { get; set; }
        public decimal  Balance { get; set; }


        public Rentas()
        {
            RentaId = 0;
            VehiculoId = 0;
            Marca = string.Empty;
            Modelo = string.Empty;
            FechaRenta = DateTime.Now;
            ClienteId = 0;
            TiempoRenta = 0;
            Vin = 0;
            Nombre = string.Empty;
        }
    }
}
