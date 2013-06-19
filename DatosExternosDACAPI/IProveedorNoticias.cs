using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OL4RENT.DatosExternosDACAPI
{
    public interface IProveedorNoticias
    {
        List<NovedadExternaDTO> ObtenerNovedades(int cantidad);

        void Configurar(Hashtable properties, string filtro, string nombre);
    }
}
