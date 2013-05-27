using OL4RENT.DatosExternosDACAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace OL4RENTServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INovedadesService" in both code and config file together.
    [ServiceContract]
    public interface INovedadesService
    {
        [OperationContract]
        [WebGet(UriTemplate="/Novedades/{idSitio}", RequestFormat = WebMessageFormat.Json,
                                                     ResponseFormat = WebMessageFormat.Json
                                                     )]
        List<NovedadExternaDTO> ObtenerNovedadesPorSitio(string idSitio);
    }
}
