using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Web.Script.Serialization;

namespace OL4RENT.Controllers
{
    public class ChatController : Controller
    {
        //
        // GET: /Chat/

        public ActionResult Index()
        {
            return View();
        }

        OL4RENT.Views.Chat.ChatEntornoDataContext dc = new OL4RENT.Views.Chat.ChatEntornoDataContext();

        [HttpPost]
        public ActionResult Redireccionar()
        {
            Response.Redirect("http://www.microsoft.com/gohere/look.htm");
            return Content("");
        }

        [HttpPost]
        public ActionResult VerificarSesion(string idusuarioactual)
        {
            var estasesionactiva = "0";
            //// No se debe mostrar al usuario actual

            var usuarioactual = from grupousuarios in dc.Usuarios
                                from sesiones in dc.Sesiones
                                where grupousuarios.Id == int.Parse(idusuarioactual)
                                where sesiones.Usuario_Id == grupousuarios.Id
                                where sesiones.FechaConexion == sesiones.FechaCierre
                                where sesiones.UltimoUso.AddHours(5) > DateTime.Now.Date
                                select grupousuarios;

            if (usuarioactual.Count() > 0)
                estasesionactiva = "1";

            return Content(estasesionactiva);

        }

        [HttpPost]
        public ActionResult ObtenerUsuariosOnline(string idusuarioactual)
        {
            string listausuariosonline = "";

            //// No se debe mostrar al usuario actual
            var usuarios = from grupousuarios in dc.Usuarios
                           from sesiones in dc.Sesiones
                           where grupousuarios.Id != int.Parse(idusuarioactual)
                           where sesiones.Usuario_Id == grupousuarios.Id
                           where sesiones.FechaConexion == sesiones.FechaCierre
                           where sesiones.UltimoUso.AddHours(5) > DateTime.Now.Date
                           select grupousuarios;

            listausuariosonline = "";
            foreach (var usu in usuarios)
            {
                listausuariosonline = listausuariosonline + usu.Id.ToString() + "-" + usu.Nombre + " " + usu.Apellido + ";";
            }

            return Content(listausuariosonline);
        }

        [HttpPost]
        public ActionResult mensajeinicial(string idusuarioactual, int espero)
        {
            var usuarios = from actualusuario in dc.Usuarios
                           where actualusuario.Id == int.Parse(idusuarioactual)
                           select actualusuario;

            if (usuarios.Count() > 0)
            {

                var Nombre = "";
                var Apellido = "";

                foreach (var usu in usuarios)
                {
                    Nombre = usu.Nombre;
                    Apellido = usu.Apellido;
                }

                string MensajeUsuario = "Bienvenido al Chat " + Nombre + " " + Apellido + ".";

                if (espero == 1)
                    return Content("Administrador: " + MensajeUsuario);
                return Content("");

            }
            else
                return Content("");
        }

        const string nollegamensaje = "-*--*--*-";

        [HttpPost]
        public ActionResult llegamensaje(string idusuarioactual, int espero)
        {

            var textosdespliegues = "";

            var mensajesnoleidos = from bm in dc.BuzonesMensajes
                                   from ms in dc.Mensajes
                                   where (bm.UsuarioBuzonMensajes_BuzonMensajes_Id == int.Parse(idusuarioactual))
                                   where bm.Id == ms.MensajeBuzonMensaje_Mensaje_Id
                                   where ms.Leido == false
                                   orderby ms.FechaHora
                                   select ms;

            if (mensajesnoleidos.Count() > 0)
            {
                var primerorec = 1;
                foreach (var m in mensajesnoleidos)
                {

                    var idusurem = m.Remitente_Id;
                    var datousuario = from uss in dc.Usuarios
                                      where uss.Id == idusurem
                                      select uss;

                    var Nombre = "";
                    var Apellido = "";
                    foreach (var usu in datousuario)
                    {
                        Nombre = usu.Nombre;
                        Apellido = usu.Apellido;
                    }

                    var textomensaje = "";

                    if (primerorec == 0)
                    {
                        textomensaje = "\n";
                    }

                    textomensaje = textomensaje + "Recibido de " + Nombre + " " + Apellido + ": " + m.Texto + "\nFecha: " + m.FechaHora.ToString();

                    if (primerorec == 1)
                    {
                        textosdespliegues = textosdespliegues + textomensaje;
                        primerorec = 0;
                    }
                    else
                    {
                        textosdespliegues = textosdespliegues + "\n" + textomensaje;
                    }

                    //// Pasar la variable como leido=True
                    m.Leido = true;

                }

                ///textosdespliegues = textosdespliegues + "\n";
                dc.SubmitChanges();
                return Content(textosdespliegues);

            }
            else
                return Content(nollegamensaje);

        }

        [HttpPost]
        public ActionResult enviomensaje(string idremitente, string idusuario, string mensaje)
        {
            // Primero verificar si existe el usuario

            // Luego verificar que el usuario siga con la sesion activa

            // Luego verificar si el mensaje tiene contenidos 
            string validoentra = "0";

            try
            {
                // Invocar mensaje en la base de datos
                // hacia el otro usuario

                //// Si no existe el buzon de mensajes para el usuario, se crea

                var buzonm = from mb in dc.BuzonesMensajes
                             where mb.UsuarioBuzonMensajes_BuzonMensajes_Id == int.Parse(idusuario)
                             select mb;

                OL4RENT.Views.Chat.BuzonesMensaje bz = null;

                if (buzonm.Count() == 0)
                {
                    bz = new OL4RENT.Views.Chat.BuzonesMensaje();
                    bz.UsuarioBuzonMensajes_BuzonMensajes_Id = int.Parse(idusuario);
                    dc.BuzonesMensajes.InsertOnSubmit(bz);
                }
                else
                {
                    bz = buzonm.First();
                }

                OL4RENT.Views.Chat.Mensaje m = new OL4RENT.Views.Chat.Mensaje();
                m.Leido = false;
                m.Remitente_Id = int.Parse(idremitente);
                m.Texto = mensaje;
                m.MensajeBuzonMensaje_Mensaje_Id = bz.Id;
                m.FechaHora = DateTime.Now;
                dc.Mensajes.InsertOnSubmit(m);

                bz.Mensajes.Add(m);

                dc.SubmitChanges();

                validoentra = "1";

            }
            // Most specific:
            catch (ArgumentNullException e)
            {
                Console.WriteLine("{0} First exception caught.", e);
            }
            // Least specific:
            catch (Exception e)
            {
                Console.WriteLine("{0} Second exception caught.", e);
            }

            return Content(validoentra);
        }

        public ActionResult ChatUsuario()
        {
            return View();
        }



    }
}
