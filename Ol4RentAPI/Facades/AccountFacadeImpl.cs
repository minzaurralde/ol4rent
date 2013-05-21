using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ol4RentAPI.Model;
using System.Data;
using Ol4RentAPI.DTO;
using System.Web.Security;
using System.Web;

namespace Ol4RentAPI.Facades
{
    class AccountFacadeImpl : IAccountFacade
    {
        public List<Model.Usuario> Todos
        {
            get {
                using (ModelContainer db = new ModelContainer())
                {
                    return db.Usuarios.ToList();
                }
            }
        }
        
        public UsuarioDTO Obtener(int id)
        {
            using (ModelContainer db = new ModelContainer())
            {
                return AutoMapperUtils<Usuario, UsuarioDTO>.Map(db.Usuarios.Find(id));
            }
        }

        public Usuario ObtenerPorNombre(string NombreUsuario)
        {
            using (ModelContainer db = new ModelContainer())
            {
                IQueryable<Usuario> query =
                    from usu in db.Usuarios
                    where usu.NombreUsuario.ToLower() == NombreUsuario.ToLower()
                    select usu;
                if (query.Count() > 0)
                {
                    return query.First();
                }
                else
                {
                    return null;
                }
            }
        }

        public bool Crear(string nombreUsuario)
        {
            try
            {
                Roles.AddUserToRole(nombreUsuario, RolEnum.PUBLIC_USER.ToString());
                using (ModelContainer db = new ModelContainer())
                {
                    // Obtengo el usuario
                    Usuario usuario = (from usu in db.Usuarios where usu.NombreUsuario == nombreUsuario select usu).First();
                    // Asocio todos los sitios al usuario
                    List<Sitio> sitios = db.Sitios.ToList();
                    foreach (Sitio sitio in sitios)
                    {
                        db.HabilitacionesUsuarios.Add(new HabilitacionUsuario() { Usuario = usuario, Sitio = sitio, Habilitado = true, CantContBloq = 0 });
                    }
                    // Guardo los cambios
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }
        
        public bool Editar(UsuarioDTO usuarioDTO)
        {
            try
            {
                using (ModelContainer db = new ModelContainer())
                {
                    IQueryable<Usuario> query =
                        from usu in db.Usuarios
                        where usu.NombreUsuario.ToLower() == usuarioDTO.NombreUsuario.ToLower()
                        select usu;
                    if (query.Count() <= 0)
                    {
                        return false;
                    }
                    else
                    {
                        Usuario usuario = query.First();
                        usuario.Nombre = usuarioDTO.Nombre;
                        usuario.Apellido = usuarioDTO.Apellido;
                        usuario.Mail = usuarioDTO.Mail;
                        db.Entry(usuario).State = EntityState.Modified;
                        db.SaveChanges();
                        return true;
                    }
                }
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
                Usuario usuario = db.Usuarios.Find(id);
                db.Usuarios.Remove(usuario);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Obtiene una lista con todos los usuarios habilitados y deshabilitados para un sitio determinado.
        /// </summary>
        /// <param name="idSitio">Identificador del sitio</param>
        /// <returns>Una lista de UsuarioSitioDTO con todos los usuarios y su relacion con el sitio</returns>
        public List<UsuarioSitioDTO> ObtenerPorSitio(int idSitio)
        {
            using (ModelContainer db = new ModelContainer())
            {
                IQueryable<HabilitacionUsuario> habilitaciones =
                    from hu in db.HabilitacionesUsuarios
                    where hu.Sitio.Id == idSitio
                    select hu;
                return AutoMapperUtils<HabilitacionUsuario, UsuarioSitioDTO>.Map(habilitaciones.ToList());
            }
        }

        /// <summary>
        /// Deshabilita un usuario para el acceso a un sitio
        /// </summary>
        /// <param name="idUsuario">Identificador del usuario</param>
        /// <param name="idSitio">Identificador del sitio</param>
        public void DeshabilitarUsuarioEnSitio(int idUsuario, int idSitio)
        {
            using (ModelContainer db = new ModelContainer())
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
        }

        /// <summary>
        /// Habilita el acceso de un usuario a un sitio
        /// </summary>
        /// <param name="idUsuario">Identificador del usuario</param>
        /// <param name="idSitio">Identificador del sitio</param>
        public void HabilitarUsuarioEnSitio(int idUsuario, int idSitio)
        {
            using (ModelContainer db = new ModelContainer())
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
        }

        /// <summary>
        /// Resetea el acceso de un usuario a un sitio, habilitandolo y restaurando el contador de contenidos bloqueados.
        /// </summary>
        /// <param name="idUsuario">Identificador del usuario</param>
        /// <param name="idSitio">Identificador del sitio</param>
        public void ResetearUsuarioEnSitio(int idUsuario, int idSitio)
        {
            using (ModelContainer db = new ModelContainer())
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


        public List<UsuarioDTO> Buscar(string query)
        {
            using (ModelContainer db = new ModelContainer())
            {
                IQueryable<Usuario> q =
                    from usu in db.Usuarios
                    where usu.NombreUsuario.ToLower().StartsWith(query.Trim().ToLower())
                    select usu;
                if (q.Count() > 0)
                {
                    return AutoMapperUtils<Usuario, UsuarioDTO>.Map(q.ToList());
                }
                else
                {
                    return new List<UsuarioDTO>();
                }
            }
        }


        public List<UsuarioDTO> ObtenerUsuariosConectados(int idUsuarioActual)
        {
            using (ModelContainer db = new ModelContainer())
            {
                double minutosValidezSesion = HttpContext.Current.Session.Timeout;
                DateTime fechaTope = DateTime.Now.Date.AddMinutes(-1 * minutosValidezSesion);

                IQueryable<Usuario> usuarios = from grupousuarios in db.Usuarios
                               from sesiones in db.Sesiones
                               where grupousuarios.Id != idUsuarioActual
                               where sesiones.Usuario.Id == grupousuarios.Id
                               where sesiones.FechaCierre == null
                               where sesiones.UltimoUso > fechaTope
                               select grupousuarios;

                return AutoMapperUtils<Usuario, UsuarioDTO>.Map(usuarios.ToList());
            }
        }
    }
}


