using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.Facades
{
    public interface ISesionManager
    {
        void CrearSesion(string nombreUsuario);
        void ActualizarSesion(string nombreUsuario);
        void CerrarSesion(string nombreUsuario);
        bool TieneSesionValida(int idUsuario);
    }
}
