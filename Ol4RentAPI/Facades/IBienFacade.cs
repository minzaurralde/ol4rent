using Ol4RentAPI.DTO;
using Ol4RentAPI.Model;
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
        bool Crear(BienAltaDTO bien);
        bool Editar(BienEdicionDTO bien);
        void Eliminar(int id);
        List<Bien> Buscar(string query);
        List<BienListadoDTO> MisBienes(string usuario, int sitio);
        BienEdicionDTO ObtenerBienParaContenido(int idContenido);
        List<ContenidoDTO> ContenidosInadecuadosPorSitio(int idSitio);
        RegistroBienDTO RegistroDeBienesEnTiempo(int idSitio, DateTime fechaInicio, DateTime fechaFin);
        List<Model.Bien> BusquedaAvanzada(Model.Bien templateBien);
        byte[] Foto(int idBien);
        List<ContenidoDTO> ObtenerComentariosBien(int idBien);
    }
}
