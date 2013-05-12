using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.DTO
{
    public class ValorAtributoAltaDTO
    {
        public string Valor { get; set; }
        public int IdAtributo { get; set; }
        public string NombreAtributo { get; set; }
    }

    public class ValorAtributoEdicionDTO
    {
        public int Id { get; set; }
        public string Valor { get; set; }
        public int IdAtributo { get; set; }
        public string NombreAtributo { get; set; }
    }
}
