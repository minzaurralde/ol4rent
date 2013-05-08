using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OL4RENT.DatosExternosDACAPI
{
    interface IProveedorNoticias
    {
        List<NovedadExternaDTO> ObtenerNovedades(int cantidad);
    }
}
