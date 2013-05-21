using Ol4RentAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.Facades
{
    public interface IMensajeFacade
    {
        List<MensajeDTO> ObtenerMensajesNoLeidos(int idUsuario);

        void MarcarComoLeido(int id);

        void EnviarMensaje(int idUsuario, int idRemitente, string textoMensaje);
    }
}
