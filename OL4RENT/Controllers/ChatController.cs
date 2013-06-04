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
using WebMatrix.WebData;

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
        public ActionResult VerificarSesion()
        {
            int useridactual = WebSecurity.GetUserId(User.Identity.Name);
            var estasesionactiva = "0";
            //// No se debe mostrar al usuario actual
            if (ServiceFacadeFactory.Instance.SesionManager.TieneSesionValida(useridactual))
            {
                estasesionactiva = "1";
            }
            return Content(estasesionactiva);
        }

        [HttpPost]
        public ActionResult ObtenerUsuariosOnline()
        {
            //// No se debe mostrar al usuario actual
            int useridactual = WebSecurity.GetUserId(User.Identity.Name);
            List<UsuarioDTO> usuarios = ServiceFacadeFactory.Instance.AccountFacade.ObtenerUsuariosConectados(useridactual);
            string listausuariosonline = "";
            foreach (var usu in usuarios)
            {
                listausuariosonline += usu.Id.ToString() + "-" + usu.Nombre + " " + usu.Apellido + ";";
            }
            return Content(listausuariosonline);
        }

        [HttpPost]
        public ActionResult mensajeinicial(int espero)
        {
            int useridactual = WebSecurity.GetUserId(User.Identity.Name);
            UsuarioDTO usuario = ServiceFacadeFactory.Instance.AccountFacade.Obtener(useridactual);
            
            string Nombre = usuario.Nombre;
            string Apellido = usuario.Apellido;
            string MensajeUsuario = "<font color='#0000FF'><b>Administrador: Bienvenido al Chat " + Nombre + " " + Apellido + ".</b></font>";
            if (espero == 1)
            {
                return Content(MensajeUsuario);
            }
            return Content("");
        }

        // Centinela que indica que no llega el mensaje
        const string nollegamensaje = "-*--*--*-";

        [HttpPost]
        public ActionResult llegamensaje(int espero)
        {
            var textosdespliegues = "";

            int useridactual = WebSecurity.GetUserId(User.Identity.Name);

            List<MensajeDTO> mensajesnoleidos = ServiceFacadeFactory.Instance.MensajeFacade.ObtenerMensajesNoLeidos(useridactual);
            
            var primerorec = 1;

            foreach (var m in mensajesnoleidos)
            {
                var Nombre = m.Remitente.Nombre;
                var Apellido = m.Remitente.Apellido;

                var textomensaje = "";

                if (primerorec == 0)
                {
                    textomensaje = "<BR>";
                }
                textomensaje = textomensaje + "Recibido de " + Nombre + " " + Apellido + ": " + m.Texto + "<BR><font size=2><b>Fecha: " + m.FechaHora.ToString() + "</b></font>";

                if (primerorec == 1)
                {
                    textosdespliegues = textosdespliegues + textomensaje;
                    primerorec = 0;
                }
                /*else
                {
                    textosdespliegues = textosdespliegues + "<BR>" + textomensaje;
                }*/
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
        public ActionResult enviomensaje(string idusuario, string mensaje)
        {
            // Primero verificar si existe el usuario
            // Luego verificar que el usuario siga con la sesion activa
            // Luego verificar si el mensaje tiene contenidos 

            int useridactual = WebSecurity.GetUserId(User.Identity.Name);

            string validoentra = "0";

            try
            {
                // Invocar mensaje en la base de datos
                // hacia el otro usuario
                //// Si no existe el buzon de mensajes para el usuario, se crea
                ServiceFacadeFactory.Instance.MensajeFacade.EnviarMensaje(int.Parse(idusuario), useridactual, mensaje);
                validoentra = "1";
            }
            // Most specific:
            catch (ArgumentNullException e)
            {
                Console.WriteLine("{0} Excepción en Argumento de Chat.", e);
            }
            // Least specific:
            catch (Exception e)
            {
                Console.WriteLine("{0} Excepción en Argumento Genérico de Chat.", e);
            }

            return Content(validoentra);
        }

        public ActionResult ChatUsuario()
        {
            return View();
        }
    }
}
