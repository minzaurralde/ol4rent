using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Ol4RentAPI.DTO;
using Ol4RentAPI.Facades;

namespace OL4RENTServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceMobile : IServiceMobile
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        /// <summary>
        /// Obtener Bienes Cercanos desde la ubicacion actual en el mobile
        /// </summary>
        /// <param name="latitud"></param>
        /// <param name="longitud"></param>
        /// <returns></returns>
        public List<BienCercanoDTO> ObtenerBienesCercanos(string latitud, string longitud)
        {
            double latd = double.Parse(latitud);
            double longd = double.Parse(longitud);

            return ServiceFacadeFactory.Instance.BienFacade.ObtenerBienesCercanos(longd, latd);
        }

    }
}
