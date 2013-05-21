using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.DTO
{
    class TipoBienDTO
    {
        public TipoBienDTO()
        {
            this.Caracteristicas = new HashSet<CaracteristicaAltaDTO>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
    
        public virtual SitioListadoDTO Sitio { get; set; }
        public virtual ICollection<CaracteristicaAltaDTO> Caracteristicas { get; set; }
    }
}
