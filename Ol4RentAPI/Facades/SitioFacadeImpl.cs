﻿using Ol4RentAPI.DTO;
using Ol4RentAPI.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Ol4RentAPI.Facades
{
    class SitioFacadeImpl: ISitioFacade
    {
        /// <summary>
        /// Obtiene una lista con todos los sitios del sistema
        /// </summary>
        public List<Sitio> Todos
        {
            get 
            {
                using (ModelContainer db = new ModelContainer())
                {
                    return db.Sitios.ToList();
                }
            }
        }

        /// <summary>
        /// Obtiene un sitio a partir de su identificador
        /// </summary>
        /// <param name="id">Identificador del sitio</param>
        /// <returns>Objeto sitio</returns>
        public Sitio Obtener(int id)
        {
            using (ModelContainer db = new ModelContainer())
            {
                return db.Sitios.Find(id);
            }
        }

        /// <summary>
        /// Crea un nuevo sitio en el portal OL4RENT
        /// </summary>
        /// <param name="sitioDTO">DTO con los datos del sitio que se creará</param>
        /// <returns><code>true</code> si se creó exitosamente el sitio, <code>false</code> en caso contrario.</returns>
        public bool Crear(SitioAltaDTO sitioDTO)
        {
            // Se crea el tipo de bien que se arrendará en el sitio
            TipoBien tipoBien = new TipoBien() { Nombre = sitioDTO.NombreTipoBien, Caracteristicas = new List<Caracteristica>() };
            // Se asocian las caracteristicas particulares de los bienes arrendados en el sitio
            foreach (CaracteristicaAltaDTO caracteristicaDTO in sitioDTO.Caracteristicas)
            {
                tipoBien.Caracteristicas.Add(new Caracteristica() { Nombre = caracteristicaDTO.Nombre, Tipo = caracteristicaDTO.Tipo });
            }
            // Se crea el sitio
            Sitio sitio = new Sitio()
            {
                Nombre = sitioDTO.Nombre,
                Descripcion = sitioDTO.Descripcion,
                Logo = sitioDTO.Logo,
                CSS = sitioDTO.CSS,
                MailAdmin = sitioDTO.MailAdmin,
                URL = sitioDTO.URL,
                CantBienesPopulares = sitioDTO.CantBienesPopulares,
                CantMarcasXCont = sitioDTO.CantMarcasXCont,
                CantContBloqXUsu = sitioDTO.CantContBloqXUsu,
                CantNovedadesHome = sitioDTO.CantNovedadesHome,
                AproximacionWish = sitioDTO.AproximacionWish,
                TipoBien = tipoBien
            };
            // Se asocia el sitio al tipo de bien
            tipoBien.Sitio = sitio;
            try
            {
                using (ModelContainer db = new ModelContainer())
                {
                    // Se obtiene el propietario del sitio
                    IQueryable<Usuario> queryPropietario =
                        from usu in db.Usuarios
                        where usu.NombreUsuario == sitioDTO.NombreUsuarioPropietario
                        select usu;
                    Usuario propietario = queryPropietario.First();
                    // Se guarda el sitio
                    db.Sitios.Add(sitio);
                    // Se guarda el tipo de bien
                    db.TiposBienes.Add(sitio.TipoBien);
                    // Se guardan las características
                    foreach (Caracteristica caracteristica in sitio.TipoBien.Caracteristicas)
                    {
                        db.Caracteristicas.Add(caracteristica);
                    }
                    // Si el propietario no tiene el rol SITE_ADMIN, se le agrega
                    if (!Roles.IsUserInRole(propietario.NombreUsuario, RolEnum.SITE_ADMIN.ToString()))
                    {
                        Roles.AddUserToRole(propietario.NombreUsuario, RolEnum.SITE_ADMIN.ToString());
                    }
                    // Se agrega el sitio al litado de sitios administrados por el usuario propietario
                    propietario.SitiosAdministrados.Add(sitio);
                    // Se asocian todos los usuarios al sitio
                    List<Usuario> usuarios = db.Usuarios.ToList();
                    foreach (Usuario usuario in usuarios)
                    {
                        db.HabilitacionesUsuarios.Add(new HabilitacionUsuario() { Usuario = usuario, Sitio = sitio, CantContBloq = 0, Habilitado = true });
                    }
                    // Se guardan los cambios y se retorna exitosamente
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Editar(SitioEdicionDTO sitioDTO)
        {
            try
            {
                using (ModelContainer db = new ModelContainer())
                {
                    Sitio sitio = db.Sitios.Find(sitioDTO.Id);
                    bool seModifico = false;
                    if (sitio.Nombre != sitioDTO.Nombre)
                    {
                        sitio.Nombre = sitioDTO.Nombre;
                        seModifico = true;
                    }
                    if (sitio.Descripcion != sitioDTO.Descripcion)
                    {
                        sitio.Descripcion = sitioDTO.Descripcion;
                        seModifico = true;
                    }
                    if (sitio.MailAdmin != sitioDTO.MailAdmin)
                    {
                        sitio.MailAdmin = sitioDTO.MailAdmin;
                        seModifico = true;
                    }
                    if (sitio.URL != sitioDTO.URL)
                    {
                        sitio.URL = sitioDTO.URL;
                        seModifico = true;
                    }
                    if (sitio.CantBienesPopulares != sitioDTO.CantBienesPopulares)
                    {
                        sitio.CantBienesPopulares = sitioDTO.CantBienesPopulares;
                        seModifico = true;
                    }
                    if (sitio.CantContBloqXUsu != sitioDTO.CantContBloqXUsu)
                    {
                        sitio.CantContBloqXUsu = sitioDTO.CantContBloqXUsu;
                        seModifico = true;
                    }
                    if (sitio.CantMarcasXCont != sitioDTO.CantMarcasXCont)
                    {
                        sitio.CantMarcasXCont = sitioDTO.CantMarcasXCont;
                        seModifico = true;
                    }
                    if (sitio.CantNovedadesHome != sitioDTO.CantNovedadesHome)
                    {
                        sitio.CantNovedadesHome = sitioDTO.CantNovedadesHome;
                        seModifico = true;
                    }
                    if (sitio.AproximacionWish != sitioDTO.AproximacionWish)
                    {
                        sitio.AproximacionWish = sitioDTO.AproximacionWish;
                        seModifico = true;
                    }
                    if (sitioDTO.CSS != null && sitio.CSS != sitioDTO.CSS)
                    {
                        sitio.CSS = sitioDTO.CSS;
                        seModifico = true;
                    }
                    if (sitioDTO.Logo != null && sitio.Logo != sitioDTO.Logo)
                    {
                        sitio.Logo = sitioDTO.Logo;
                        seModifico = true;
                    }
                    bool salvar = false;
                    if (sitio.TipoBien.Nombre != sitioDTO.NombreTipoBien)
                    {
                        sitio.TipoBien.Nombre = sitioDTO.NombreTipoBien;
                        db.Entry(sitio.TipoBien).State = EntityState.Modified;
                        salvar = true;
                    }
                    // Se verifica si se tiene que cambiar el usuario propietario
                    Usuario usuarioActual = (from usu in db.Usuarios where usu.SitiosAdministrados.Where(s => s.Id == sitio.Id).Count() > 0 select usu).First();
                    if (usuarioActual == null || usuarioActual.NombreUsuario != sitioDTO.NombreUsuarioPropietario)
                    {
                        Usuario usuarioNuevo = (from usu in db.Usuarios where usu.NombreUsuario == sitioDTO.NombreUsuarioPropietario select usu).First();
                        if (usuarioNuevo != null)
                        {
                            usuarioNuevo.SitiosAdministrados.Add(sitio);
                            db.Entry<Usuario>(usuarioNuevo).State = EntityState.Modified;
                            salvar = true;
                        }
                    }
                    // Se modifican las caracteristicas del tipo de bien
                    List<int> idsCaracteristicasNuevas = sitioDTO.Caracteristicas.Select(a => a.Id).ToList();
                    List<Caracteristica> caracteristicasBorrables = sitio.TipoBien.Caracteristicas.Where(a => !idsCaracteristicasNuevas.Contains(a.Id)).ToList();
                    bool seEliminaAlguno = false;
                    foreach (Caracteristica caracteristicaBorrable in caracteristicasBorrables)
                    {
                        sitio.TipoBien.Caracteristicas.Remove(caracteristicaBorrable);
                        db.Caracteristicas.Remove(caracteristicaBorrable);
                        seEliminaAlguno = true;
                    }
                    // Se recorren todos los atributos viejos que no se eliminaron en busca de modificaciones
                    bool seModificoAlguno = false;
                    foreach (Caracteristica caracteristicaVieja in sitio.TipoBien.Caracteristicas)
                    {
                        CaracteristicaEdicionDTO caracteristicaDto = sitioDTO.Caracteristicas.Where(a => a.Id == caracteristicaVieja.Id).First();
                        if (caracteristicaDto != null)
                        {
                            if (!caracteristicaVieja.Nombre.Equals(caracteristicaDto.Nombre))
                            {
                                caracteristicaVieja.Nombre = caracteristicaDto.Nombre;
                                db.Entry<Caracteristica>(caracteristicaVieja).State = System.Data.EntityState.Modified;
                                seModificoAlguno = true;
                            }
                            if (!caracteristicaVieja.Tipo.Equals(caracteristicaDto.Tipo))
                            {
                                caracteristicaVieja.Tipo = caracteristicaDto.Tipo;
                                db.Entry<Caracteristica>(caracteristicaVieja).State = System.Data.EntityState.Modified;
                                seModificoAlguno = true;
                            }
                        }
                    }
                    // Se obtiene una lista de los atributos nuevos y se agregan
                    bool seAgregoAlguno = false;
                    List<CaracteristicaEdicionDTO> caracteristicasNuevos = sitioDTO.Caracteristicas.Where(a => a.Id <= 0).ToList();
                    foreach (CaracteristicaEdicionDTO caracteristicaNueva in caracteristicasNuevos)
                    {
                        Caracteristica caracteristica = new Caracteristica() { Nombre = caracteristicaNueva.Nombre, Tipo = caracteristicaNueva.Tipo };
                        db.Caracteristicas.Add(caracteristica);
                        sitio.TipoBien.Caracteristicas.Add(caracteristica);
                        seAgregoAlguno = true;
                    }
                    salvar = salvar || seAgregoAlguno || seEliminaAlguno || seModificoAlguno;

                    if (seModifico)
                    {
                        db.Entry(sitio).State = EntityState.Modified;
                    }
                    if (seModifico || salvar)
                    {
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Eliminar(int id)
        {
            using (ModelContainer db = new ModelContainer())
            {
                Sitio sitio = db.Sitios.Find(id);
                db.Sitios.Remove(sitio);
                db.SaveChanges();
            }
        }
        
        public byte[] Logo(int id)
        {
            using (ModelContainer db = new ModelContainer())
            {
                Sitio sitio = db.Sitios.Find(id);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public List<SitioListadoDTO> ObtenerPorUsuario(string nombreUsuario)
        {
            using (ModelContainer db = new ModelContainer())
            {
                IQueryable<Usuario> query =
                    from usu in db.Usuarios
                    where usu.NombreUsuario == nombreUsuario
                    select usu;
                if (query.Count() > 0)
                {
                    return AutoMapperUtils<Sitio, SitioListadoDTO>.Map(query.First().SitiosAdministrados.ToList());
                }
                else
                {
                    return new List<SitioListadoDTO>();
                }
            }
        }

        /// <summary>
        /// Obtiene un DTO del sitio para ser editado
        /// </summary>
        /// <param name="id">Identificador del sitio</param>
        /// <returns>Un objeto SitioEdicionDTO con los datos del sitio para ser editados</returns>
        public SitioEdicionDTO ObtenerParaEdicion(int id)
        {
            using (ModelContainer db = new ModelContainer())
            {
                return AutoMapperUtils<Sitio, SitioEdicionDTO>.Map(db.Sitios.Find(id));
            }
        }

        public List<CaracteristicaEdicionDTO> ObtenerCaracteristicasParaEdicion(int idSitio)
        {
            using (ModelContainer db = new ModelContainer())
            {
                Sitio sitio = db.Sitios.Find(idSitio);
                return AutoMapperUtils<Caracteristica, CaracteristicaEdicionDTO>.Map(sitio.TipoBien.Caracteristicas.ToList());
            }
        }

        public string ObtenerNombreUsuarioPropietario(int idSitio)
        {
            using (ModelContainer db = new ModelContainer())
            {
                return (from usu in db.Usuarios where usu.SitiosAdministrados.Where(s => s.Id == idSitio).Count() > 0 select usu.NombreUsuario).First<string>();
            }
        }


        public SitioListadoDTO ObtenerPorDominio(string dominio)
        {
            using (ModelContainer db = new ModelContainer()) {
                IQueryable<Sitio> querySitio = 
                    from s in db.Sitios 
                    where s.URL == dominio 
                    select s;
                if (querySitio.Count() > 0)
                {
                    return AutoMapperUtils<Sitio, SitioListadoDTO>.Map(querySitio.First());
                }
                else
                {
                    return null;
                }
            }
        }

        public int ObtenerIdTipoBien (int id)
        {
            using (ModelContainer db = new ModelContainer())
            {
                IQueryable<Sitio> querySitio =
                    from s in db.Sitios
                    where s.Id == id
                    select s;
                if (querySitio.Count() > 0)
                {
                    return querySitio.First().TipoBien.Id;
                }
                else
                {
                    return 0;
                }
            }
        }


        public byte[] Css(int idSitio)
        {
            using (ModelContainer db = new ModelContainer())
            {
                Sitio sitio = db.Sitios.Find(idSitio);
                if (sitio == null)
                {
                    return null;
                }
                else
                {
                    return sitio.CSS;
                }
            }
        }


        public List<SitioListadoDTO> ObtenerTodos()
        {
            using (ModelContainer db = new ModelContainer())
            {
                IQueryable<Sitio> query =
                    from s in db.Sitios
                    select s;
                if (query.Count() > 0)
                {
                    return AutoMapperUtils<Sitio, SitioListadoDTO>.Map(query.ToList());
                }
                else
                {
                    return new List<SitioListadoDTO>();
                }
            }
        }
    }
}
