using Ol4RentAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.Facades
{
    public interface IOrigenDatosFacade
    {
        List<OrigenDatosListaDTO> ObtenerPorSitio(int idSitio);

        List<OrigenDatosListaDTO> ObtenerTodos();

        bool Crear(OrigenDatosAltaDTO dto);

        OrigenDatosEdicionDTO ObtenerParaEdicion(int id);

        bool Editar(OrigenDatosEdicionDTO dto);

        void Eliminar(int id);

        bool Configurar(ConfiguracionOrigenDatosAltaDTO dto);

        ConfiguracionOrigenDatosEdicionDTO ObtenerConfiguracionParaEdicion(int idSitio, int idOrigenDatos);

        bool EditarConfiguracion(ConfiguracionOrigenDatosEdicionDTO dto);

        void EliminarConfiguracion(int idSitio, int idOrigenDatos);

        List<AtributoEdicionDTO> ObtenerAtributos(int idOrigenDatos);
    }
}
