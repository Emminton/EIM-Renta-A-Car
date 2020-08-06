using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EIMRentaaCar.Models
{
    public class Clientes
    {
        [Key]
        [Required(ErrorMessage = "El campo ID no puede estar vació.")]
        [Range(0, 1000000, ErrorMessage = "El campo ID no puede ser menor que 1 o mayor que 1000000.")]
        public int ClienteId { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "El campo nombre no puede estar vació.")]
        [MinLength(3, ErrorMessage = "El campo lo minimo debe terner 3 caracteres.")]
        [MaxLength(40, ErrorMessage = "El nombre es muy largo.")]
        [RegularExpression(@"\S(.*)\S", ErrorMessage = "Debe ser un texto.")]
        public string Nombre { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío.")]
        [DisplayFormat(DataFormatString = "{0:dd,mm,yyyy}")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo cedula no debe estar vació.")]
        [MinLength(11, ErrorMessage = "El Campo Cedula debe contener 11 Caracteres.")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El campo Teléfono no debe de estar vació.")]
        [Phone(ErrorMessage = "Debes de ingresar tu número telefonico.")]
        [MinLength(10, ErrorMessage = "El campo telefono no puede tener minimo de diez dígitos.")]
        [MaxLength(10, ErrorMessage = "El campo telefono tiene más de diez dígitos.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Dirección no debe de estar vació.")]
        [MinLength(10, ErrorMessage = "La dirección es muy corta.")]
        [MaxLength(100, ErrorMessage = "La dirección debe contener menos de 40 caracteres.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo Email no debe estar vació.")]
        [EmailAddress(ErrorMessage = "Ingrese una dirección de Email correcto .")]
        public string Email { get; set; }

        public Clientes()
        {
            ClienteId = 0;
            UsuarioId = 0;
            Nombre = string.Empty;
            Cedula = string.Empty;
            Email = string.Empty;
            Direccion = string.Empty;
            FechaNacimiento = DateTime.Now.Date;
            Telefono = string.Empty;
        }

        public Clientes(int clienteId, int usuarioId, string nombre, DateTime fechaNacimiento, string cedula, string telefono, string direccion, string email)
        {
            ClienteId = clienteId;
            UsuarioId = usuarioId;
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            FechaNacimiento = fechaNacimiento;
            Cedula = cedula ?? throw new ArgumentNullException(nameof(cedula));
            Telefono = telefono ?? throw new ArgumentNullException(nameof(telefono));
            Direccion = direccion ?? throw new ArgumentNullException(nameof(direccion));
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }
    }
}
