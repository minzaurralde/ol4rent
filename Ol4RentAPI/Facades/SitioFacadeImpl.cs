using Ol4RentAPI.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.Facades
{
    class SitioFacadeImpl: ISitioFacade
    {
        private ModelContainer db = new ModelContainer();

        public List<Model.Sitio> Todos
        {
            get { return db.Sitios.ToList(); }
        }

        public Model.Sitio Obtener(int id)
        {
            return db.Sitios.Find(id);
        }

        public Model.Sitio Crear(Model.Sitio sitio)
        {
            try
            {
                db.Sitios.Add(sitio);
                db.SaveChanges();
                return sitio;
            }
            catch
            {
                return null;
            }
        }

        public Model.Sitio Editar(Model.Sitio sitio)
        {
            try
            {
                db.Entry(sitio).State = EntityState.Modified;
                db.SaveChanges();
                return sitio;
            }
            catch
            {
                return null;
            }
        }

        public void Eliminar(int id)
        {
            Sitio sitio = db.Sitios.Find(id);
            db.Sitios.Remove(sitio);
            db.SaveChanges();
        }


        public byte[] Logo(int id)
        {
            Sitio sitio = Obtener(id);
            if (sitio != null)
            {
                return sitio.Logo;
            }
            else
            {
                return null;
            }
        }
    }
}
