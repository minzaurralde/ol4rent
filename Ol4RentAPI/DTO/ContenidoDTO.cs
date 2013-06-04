using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.DTO
{
    public class ContenidoDTO
    {
        public int Id { get; set; }
        public string Mensaje { get; set; }
        public short CantMarcas { get; set; }
        public bool TieneAdjuntos { get; set; }
        public string NombreUsuario { get; set; }
        public BienEdicionDTO Bien { get; set; }
    }

    public class ComentarioAltaDTO
    {
        public int IdBien { get; set; }
        public string NombreUsuario { get; set; }
        public string Texto { get; set; }
        public List<AdjuntoDTO> Adjuntos { get; set; }
    }

    public class AdjuntoDTO
    {
        public string Nombre { get; set; }
        public byte[] Contenido { get; set; }
    }
}
