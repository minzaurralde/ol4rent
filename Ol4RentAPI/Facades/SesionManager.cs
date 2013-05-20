using Ol4RentAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ol4RentAPI.Facades
{
    class SesionManager: ISesionManager
    {
        public void CrearSesion(string nombreUsuario)
        {
            EjecutarOperacion(nombreUsuario, SesionManagerOperation.CREAR);
        }

        public void ActualizarSesion(string nombreUsuario)
        {
            EjecutarOperacion(nombreUsuario, SesionManagerOperation.ACTUALIZAR);
        }

        public void CerrarSesion(string nombreUsuario)
        {
            EjecutarOperacion(nombreUsuario, SesionManagerOperation.CERRAR);
        }

        private void EjecutarOperacion(string nombreUsuario, SesionManagerOperation operacion)
        {
            using (ModelContainer db = new ModelContainer())
            {
                IQueryable<Sesion> query =
                    from s in db.Sesiones
                    where s.Usuario.NombreUsuario == nombreUsuario
                    select s;
                if (query.Count() == 0)
                {
                    IQueryable<Usuario> queryUusario =
                        from usu in db.Usuarios
                        where usu.NombreUsuario == nombreUsuario
                        select usu;
                    if (queryUusario.Count() != 0)
                    {
                        Usuario usuario = queryUusario.First();
                        DateTime? fechaCierre;
                        DateTime fechaConexion;
                        switch (operacion)
                        {
                            case SesionManagerOperation.CERRAR:
                                fechaCierre = DateTime.Now;
                                fechaConexion = fechaCierre.Value.AddMinutes(-1);
                                break;
                            case SesionManagerOperation.CREAR:
                            case SesionManagerOperation.ACTUALIZAR:
                            default:
                                fechaCierre = null;
                                fechaConexion = DateTime.Now;
                                break;
                        }
                        Sesion sesion = new Sesion() { Usuario = usuario, FechaCierre = fechaCierre, FechaConexion = fechaConexion, UltimoUso = DateTime.Now, SesionID = HttpContext.Current.Session.SessionID };
                        db.Sesiones.Add(sesion);
                        db.SaveChanges();
                    }
                }
                else
                {
                    Sesion sesion = query.First();
                    bool actualizarSessionId = sesion.SesionID != HttpContext.Current.Session.SessionID;
                    switch (operacion)
                    {
                        case SesionManagerOperation.CERRAR:
                            sesion.FechaCierre = DateTime.Now;
                            break;
                        case SesionManagerOperation.ACTUALIZAR:
                            sesion.UltimoUso = DateTime.Now;
                            break;
                        case SesionManagerOperation.CREAR:
                            sesion.FechaCierre = null;
                            sesion.FechaConexion = DateTime.Now;
                            sesion.UltimoUso = DateTime.Now;
                            actualizarSessionId = true;
                            break;
                    }
                    if (actualizarSessionId)
                    {
                        sesion.SesionID = HttpContext.Current.Session.SessionID;
                    }
                    db.Entry<Sesion>(sesion).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }


        public bool TieneSesionValida(int idUsuario)
        {
            using (ModelContainer db = new ModelContainer())
            {
                // TODO hay que configurar esto en algun lado
                int minutosValidezSesion = 180;
                var usuarioactual = from sesiones in db.Sesiones
                                    where sesiones.Usuario.Id == idUsuario
                                    where sesiones.FechaConexion == sesiones.FechaCierre
                                    where sesiones.UltimoUso.AddMinutes(minutosValidezSesion) > DateTime.Now.Date
                                    select sesiones;
                return usuarioactual.Count() > 0;
            }
        }

    }

    internal enum SesionManagerOperation
    {
        CREAR, ACTUALIZAR, CERRAR
    }
}
