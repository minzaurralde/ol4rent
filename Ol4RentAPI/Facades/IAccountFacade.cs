using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ol4RentAPI.Model;

namespace Ol4RentAPI.Facades
{
    public interface IAccountFacade
    {
        List<Usuario> Todos { get; }
        Usuario Obtener(int id);
        Usuario ObtenerPorNombre(string NombreUsuario);
        Usuario Crear(Usuario usuario);
        Usuario Editar(Usuario usuario);
        void Eliminar(int id);
    }
}
