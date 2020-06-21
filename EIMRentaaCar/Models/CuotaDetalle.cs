using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EIMRentaaCar.Models
{
    public class CuotaDetalles
    {
        [Key]
        [Required(ErrorMessage = "El campo Id debe ser un numero")]
        [Range(0, 100000000, ErrorMessage = "El campo Id no puede ser menor que cero")]
        public int CuotaId { get; set; }

        [ForeignKey("VentaId")]
        public int VentaId { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "El campo Moton no debe estar vació")]
        [RegularExpression("^[0-9]", ErrorMessage = "Debe ser numeros")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El campo Balance no debe estar vació")]
        [RegularExpression("^[0-9]", ErrorMessage = "Debe ser numeros")]
        public decimal Balance { get; set; }

        [Required(ErrorMessage ="No puede estar vació")]
        public bool Pagada { get; set; }

        [Required(ErrorMessage = "El campo numero no debe estar vació")]
        [RegularExpression("^[0-9]", ErrorMessage = "Debe ser numeros")]
        public int Numero { get; set; }

        public CuotaDetalles()
        {
            CuotaId = 0;
            VentaId = 0;
            UsuarioId = 0;
            Monto = 0.0m;
            Balance = 0.0m;
            Pagada = false;
            Numero = 0;
        }

    }
}
