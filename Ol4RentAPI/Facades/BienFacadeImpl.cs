using Ol4RentAPI.DTO;
using Ol4RentAPI.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ol4RentAPI.Facades
{
    class BienFacadeImpl: IBienFacade
    {
        public Model.Bien Obtener(int id)
        {
            using (ModelContainer db = new ModelContainer())
            {
                return db.Bienes.Find(id);
            }
        }

        public bool Crear(BienAltaDTO bienDTO)
        {
            bienDTO.Normas = "";
            bienDTO.Capacidad = 12;


            Bien bien = new Bien()
            {
                Titulo = bienDTO.Titulo,
                Descripcion = bienDTO.Descripcion,
                Foto = bienDTO.Foto,
                Latitud = bienDTO.Latitud,
                Longitud = bienDTO.Longitud,
                Direccion = bienDTO.Direccion,
                Normas = bienDTO.Normas,
                Capacidad = bienDTO.Capacidad,
                Precio = bienDTO.Precio,
                TipoBien = new TipoBien()
                {
                    Id = 1,Nombre="Auto"
                },
                Usuario=new Usuario(){
                    Id=1,Nombre="Ignacio"
                }
            };
            try {
                using (ModelContainer db = new ModelContainer())
                {
                    db.Bienes.Add(bien);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public Model.Bien Editar(Model.Bien bien)
        {
            try
            {
                using (ModelContainer db = new ModelContainer())
                {
                    db.Entry(bien).State = EntityState.Modified;
                    db.SaveChanges();
                    return bien;
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
                Bien bien = db.Bienes.Find(id);
                if (bien != null)
                {
                    db.Bienes.Remove(bien);
                    db.SaveChanges();
                }
            }
        }

        public List<Model.Bien> Buscar(string query)
        {
            if (query != null)
            {
                // TODO pasar a linq
                using (ModelContainer db = new ModelContainer())
                {
                    return db.Bienes.Where(b => b.Descripcion.Contains(query) || b.Titulo.Contains(query)).ToList();
                }
            }
            else
            {
                return new List<Bien>();
            }
        }

        public List<Model.Bien> BusquedaAvanzada(Model.Bien templateBien)
        {
            using (ModelContainer db = new ModelContainer())
            {
                if (templateBien.Descripcion != null && templateBien.Titulo != null)
                {
                    IQueryable<Bien> query =
                        from b in db.Bienes
                        where b.Descripcion.Contains(templateBien.Descripcion)
                            && b.Titulo.Contains(templateBien.Titulo)
                        select b;
                    if (query.Count() > 0)
                    {
                        return query.ToList();
                    }
                    else
                    {
                        return new List<Bien>();
                    }
                    // TODO pasar a linq
                    // return db.Bienes.Where(b => b.Descripcion.Contains(templateBien.Descripcion) && b.Titulo.Contains(templateBien.Titulo)).ToList();
                }
                else if (templateBien.Titulo != null)
                {
                    IQueryable<Bien> query =
                        from b in db.Bienes
                        where b.Titulo.Contains(templateBien.Titulo)
                        select b;
                    if (query.Count() > 0)
                    {
                        return query.ToList();
                    }
                    else
                    {
                        return new List<Bien>();
                    }
                    // TODO pasar a linq
                    // return db.Bienes.Where(b => b.Titulo.Contains(templateBien.Titulo)).ToList();
                }
                else if (templateBien.Descripcion != null)
                {
                    IQueryable<Bien> query =
                        from b in db.Bienes
                        where b.Descripcion.Contains(templateBien.Descripcion)
                        select b;
                    if (query.Count() > 0)
                    {
                        return query.ToList();
                    }
                    else
                    {
                        return new List<Bien>();
                    }
                    // TODO pasar a linq
                    // return db.Bienes.Where(b => b.Descripcion.Contains(templateBien.Descripcion)).ToList();
                }
                return new List<Bien>();
            }
        }

        public List<Model.Bien> Wishlist(Model.Usuario usuario)
        {
            // TODO implementar
            throw new NotImplementedException();
        }

        public List<Model.Bien> MisBienes(Model.Usuario usuario)
        {
            // TODO implementar
            throw new NotImplementedException();
        }

        public List<Bien> BienesPopulares
        {
            get
            {
                using (ModelContainer db = new ModelContainer())
                {
                    SitioListadoDTO sitioDTO = HttpContext.Current.Session["sitio"] as SitioListadoDTO;
                    Sitio sitio = db.Sitios.Find(sitioDTO.Id);
                    int maximaCantidadPopulares = sitio.CantBienesPopulares;
                    IQueryable<Bien> query =
                        from mg in db.MeGusta
                        where mg.Bien.TipoBien.Sitio.Id == sitio.Id
                        group mg by mg.Bien into mgg
                        orderby mgg.Count() descending
                        select mgg.Key;
                    if (query.Count() > 0)
                    {
                        return query.ToList();
                    }
                    else
                    {
                        return new List<Bien>();
                    }
                }
            }
        }

        public List<Bien> Todos
        {
            get {
                using (ModelContainer db = new ModelContainer())
                {
                    return db.Bienes.ToList();
                }
            }
        }

        public BienEdicionDTO ObtenerBienParaContenido(int idContenido) 
        {
            using (ModelContainer db = new ModelContainer()) 
            {
                IQueryable<Bien> query =
                    from b in db.Bienes
                    where b.Contenidos.Where(c => c.Id == idContenido).Count() > 0
                    select b;
                if (query.Count() > 0) 
                {
                    return AutoMapperUtils<Bien, BienEdicionDTO>.Map(query.First());
                }
                else 
                {
                    return null;
                }
            }
        }

        public List<ContenidoDTO> ContenidosInadecuadosPorSitio(int idSitio)
        {
            using (ModelContainer db = new ModelContainer())
            {
                IQueryable<Contenido> query =
                    from cont in db.Contenidos
                    where db.Bienes.Where(b => 
                                b.TipoBien.Sitio.Id == idSitio 
                                && b.Contenidos.Where(c => c.Id == cont.Id).Count() > 0).Count() > 0
                    orderby cont.CantMarcas descending
                    select cont;
                if (query.Count() > 0) 
                {
                    return AutoMapperUtils<Contenido, ContenidoDTO>.Map(query.ToList());
                } 
                else 
                {
                    return new List<ContenidoDTO>();
                }
            }
        }

        public RegistroBienDTO RegistroDeBienesEnTiempo(int idSitio, DateTime fechaInicio, DateTime fechaFin)
        {
            using (ModelContainer db = new ModelContainer())
            {
                // TODO falta la fecha de alta en el bien
                IQueryable<Bien> query =
                    from b in db.Bienes
                    where b.TipoBien.Sitio.Id == idSitio
                    select b;
                return new RegistroBienDTO() { Cantidad = query.Count() };
            }
            return null;
        }
    }
}
