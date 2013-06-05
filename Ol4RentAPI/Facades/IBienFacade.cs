using Ol4RentAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.Facades
{
    public interface IBienFacade
    {
        List<BienListadoDTO> BienesPopulares();
        List<BienListadoDTO> Todos();
        BienEdicionDTO Obtener(int id);
        BienArrendarDTO ObtenerArrendar(int id);
        bool Arrendar(BienArrendarDTO bienDTO, string usuario);
        bool Crear(BienAltaDTO bien);
        bool Editar(BienEdicionDTO bienDTO);
        void Eliminar(int id);
        List<BienListadoDTO> Buscar(string query);
        List<BienListadoDTO> MisBienes(string usuario, int sitio);
        BienEdicionDTO ObtenerBienParaContenido(int idContenido);
        List<ContenidoDTO> ContenidosInadecuadosPorSitio(int idSitio);
        RegistroBienDTO RegistroDeBienesEnTiempo(int idSitio, DateTime fechaInicio, DateTime fechaFin);
        List<BienListadoDTO> BusquedaAvanzada(BusquedaAvanzadaDTO templateBien);

        void Like(string nombreUsuario, int idBien);
        byte[] Foto(int idBien);
        List<ContenidoDTO> ObtenerComentariosBien(int idBien);
    }
}
