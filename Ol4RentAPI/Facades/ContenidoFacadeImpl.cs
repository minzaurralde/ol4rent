using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ol4RentAPI.DTO;
using Ol4RentAPI.Model;
using System.Data;

namespace Ol4RentAPI.Facades
{
    class ContenidoFacadeImpl: IContenidoFacade
    {
        public ContenidoDTO Obtener(int id)
        {
            using (ModelContainer db = new ModelContainer())
            {
                return AutoMapperUtils<Contenido, ContenidoDTO>.Map(db.Contenidos.Find(id));
            }
        }

       
        public  void MarcarInadecuado(int id)
        {
            using (ModelContainer db = new ModelContainer())
            {
                Contenido cont =  db.Contenidos.Find(id) ;
                if (cont != null)
                {
                    cont.CantMarcas++; 
                        db.Entry(cont).State = EntityState.Modified; 
                        db.SaveChanges();
                }
            }
        }

        public void Eliminar(int id)
        {
            using (ModelContainer db = new ModelContainer())
            {
                Contenido cont = db.Contenidos.Find(id);
                db.Contenidos.Remove(cont);
                db.SaveChanges();
            }
        }
    }
}
