using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EIMRentaaCar.Models
{
    public class Importadores
    {
        [Key]
        [Required(ErrorMessage = "El campo Id debe ser un numero")]
        [Range(0, 100000000, ErrorMessage = "El campo Id no puede ser menor que cero")]
        public int ImportadorId { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "El campo nombre no puede estar vació.")]
        [MinLength(3, ErrorMessage = "El campo lo minimo debe terner 3 caracteres.")]
        [MaxLength(30, ErrorMessage = "El nombre es muy largo.")]
        [RegularExpression(@"\S(.*)\S", ErrorMessage = "Debe ser un texto.")]
        public string Nombre { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío.")]
        [DisplayFormat(DataFormatString = "{0:dd,mm,yyyy}")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo Teléfono no debe de estar vació.")]
        [Phone(ErrorMessage = "Debes de ingresar tu número telefonico.")]
        [MaxLength(10, ErrorMessage = "El campo telefono no tiene más de diez dígitos.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Email no debe estar vació.")]
        [EmailAddress(ErrorMessage = "Ingrese un Email Valido.")]
        public string Email { get; set; }
      
        public Importadores()
        {
            ImportadorId = 0;
            UsuarioId = 0;
            Nombre = string.Empty;
            Fecha = DateTime.Now;
            Telefono = string.Empty;
            Email = string.Empty;
        }

        public Importadores(int importadorId, int usuarioId, string nombre, DateTime fecha, string telefono, string email)
        {
            ImportadorId = importadorId;
            UsuarioId = usuarioId;
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Fecha = fecha;
            Telefono = telefono ?? throw new ArgumentNullException(nameof(telefono));
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }
    }
}
