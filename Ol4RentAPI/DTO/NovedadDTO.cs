using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.DTO
{
    public class NovedadDTO
    {
        public string Proveedor { get; set; }
        public string Titulo { get; set; }
        [DataType(DataType.Html)]
        public string Contenido { get; set; }
        public string ContenidoRecortado { get; set; }
        public DateTime Fecha { get; set; }
    }
}
