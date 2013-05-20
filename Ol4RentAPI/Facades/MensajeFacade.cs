using Ol4RentAPI.DTO;
using Ol4RentAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.Facades
{
    class MensajeFacade: IMensajeFacade
    {
        public List<MensajeDTO> ObtenerMensajesNoLeidos(int idUsuario)
        {
            using (ModelContainer db = new ModelContainer())
            {
                IQueryable<Mensaje> mensajesnoleidos = 
                                       from usu in db.Usuarios
                                       from bm in usu.BuzonesMensajes
                                       from ms in bm.Mensajes
                                       where usu.Id == idUsuario
                                       where ms.Leido == false
                                       orderby ms.FechaHora
                                       select ms;
                return AutoMapperUtils<Mensaje, MensajeDTO>.Map(mensajesnoleidos.ToList());
            }
        }


        public void MarcarComoLeido(int id)
        {
            using (ModelContainer db = new ModelContainer())
            {
                Mensaje mensaje = db.Mensajes.Find(id);
                mensaje.Leido = true;
                db.Entry<Mensaje>(mensaje).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void EnviarMensaje(int idUsuario, int idRemitente, string textoMensaje)
        {
            using (ModelContainer db = new ModelContainer())
            {
                IQueryable<BuzonMensajes> qBuzon =
                    from usu in db.Usuarios
                    from buz in usu.BuzonesMensajes
                    from msgs in buz.Mensajes
                    where usu.Id == idUsuario
                    where msgs.Remitente.Id == idRemitente
                    select buz;
                BuzonMensajes buzon;
                if (qBuzon.Count() == 0)
                {
                    Usuario usuario = db.Usuarios.Find(idUsuario);
                    buzon = new BuzonMensajes() { Mensajes = new List<Mensaje>() };
                    usuario.BuzonesMensajes.Add(buzon);
                    db.BuzonesMensajes.Add(buzon);
                    db.SaveChanges();
                }
                else
                {
                    buzon = qBuzon.First();
                }
                Usuario remitente = db.Usuarios.Find(idRemitente);
                Mensaje mensaje = new Mensaje() { FechaHora = DateTime.Now, Remitente = remitente, Leido = false, Texto = textoMensaje };
                buzon.Mensajes.Add(mensaje);
                db.Mensajes.Add(mensaje);
                db.SaveChanges();
            }
        }
    }
}
