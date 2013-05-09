using Ol4RentAPI.DTO;
using Ol4RentAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.Facades
{
    public interface ISitioFacade
    {
        List<Sitio> Todos { get; }
        Sitio Obtener(int id);
        /// <summary>
        /// Crea un nuevo sitio en el portal OL4RENT
        /// </summary>
        /// <param name="sitioDTO">DTO con los datos del sitio que se creará</param>
        /// <returns><code>true</code> si se creó exitosamente el sitio, <code>false</code> en caso contrario.</returns>
        bool Crear(SitioAltaDTO sitio);
        Sitio Editar(Sitio sitio);
        void Eliminar(int id);
        byte[] Logo(int id);
    }
}
