using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMRentaaCar.Models
{
    public class Usuarios
    {
        [Key]
        [Required(ErrorMessage = "El campo Id debe ser un numero")]
        [Range(0, 100000000, ErrorMessage = "El campo Id no puede ser menor que cero")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "El Nombre  no puede estar vacío")]
        [MinLength(2, ErrorMessage = "El Nombre  muy corto")]
        [MaxLength(50, ErrorMessage = "Nombre  muy largo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Email  no puede estar vacío")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El nombre de usuario no puede estar vacio")]
        [MinLength(3, ErrorMessage = "Nombre de usuario muy corto")]
        [MaxLength(30, ErrorMessage = "Nombre de usuario muy largo")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "El Clave no puede estar vacío")]
        [MinLength(2, ErrorMessage = "El Clave muy corto")]
        [MaxLength(60, ErrorMessage = "Clave muy largo")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El Confirmar Clave no puede estar vacío")]
        [MinLength(2, ErrorMessage = "El Confirmar Clave es muy corto")]
        [MaxLength(60, ErrorMessage = "ConfirmarClave muy largo")]
        public string ConfirmarPassword { get; set; }

        [Required(ErrorMessage = "El Nivel Usuario no puede estar vacío")]
        public string Roles { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío")]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        public DateTime FechaIngreso { get; set; }
        public Usuarios()
        {
            UsuarioId = 0;
            Nombre = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            ConfirmarPassword = string.Empty;
            Roles = string.Empty;
            FechaIngreso = DateTime.Now;
            UserName = string.Empty;
        }

        public Usuarios(int usuarioId, string nombre, string email, string userName, string password, string confirmarPassword, string roles, DateTime fechaIngreso)
        {
            UsuarioId = usuarioId;
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            ConfirmarPassword = confirmarPassword ?? throw new ArgumentNullException(nameof(confirmarPassword));
            Roles = roles ?? throw new ArgumentNullException(nameof(roles));
            FechaIngreso = fechaIngreso;
        }
    }
}
