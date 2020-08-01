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

        public int RentaId { get; set; }

        public int UsuarioId { get; set; }

        [Range(0, 100000000, ErrorMessage = "El campo monto no puede ser menor que cero")]
        [Required(ErrorMessage = "El campo Moton no debe estar vació")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El campo Balance no debe estar vació")]
        [Range(0, 100000000, ErrorMessage = "El campo balance no puede ser menor que cero")]
        public decimal Balance { get; set; }

        [Required(ErrorMessage = "No puede estar vació")]
        public bool Pagada { get; set; }

        [Required(ErrorMessage = "El campo numero no debe estar vació")]
        [Range(0, 100000000, ErrorMessage = "El campo dias no puede ser menor que cero")]
        public int Dias { get; set; }

     
        public PagoDetalles()
        {
            PagoId = 0;         
            RentaId = 0;
            Monto = 0.0m;
            Dias = 0;
            Pagada = false;
        }

        public PagoDetalles(int pagoId, int rentaId, int usuarioId, decimal monto, decimal balance, bool pagada, int dias)
        {
            PagoId = pagoId;
            RentaId = rentaId;
            UsuarioId = usuarioId;
            Monto = monto;
            Balance = balance;
            Pagada = pagada;
            Dias = dias;
        }
    }
}
