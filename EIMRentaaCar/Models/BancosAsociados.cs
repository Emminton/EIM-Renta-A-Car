using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EIMRentaaCar.Models
{
    public class BancosAsociados
    {
        [Key]
        [Required(ErrorMessage = "El campo Id debe ser un numero")]
        [Range(0, 100000000, ErrorMessage = "El campo Id no puede ser menor que cero")]
        public int BancoAsociadoId { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "El campo nombre no puede estar vació.")]
        [MinLength(3, ErrorMessage = "El campo lo minimo debe terner 3 caracteres.")]
        [MaxLength(30, ErrorMessage = "El nombre es muy largo.")]
        [RegularExpression(@"\S(.*)\S", ErrorMessage = "Debe ser un texto.")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo Teléfono no debe de estar vació.")]
        [Phone(ErrorMessage = "Debes de ingresar tu número telefonico.")]
        [MaxLength(10, ErrorMessage = "El campo telefono no tiene más de diez dígitos.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Email no debe estar vació.")]
        [EmailAddress(ErrorMessage = "Ingrese su dirección de Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage ="No puede estar vació")]
        [Url(ErrorMessage ="debe ser una url")]
        public string PaginaWeb { get; set; }
        public BancosAsociados()
        {
            BancoAsociadoId = 0;
            UsuarioId = 0;
            Nombres = string.Empty;
            Telefono = string.Empty;
            Email = string.Empty;
            PaginaWeb = string.Empty;
        }
    }
}
