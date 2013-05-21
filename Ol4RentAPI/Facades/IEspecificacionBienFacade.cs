using Ol4RentAPI.DTO;
using Ol4RentAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.Facades
{
    public interface IEspecificacionBienFacade
    {
        List<EspecificacionBien> Todos { get; }
        EspecificacionBien Obtener(int id);
        bool Crear(EspecificacionBienDTO w);
        bool Editar(EspecificacionBienDTO w);
        void Eliminar(int id);
        List<EspecificacionBienListadoDTO> Wishlist(string usuario, string tipoBien);
    }
}
