using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ol4RentAPI.DTO;
using Ol4RentAPI.Model;

namespace Ol4RentAPI.Facades
{
    class CaracteristicasFacadeImpl: ICaracteristicaFacade
    {
        public CaracteristicaEdicionDTO Obtener(int id)
        {
            using (ModelContainer db = new ModelContainer())
            {
                return AutoMapperUtils<Caracteristica, CaracteristicaEdicionDTO>.Map(db.Caracteristicas.Find(id));
            }
        }
    }
}
