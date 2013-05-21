using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.DTO
{
    public class MensajeDTO
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public DateTime FechaHora { get; set; }
        public UsuarioDTO Remitente { get; set; }
    }
}
