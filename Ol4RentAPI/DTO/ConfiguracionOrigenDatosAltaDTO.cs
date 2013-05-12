using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.DTO
{
    public class ConfiguracionOrigenDatosAltaDTO
    {
        public int IdSitio { get; set; }
        public int IdOrigenDatos { get; set; }
        public List<ValorAtributoAltaDTO> ValoresAtributo { get; set; }
    }

    public class ConfiguracionOrigenDatosEdicionDTO 
    {
        public int Id { get; set; }
        public int IdSitio { get; set; }
        public string NombreSitio { get; set; }
        public int IdOrigenDatos { get; set; }
        public string NombreOrigenDatos { get; set; }
        public List<ValorAtributoEdicionDTO> ValoresAtributo { get; set; }
    }
}
