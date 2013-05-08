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
        Sitio Crear(Sitio sitio);
        Sitio Editar(Sitio sitio);
        void Eliminar(int id);
        private byte[] Logo(int id);
    }
}
