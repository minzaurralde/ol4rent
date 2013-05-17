using Ol4RentAPI.DTO;
using Ol4RentAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.Facades
{
    public interface IOrigenDatosFacade
    {
        List<ConfiguracionOrigenDatosEdicionDTO> ObtenerPorSitio(int idSitio);

        List<OrigenDatosListaDTO> ObtenerTodos();

        bool Crear(OrigenDatosAltaDTO dto);

        OrigenDatosEdicionDTO ObtenerParaEdicion(int id);

        bool Editar(OrigenDatosEdicionDTO dto);

        void Eliminar(int id);

        bool Configurar(ConfiguracionOrigenDatosAltaDTO dto);

        ConfiguracionOrigenDatosEdicionDTO ObtenerConfiguracionParaEdicion(int id);

        bool EditarConfiguracion(ConfiguracionOrigenDatosEdicionDTO dto);

        void EliminarConfiguracion(int id);

        List<AtributoEdicionDTO> ObtenerAtributos(int idOrigenDatos);

        OrigenDatos Obtener(int id);

        Atributo ObtenerAtributo(int id);
    }
}
