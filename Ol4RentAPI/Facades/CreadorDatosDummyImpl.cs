using Ol4RentAPI.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.Facades
{
    class CreadorDatosDummyImpl: ICreadorDatosDummyFacade
    {
        public void CrearSitios()
        {
            using (ModelContainer c = new ModelContainer())
            {
                Sitio s = new Sitio();
                s.Nombre = "Autos";
                s.Descripcion = "Sitio de autos";
                List<Caracteristica> caracteristicas = new List<Caracteristica>();
                caracteristicas.Add(new Caracteristica() { Nombre = "Marca", Tipo = TipoDato.STRING });
                caracteristicas.Add(new Caracteristica() { Nombre = "Modelo", Tipo = TipoDato.STRING });
                caracteristicas.Add(new Caracteristica() { Nombre = "Año", Tipo = TipoDato.ENTERO });
                caracteristicas.Add(new Caracteristica() { Nombre = "Pais de Origen", Tipo = TipoDato.STRING });
                s.TipoBien = new TipoBien() { Nombre = "Auto", Caracteristicas = caracteristicas };
                s.URL = "autos.ol4rent.com";
                s.Logo = File.ReadAllBytes(@"C:\Users\Martin\Desktop\Sitioase (1)\Autos.png");
                s.CSS = File.ReadAllBytes(@"C:\Users\Martin\Desktop\Sitioase (1)\Autos.css");
                s.MailAdmin = "eminzaurralde@gmail.com";
                c.SaveChanges();

                s = new Sitio();
                s.Nombre = "Casas";
                s.Descripcion = "Sitio de casas";
                caracteristicas = new List<Caracteristica>();
                caracteristicas.Add(new Caracteristica() { Nombre = "Cantidad Dormitorios", Tipo = TipoDato.ENTERO });
                caracteristicas.Add(new Caracteristica() { Nombre = "Descripcion", Tipo = TipoDato.STRING });
                caracteristicas.Add(new Caracteristica() { Nombre = "Año", Tipo = TipoDato.ENTERO });
                s.TipoBien = new TipoBien() { Nombre = "Casa", Caracteristicas = caracteristicas };
                s.URL = "casas.ol4rent.com";
                s.Logo = File.ReadAllBytes(@"C:\Users\Martin\Desktop\Sitioase (1)\Casas.png");
                s.CSS = File.ReadAllBytes(@"C:\Users\Martin\Desktop\Sitioase (1)\Casas.css");
                s.MailAdmin = "eminzaurralde@gmail.com";
                c.SaveChanges();

                s = new Sitio();
                s.Nombre = "Camellos";
                s.Descripcion = "Sitio de cammellos";
                caracteristicas = new List<Caracteristica>();
                caracteristicas.Add(new Caracteristica() { Nombre = "Cantidad Jorobas", Tipo = TipoDato.ENTERO });
                caracteristicas.Add(new Caracteristica() { Nombre = "Descripcion", Tipo = TipoDato.STRING });
                caracteristicas.Add(new Caracteristica() { Nombre = "Edad", Tipo = TipoDato.ENTERO });
                s.TipoBien = new TipoBien() { Nombre = "Camello", Caracteristicas = caracteristicas };
                s.URL = "camellos.ol4rent.com";
                s.Logo = File.ReadAllBytes(@"C:\Users\Martin\Desktop\Sitioase (1)\Camellos.png");
                s.CSS = File.ReadAllBytes(@"C:\Users\Martin\Desktop\Sitioase (1)\Camellos.css");
                s.MailAdmin = "eminzaurralde@gmail.com";
                c.SaveChanges();

                s = new Sitio();
                s.Nombre = "Perros";
                s.Descripcion = "Sitio de perros";
                caracteristicas = new List<Caracteristica>();
                caracteristicas.Add(new Caracteristica() { Nombre = "Raza", Tipo = TipoDato.STRING });
                caracteristicas.Add(new Caracteristica() { Nombre = "Descripcion", Tipo = TipoDato.STRING });
                caracteristicas.Add(new Caracteristica() { Nombre = "Edad", Tipo = TipoDato.ENTERO });
                s.TipoBien = new TipoBien() { Nombre = "Perro", Caracteristicas = caracteristicas };
                s.URL = "perros.ol4rent.com";
                s.Logo = File.ReadAllBytes(@"C:\Users\Martin\Desktop\Sitioase (1)\Perros.png");
                s.CSS = File.ReadAllBytes(@"C:\Users\Martin\Desktop\Sitioase (1)\Perros.css");
                s.MailAdmin = "eminzaurralde@gmail.com";
                c.SaveChanges();

                s = new Sitio();
                s.Nombre = "Tornillos";
                s.Descripcion = "Sitio de tornillos";
                caracteristicas = new List<Caracteristica>();
                caracteristicas.Add(new Caracteristica() { Nombre = "Material", Tipo = TipoDato.STRING });
                caracteristicas.Add(new Caracteristica() { Nombre = "Tamaño", Tipo = TipoDato.ENTERO });
                s.TipoBien = new TipoBien() { Nombre = "Tornillo", Caracteristicas = caracteristicas };
                s.URL = "tornillos.ol4rent.com";
                s.Logo = File.ReadAllBytes(@"C:\Users\Martin\Desktop\Sitioase (1)\Tornillos.png");
                s.CSS = File.ReadAllBytes(@"C:\Users\Martin\Desktop\Sitioase (1)\Tornillos.css");
                s.MailAdmin = "eminzaurralde@gmail.com";
                c.SaveChanges();
            }
        }
    }
}
