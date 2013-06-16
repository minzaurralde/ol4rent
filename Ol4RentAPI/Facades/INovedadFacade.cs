using OL4RENT.DatosExternosDACAPI;
using Ol4RentAPI.DTO;
using Ol4RentAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.Facades
{
    public interface INovedadFacade
    {
        List<NovedadDTO> ListaNovedades();

        List<NovedadExternaDTO> ObtenerNovedadesPorSitio(int idSitio);

        List<NovedadListadoDTO> ObtenerNovedadesParaBOPorSitio(int idSitio);

        void Crear(NovedadAltaDTO dto);

        void Eliminar(int id);

        NovedadEdicionDTO ObtenerNovedadParaEdicion(int id);

        void Editar(NovedadEdicionDTO dto);
    }
}
