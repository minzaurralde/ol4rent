using OL4RENT.DatosExternosDACAPI;
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

    public class NovedadListadoDTO: NovedadExternaDTO
    {
        public int Id { get; set; }
        public int Prioridad { get; set; }
    }

    public class NovedadAltaDTO
    {
        [Display(Name="Titulo de la novedad")]
        public string Titulo { get; set; }
        [Display(Name = "Contenido")]
        public string Contenido { get; set; }
        [Display(Name = "Fecha y hora")]
        public DateTime FechaHora { get; set; }
        [Display(Name = "Prioridad")]
        public int Prioridad { get; set; }
        [Display(Name = "Origen de datos")]
        public int IdConfiguracionOrigenDeDatos { get; set; }
    }

    public class NovedadEdicionDTO
    {
        public int Id { get; set; }
        [Display(Name = "Titulo de la novedad")]
        public string Titulo { get; set; }
        [Display(Name = "Contenido")]
        public string Contenido { get; set; }
        [Display(Name = "Fecha y hora")]
        public DateTime FechaHora { get; set; }
        [Display(Name = "Prioridad")]
        public int Prioridad { get; set; }
        [Display(Name = "Origen de datos")]
        public int IdConfiguracionOrigenDeDatos { get; set; }
    }
}
