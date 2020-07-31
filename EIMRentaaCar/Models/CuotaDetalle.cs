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

        public int VentaId { get; set; }

        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "El campo Moton no debe estar vació")]
        [Range(0, 100000000, ErrorMessage = "El campo motnto no puede ser menor que cero")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El campo Balance no debe estar vació")]
        [Range(0, 100000000, ErrorMessage = "El campo balance no puede ser menor que cero")]
        public decimal Balance { get; set; }

        [Required(ErrorMessage ="No puede estar vació")]
        public bool Pagada { get; set; }

        [Range(0, 100000000, ErrorMessage = "El campo numero no puede ser menor que cero")]
        [Required(ErrorMessage = "El campo numero no debe estar vació")]
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

        public CuotaDetalles(int cuotaId, int ventaId, int usuarioId, decimal monto, decimal balance, bool pagada, int numero)
        {
            CuotaId = cuotaId;
            VentaId = ventaId;
            UsuarioId = usuarioId;
            Monto = monto;
            Balance = balance;
            Pagada = pagada;
            Numero = numero;
        }
    }
}
