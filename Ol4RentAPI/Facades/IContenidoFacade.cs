using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ol4RentAPI.DTO;
using Ol4RentAPI.Model;

namespace Ol4RentAPI.Facades
{
    public interface IContenidoFacade
    {
        ContenidoDTO Obtener(int id);
        void MarcarInadecuado(int id);
        void Eliminar(int id);
        void Agregar(ComentarioAltaDTO dto);
    }
}
