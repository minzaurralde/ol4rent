using OL4RENT.DatosExternosDACAPI;
using Ol4RentAPI.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace OL4RENTServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NovedadesService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select NovedadesService.svc or NovedadesService.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class NovedadesService : INovedadesService
    {
        public List<NovedadExternaDTO> ObtenerNovedadesPorSitio(string idSitio)
        {
            return ServiceFacadeFactory.Instance.NovedadFacade.ObtenerNovedadesPorSitio(int.Parse(idSitio));
        }
    }
}
