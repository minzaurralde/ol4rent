using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.DTO
{
    public class RegistroBienDTO
    {
        public string Tipo { get; set; }
        public List<ValorRegistroBienDTO> Valores { get; set; }
    }

    public class ValorRegistroBienDTO
    {
        public string Etiqueta { get; set; }
        public int Cantidad { get; set; }
    }
}
