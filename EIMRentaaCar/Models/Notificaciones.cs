using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EIMRentaaCar.Models
{
    public class Notificaciones
    {
        [Key]
        [Required(ErrorMessage = "El campo Id debe ser un numero")]
        [Range(0, 100000000, ErrorMessage = "El campo Id no puede ser menor que cero")]
        public int NotificacionId { get; set; }
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "El campo nombre no puede estar vació.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "El campo nombre no puede estar vació.")]
        public string Asunto { get; set; }
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío.")]
        [DisplayFormat(DataFormatString = "{0:dd,mm,yyyy}")]
        public DateTime Fecha { get; set; }

        public Notificaciones()
        {
            NotificacionId = 0;
            UsuarioId = 0;
            Titulo = string.Empty;
            Asunto = string.Empty;
            Fecha = DateTime.Now;
        }

        public Notificaciones(int notificacionId, int usuarioId, string titulo, string asunto, DateTime fecha)
        {
            NotificacionId = notificacionId;
            UsuarioId = usuarioId;
            Titulo = titulo ?? throw new ArgumentNullException(nameof(titulo));
            Asunto = asunto ?? throw new ArgumentNullException(nameof(asunto));
            Fecha = fecha;
        }
    }
}
