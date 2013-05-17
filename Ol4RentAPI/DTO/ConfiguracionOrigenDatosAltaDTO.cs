using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.DTO
{
    public class ConfiguracionOrigenDatosAltaDTO
    {
        [Required(ErrorMessage = "El Sitio es un campo obligatorio.")]
        public int IdSitio { get; set; }
        [Required(ErrorMessage = "El Origen de Datos es un campo obligatorio.")]
        public int IdOrigenDatos { get; set; }
        [Display(Name = "Propiedades")]
        public List<ValorAtributoAltaDTO> ValoresAtributo { get; set; }
    }

    public class ConfiguracionOrigenDatosEdicionDTO 
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Sitio es un campo obligatorio.")]
        public int IdSitio { get; set; }
        public string NombreSitio { get; set; }
        [Required(ErrorMessage = "El Origen de Datos es un campo obligatorio.")]
        public int IdOrigenDatos { get; set; }
        public string NombreOrigenDatos { get; set; }
        public List<ValorAtributoEdicionDTO> ValoresAtributo { get; set; }
    }
}
