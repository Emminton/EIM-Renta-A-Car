using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EIMRentaaCar.Models
{
    public class Paginacion
    {
        public int Pagina { get; set; } = 1;
        public int CantidadMostrar { get; set; } = 5;
    }
}
