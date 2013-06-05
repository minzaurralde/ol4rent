using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.DTO
{
    public class BusquedaAvanzadaDTO
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string CapacidadMinima { get; set; }
        public string CapacidadMaxima { get; set; }
        public string Normas { get; set; }
        public string PrecioMinimo { get; set; }
        public string PrecioMaximo { get; set; }
        public List<ValorCaracteristicaAltaDTO> ValoresCaracteristicas { get; set; }
    }
}
