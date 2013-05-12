using Ol4RentAPI.DTO;
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
                TipoBien = tipoBien
            };
            // Se asocia el sitio al tipo de bien
            tipoBien.Sitio = sitio;
            // Se obtiene el propietario del sitio
            Usuario propietario = ServiceFacadeFactory.Instance.AccountFacade.ObtenerPorNombre(sitioDTO.NombreUsuarioPropietario);
            try
            {
                using (ModelContainer db = new ModelContainer())
                {
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
                Sitio sitio = Obtener(sitioDTO.Id);
                // TODO implementar edicion de sitio
                using (ModelContainer db = new ModelContainer())
                {
                    db.Entry(sitio).State = EntityState.Modified;
                    db.SaveChanges();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public List<SitioListadoDTO> ObtenerPorUsuario(string nombreUsuario)
        {
            Usuario usuario = ServiceFacadeFactory.Instance.AccountFacade.ObtenerPorNombre(nombreUsuario);
            return AutoMapperUtils<Sitio, SitioListadoDTO>.Map(usuario.SitiosAdministrados.ToList());
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
                Sitio sitio = Obtener(id);
                IQueryable<Usuario> usuarios = from usu in db.Usuarios where usu.SitiosAdministrados.Contains(sitio) select usu;
                SitioEdicionDTO dto = AutoMapperUtils<Sitio, SitioEdicionDTO>.Map(sitio);
                //dto.Caracteristicas = AutoMapperUtils<Caracteristica, CaracteristicaAltaDTO>.Map(sitio.TipoBien.Caracteristicas.ToList());
                //dto.NombreUsuarioPropietario = usuarios.First().NombreUsuario;
                return dto;
            }
        }

        public List<CaracteristicaAltaDTO> ObtenerCaracteristicasParaEdicion(int idSitio)
        {
            using (ModelContainer db = new ModelContainer())
            {
                Sitio sitio = db.Sitios.Find(idSitio);
                return AutoMapperUtils<Caracteristica, CaracteristicaAltaDTO>.Map(sitio.TipoBien.Caracteristicas.ToList());
            }
        }

        public string ObtenerNombreUsuarioPropietario(int idSitio)
        {
            using (ModelContainer db = new ModelContainer())
            {
                Sitio sitio = db.Sitios.Find(idSitio);
                return (from usu in db.Usuarios where usu.SitiosAdministrados.Contains(sitio) select usu.NombreUsuario).First<string>();
            }
        }
    }
}
