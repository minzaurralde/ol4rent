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
        List<Bien> BienesPopulares { get; }
        List<Bien> Todos { get; }
        Bien Obtener(int id);
        bool Crear(BienAltaDTO bien);
        Bien Editar(Bien bien);
        void Eliminar(int id);
        List<Bien> Buscar(string query);
        List<Bien> BusquedaAvanzada(Bien templateBien);
        List<Bien> Wishlist(Usuario usuario);
        List<Bien> MisBienes(Usuario usuario);
        BienEdicionDTO ObtenerBienParaContenido(int idContenido);
        List<ContenidoDTO> ContenidosInadecuadosPorSitio(int idSitio);
        RegistroBienDTO RegistroDeBienesEnTiempo(int idSitio, DateTime fechaInicio, DateTime fechaFin);
    }
}
