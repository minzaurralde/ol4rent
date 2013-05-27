using OL4RENT.DatosExternosDACAPI;
using Ol4RentAPI.DTO;
using Ol4RentAPI.Facades.Novedades;
using Ol4RentAPI.Model;
using Ol4RentAPI.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ol4RentAPI.Facades
{
    class NovedadFacadeImpl: INovedadFacade
    {
        public List<Novedad> Todas
        {
            get
            {
                using (ModelContainer db = new ModelContainer())
                {
                    return db.Novedades.ToList();
                }
            }
        }

        public Novedad Obtener(int id)
        {
            using (ModelContainer db = new ModelContainer())
            {
                return db.Novedades.Find(id);
            }
        }
        public Novedad Crear(Novedad novedad)
        {
            try
            {
                using (ModelContainer db = new ModelContainer())
                {
                    db.Novedades.Add(novedad);
                    db.SaveChanges();
                    return novedad;
                }
            }
            catch
            {
                return null;
            }
        }

        public Novedad Editar(Novedad novedad)
        {
            try
            {
                using (ModelContainer db = new ModelContainer())
                {
                    db.Entry(novedad).State = EntityState.Modified;
                    db.SaveChanges();
                    return novedad;
                }
            }
            catch
            {
                return null;
            }
        }

        public void Eliminar(int id)
        {
            using (ModelContainer db = new ModelContainer())
            {
                Novedad novedad = db.Novedades.Find(id);
                db.Novedades.Remove(novedad);
                db.SaveChanges();
            }
        }

        public List<NovedadDTO> ListaNovedades()
        {
            using (ModelContainer db = new ModelContainer())
            {
                if (HttpContext.Current.Session["sitio"] == null)
                {
                    return new List<NovedadDTO>();
                }
                SitioListadoDTO sitioDTO = HttpContext.Current.Session["sitio"] as SitioListadoDTO;
                Sitio sitio = db.Sitios.Find(sitioDTO.Id);
                if (sitio == null)
                {
                    return new List<NovedadDTO>();
                }
                // TODO agregar parametro en el sitio con la cantidad maxima de novedades a mostrar
                int maximaCantidadNovedadesHome = sitio.CantBienesPopulares;
                IQueryable<ConfiguracionOrigenDatos> query =
                    from cod in db.ConfiguracionesOrigenesDatos
                    where cod.Sitio.Id == sitio.Id
                    select cod;
                if (query.Count() <= 0)
                {
                    return new List<NovedadDTO>();
                }
                else
                {
                    List<ConfiguracionOrigenDatos> configuraciones = query.ToList();
                    List<NovedadDTO> novedades = new List<NovedadDTO>();
                    foreach (ConfiguracionOrigenDatos config in configuraciones)
                    {
                        IProveedorNoticias proveedor = NovedadesExternasFactory.ObtenerProveedor(config);
                        List<NovedadExternaDTO> novedadesConfig = proveedor.ObtenerNovedades(maximaCantidadNovedadesHome);
                        foreach (NovedadExternaDTO novedadExterna in novedadesConfig)
                        {
                            novedades.Add(new NovedadDTO() { ContenidoRecortado = novedadExterna.Contenido.Count() > 130 ? novedadExterna.Contenido.Substring(0, 130) + "..." : novedadExterna.Contenido, Contenido = novedadExterna.Contenido, Titulo = novedadExterna.Titulo, Fecha = novedadExterna.Fecha, Proveedor = config.OrigenDatos.Nombre });
                        }
                    }
                    novedades.Sort(new NovedadComparer());
                    return novedades;
                }
            }
        }


        public List<NovedadExternaDTO> ObtenerNovedadesPorSitio(int idSitio)
        {
            using (ModelContainer db = new ModelContainer())
            {
                IQueryable<Novedad> queryNovedades =
                    from nov in db.Novedades
                    where nov.Configuracion.Sitio.Id == idSitio
                    select nov;
                if (queryNovedades.Count() > 0)
                {
                    return AutoMapperUtils<Novedad, NovedadExternaDTO>.Map(queryNovedades.ToList());
                }
                else
                {
                    return new List<NovedadExternaDTO>();
                }
            }
        }
    }
}
