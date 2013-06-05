using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Ol4RentAPI.DTO;

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

        // Coneccion con la base de datos
        bienescercanosDataContext dbc = new bienescercanosDataContext();

        /// <summary>
        /// Obtener Bienes Cercanos desde la ubicacion actual en el mobile
        /// </summary>
        /// <param name="latitud"></param>
        /// <param name="longitud"></param>
        /// <returns></returns>
        public List<BienListadoDTO> ObtenerBienesCercanos(string latitud, string longitud)
        {

            List<BienListadoDTO> bienlistdto = new List<BienListadoDTO>();
            
            double latd = double.Parse(latitud);
            double longd = double.Parse(longitud);

            ///var bienescercanosstr = "";
            /*var bienescer = (from bienescerc in dbc.Bienes
                             orderby Math.Pow((double)(bienescerc.Longitud - longd), 2) - Math.Pow((double)(bienescerc.Latitud - latd), 2)
                             select Math.Pow((double)(bienescerc.Longitud - longd), 2) - Math.Pow((double)(bienescerc.Latitud - latd), 2)  
                            ).Take(10);*/

            var bienescer = (from bienescerc in dbc.Bienes
                             orderby Math.Pow((double)((double)bienescerc.Longitud - longd), 2) - Math.Pow((double)((double)bienescerc.Latitud - latd), 2)
                             select bienescerc 
                            ).Take(10);

            //// devuelve en uan lista los ids. de lso bienes cercanos
            ///bienescercanosstr = "";

            //double distact = 0;
            foreach (var bienesmin in bienescer)
            {
                //distact = Math.Pow((double)((double)bienesmin.Longitud - longd), 2) - Math.Pow((double)((double)bienesmin.Latitud - latd), 2);
                //bienescercanosstr = bienescercanosstr + distact.ToString() + "-";
                ///bienescercanosstr = bienescercanosstr + c.ToString() + "-";
                BienListadoDTO eblist = new BienListadoDTO();
                eblist.Id = bienesmin.Id;
                eblist.TipoDeBien = bienesmin.TiposBiene.Nombre;
                eblist.Titulo = bienesmin.Titulo;
                eblist.Latitud = bienesmin.Latitud;
                eblist.Longitud = bienesmin.Longitud;
                bienlistdto.Add(eblist);
            }

            //// Mientras no hallan bienes ingresados
            //// Por el momento retorna lista fija de pruebas
            ///bienescercanosstr = bienescercanosstr + "1010-1020-1030-1040-1050";

            return bienlistdto;

        }

    }
}
