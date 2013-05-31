using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.DTO
{
    public class SitioListadoDTO
    {
        [Display(Name = "Identificador del sitio")]
        public int Id { get; set; }
        [Display(Name = "Nombre del sitio")]
        public string Nombre { get; set; }
        [Display(Name = "Dominio")]
        public string URL { get; set; }
        [Display(Name = "Tipo de Bien")]
        public String NombreTipoBien { get; set; }
    }
}
