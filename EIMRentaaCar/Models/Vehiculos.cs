using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EIMRentaaCar.Models
{
    public class Vehiculos
    {
        [Key]
        [Required(ErrorMessage = "El campo Id debe ser un numero")]
        [Range(0, 100000000, ErrorMessage = "El campo Id no puede ser menor que cero")]
        public int VehiculoId { get; set; }
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "El campo tipo no puede estar vacio")]
        [RegularExpression(@"\S(.*)\S", ErrorMessage = "Debe ser un texto.")]
        public string Estado { get; set; }

        [Required(ErrorMessage ="El campo tipo no puede estar vacio")]
        [RegularExpression(@"\S(.*)\S", ErrorMessage = "Debe ser un texto.")]
        public string Tipo { get; set; }

        [Required(ErrorMessage ="No puede estar vació el campo modelo")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "No puede estar vació el campo marca")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "No puede estar vació el campo VIN")]
        public string Vin { get; set; }

        [Required(ErrorMessage = "No puede estar vació el campo año")]
        [Range(0, 100000000, ErrorMessage = "El campo año no puede ser menor que cero")]
        public int Año { get; set; }

        [Range(0, 100000000, ErrorMessage = "El campo precio de venta no puede ser menor que cero")]
        [Required(ErrorMessage = "No puede estar vació el campo precio de venta")]
        public decimal PrecioVenta { get; set; }

        [Range(0, 100000000, ErrorMessage = "El campo precio de venta no puede ser menor que cero")]
        public double ITBIS { get; set; } 

        [Range(0, 100000000, ErrorMessage = "El campo precio por dia no puede ser menor que cero")]
        [Required(ErrorMessage = "No puede estar vació el campo precio por dia")]
        public decimal PrecioPorDia { get; set; }

        [Range(0, 100000000, ErrorMessage = "El campo kilometraje no puede ser menor que cero")]
        [Required(ErrorMessage = "No puede estar vació el campo Kilometraje")]
        public int Kilometraje { get; set; }
        public int ImportadorId { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío.")]
        [DisplayFormat(DataFormatString = "{0:dd,mm,yyyy}")]
        public DateTime Fecha { get; set; }

        public Vehiculos()
        {
            VehiculoId = 0;
            UsuarioId = 0;
            Estado =string.Empty;
            Tipo = string.Empty;
            Modelo = string.Empty;
            Marca = string.Empty;
            Vin = string.Empty;
            Año = 0;
            PrecioVenta = 0.0m;
            ITBIS = 0.0;
            PrecioPorDia = 0.0m;
            Kilometraje = 0;
            ImportadorId = 0;
            Fecha = DateTime.Now;
        }

        public Vehiculos(int vehiculoId, int usuarioId, string estado, string tipo, string modelo, string marca, string vin, int año, decimal precioVenta, double itbis, decimal precioPorDia, int kilometraje, int importadorId, DateTime fecha)
        {
            VehiculoId = vehiculoId;
            UsuarioId = usuarioId;
            Estado = estado;
            Tipo = tipo ?? throw new ArgumentNullException(nameof(tipo));
            Modelo = modelo ?? throw new ArgumentNullException(nameof(modelo));
            Marca = marca ?? throw new ArgumentNullException(nameof(marca));
            Vin = string.Empty;
            Año = año;
            PrecioVenta = precioVenta;
            ITBIS = itbis;
            PrecioPorDia = precioPorDia;
            Kilometraje = kilometraje;
            ImportadorId = importadorId;
            Fecha = fecha;
        }
    }
}
