using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Web.Script.Serialization;
using Ol4RentAPI.Facades;
using Ol4RentAPI.DTO;

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
            if (ServiceFacadeFactory.Instance.SesionManager.TieneSesionValida(int.Parse(idusuarioactual)))
            {
                estasesionactiva = "1";
            }
            return Content(estasesionactiva);
        }

        [HttpPost]
        public ActionResult ObtenerUsuariosOnline(string idusuarioactual)
        {
            //// No se debe mostrar al usuario actual
            List<UsuarioDTO> usuarios = ServiceFacadeFactory.Instance.AccountFacade.ObtenerUsuariosConectados(int.Parse(idusuarioactual));
            string listausuariosonline = "";
            foreach (var usu in usuarios)
            {
                listausuariosonline += usu.Id.ToString() + "-" + usu.Nombre + " " + usu.Apellido + ";";
            }
            return Content(listausuariosonline);
        }

        [HttpPost]
        public ActionResult mensajeinicial(string idusuarioactual, int espero)
        {
            UsuarioDTO usuario = ServiceFacadeFactory.Instance.AccountFacade.Obtener(int.Parse(idusuarioactual));

            string Nombre = usuario.Nombre;
            string Apellido = usuario.Apellido;
            string MensajeUsuario = "Bienvenido al Chat " + Nombre + " " + Apellido + ".";
            if (espero == 1)
            {
                return Content("Administrador: " + MensajeUsuario);
            }
            return Content("");
        }

        // Centinela que indica que no llega el mensaje
        const string nollegamensaje = "-*--*--*-";

        [HttpPost]
        public ActionResult llegamensaje(string idusuarioactual, int espero)
        {
            var textosdespliegues = "";
            List<MensajeDTO> mensajesnoleidos = ServiceFacadeFactory.Instance.MensajeFacade.ObtenerMensajesNoLeidos(int.Parse(idusuarioactual));
            var primerorec = 1;
            foreach (var m in mensajesnoleidos)
            {
                var Nombre = m.Remitente.Nombre;
                var Apellido = m.Remitente.Apellido;

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
                ServiceFacadeFactory.Instance.MensajeFacade.MarcarComoLeido(m.Id);
            }
            ///textosdespliegues = textosdespliegues + "\n";
            if (textosdespliegues.Trim() != "")
                return Content(textosdespliegues);
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
                ServiceFacadeFactory.Instance.MensajeFacade.EnviarMensaje(int.Parse(idusuario), int.Parse(idremitente), mensaje);
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
