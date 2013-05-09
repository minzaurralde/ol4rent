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
        private ModelContainer db = new ModelContainer();

        public List<Model.Sitio> Todos
        {
            get { return db.Sitios.ToList(); }
        }

        public Model.Sitio Obtener(int id)
        {
            return db.Sitios.Find(id);
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
                // Se guardan los cambios y se retorna exitosamente
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
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
