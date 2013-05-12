using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ol4RentAPI.Model;
using System.Data;
using Ol4RentAPI.DTO;

namespace Ol4RentAPI.Facades
{
    class AccountFacadeImpl : IAccountFacade
    {
        private ModelContainer db = new ModelContainer();

        public List<Model.Usuario> Todos
        {
            get { return db.Usuarios.ToList(); }
        }
        
        public Usuario Obtener(int id)
        {
            return db.Usuarios.Find(id);
        }

        public Usuario ObtenerPorNombre(string NombreUsuario)
        {
            return db.Usuarios.Where(u => u.NombreUsuario.ToLower() == NombreUsuario.ToLower()).First();
        }

        public Usuario Crear(Usuario usuario)
        {
            try
            {
                // Creo el usuario
                db.Usuarios.Add(usuario);
                // Asocio todos los sitios al usuario
                List<Sitio> sitios = db.Sitios.ToList();
                foreach (Sitio sitio in sitios)
                {
                    db.HabilitacionesUsuarios.Add(new HabilitacionUsuario() { Usuario = usuario, Sitio = sitio, Habilitado = true, CantContBloq = 0 });
                }
                // Guardo los cambios
                db.SaveChanges();
                return usuario;
            }
            catch
            {
                return null;
            }

        }
        
        public Usuario Editar(Usuario usuario)
        {
            try
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return usuario;
            }
            catch
            {
                return null;
            }
        }

        public void Eliminar(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
            db.SaveChanges();
        }

        /// <summary>
        /// Obtiene una lista con todos los usuarios habilitados y deshabilitados para un sitio determinado.
        /// </summary>
        /// <param name="idSitio">Identificador del sitio</param>
        /// <returns>Una lista de UsuarioSitioDTO con todos los usuarios y su relacion con el sitio</returns>
        public List<UsuarioSitioDTO> ObtenerPorSitio(int idSitio)
        {
            IQueryable<HabilitacionUsuario> habilitaciones =
                from hu in db.HabilitacionesUsuarios
                where hu.Sitio.Id == idSitio
                select hu;
            return AutoMapperUtils<HabilitacionUsuario, UsuarioSitioDTO>.Map(habilitaciones.ToList());
        }

        /// <summary>
        /// Deshabilita un usuario para el acceso a un sitio
        /// </summary>
        /// <param name="idUsuario">Identificador del usuario</param>
        /// <param name="idSitio">Identificador del sitio</param>
        public void DeshabilitarUsuarioEnSitio(int idUsuario, int idSitio)
        {
            IQueryable<HabilitacionUsuario> habilitaciones =
                from hu in db.HabilitacionesUsuarios
                where hu.Sitio.Id == idSitio
                    && hu.Usuario.Id == idUsuario
                select hu;
            if (habilitaciones.Count<HabilitacionUsuario>() > 0)
            {
                habilitaciones.First().Habilitado = false;
                db.Entry<HabilitacionUsuario>(habilitaciones.First()).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Habilita el acceso de un usuario a un sitio
        /// </summary>
        /// <param name="idUsuario">Identificador del usuario</param>
        /// <param name="idSitio">Identificador del sitio</param>
        public void HabilitarUsuarioEnSitio(int idUsuario, int idSitio)
        {
            IQueryable<HabilitacionUsuario> habilitaciones =
                from hu in db.HabilitacionesUsuarios
                where hu.Sitio.Id == idSitio
                    && hu.Usuario.Id == idUsuario
                select hu;
            if (habilitaciones.Count<HabilitacionUsuario>() > 0)
            {
                habilitaciones.First().Habilitado = true;
                db.Entry<HabilitacionUsuario>(habilitaciones.First()).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Resetea el acceso de un usuario a un sitio, habilitandolo y restaurando el contador de contenidos bloqueados.
        /// </summary>
        /// <param name="idUsuario">Identificador del usuario</param>
        /// <param name="idSitio">Identificador del sitio</param>
        public void ResetearUsuarioEnSitio(int idUsuario, int idSitio)
        {
            IQueryable<HabilitacionUsuario> habilitaciones =
                from hu in db.HabilitacionesUsuarios
                where hu.Sitio.Id == idSitio
                    && hu.Usuario.Id == idUsuario
                select hu;
            if (habilitaciones.Count<HabilitacionUsuario>() > 0)
            {
                habilitaciones.First().Habilitado = true;
                habilitaciones.First().CantContBloq = 0;
                db.Entry<HabilitacionUsuario>(habilitaciones.First()).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
