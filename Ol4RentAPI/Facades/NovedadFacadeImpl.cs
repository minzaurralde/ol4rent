using Ol4RentAPI.Model;
using Ol4RentAPI.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.Facades
{
    class NovedadFacadeImpl: INovedadFacade
    {
        private ModelContainer db = new ModelContainer();

        // TODO cambiar con el tema de los origenes de datos
        internal List<Novedad> ListaNovedadesRSS
        {
            get
            {
                ManejoRSS mj = new ManejoRSS();
                return mj.LecturaRSS("http://blog.orcare.com/rss");
            }
        }


        public List<Model.Novedad> Todas
        {
            get { return db.Novedades.ToList(); }
        }

        public Model.Novedad Obtener(int id)
        {
            return db.Novedades.Find(id);
        }

        public Model.Novedad Crear(Model.Novedad novedad)
        {
            try
            {
                db.Novedades.Add(novedad);
                db.SaveChanges();
                return novedad;
            }
            catch
            {
                return null;
            }
        }

        public Model.Novedad Editar(Model.Novedad novedad)
        {
            try
            {
                db.Entry(novedad).State = EntityState.Modified;
                db.SaveChanges();
                return novedad;
            }
            catch
            {
                return null;
            }
        }

        public void Eliminar(int id)
        {
            Novedad novedad = db.Novedades.Find(id);
            db.Novedades.Remove(novedad);
            db.SaveChanges();
        }

        public List<Model.Novedad> ListaNovedades()
        {
            // TODO sacar este parametro de sitio
            int maximaCantidadNovedadesHome = 6;
            return db.Novedades.Take(maximaCantidadNovedadesHome).ToList();
        }
    }
}
