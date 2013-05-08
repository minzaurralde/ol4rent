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
        List<Novedad> Todas { get; }
        Novedad Obtener(int id);
        Novedad Crear(Novedad novedad);
        Novedad Editar(Novedad novedad);
        void Eliminar(int id);
        List<Novedad> ListaNovedades();
    }
}
