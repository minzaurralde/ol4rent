using OL4RENT.Controllers;
using OL4RENT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OL4RENT.App_Start
{
    public static class DatabaseConfig
    {
        public static void RegisterContexts()
        {
            Database.SetInitializer<BienContext>(null);
            BienContext bc = new BienContext();
            bc.Database.CreateIfNotExists();

            Database.SetInitializer<NovedadContext>(null);
            NovedadContext nc = new NovedadContext();
            nc.Database.CreateIfNotExists();

            Database.SetInitializer<SitioContext>(null);
            SitioContext sc = new SitioContext();
            sc.Database.CreateIfNotExists();

            // CrearNovedadesFalsas();
            // CrearBienesFalsos();
            // CrearSitioFalso();
        }

        private static void CrearSitioFalso()
        {
            SitioContext contexto = new SitioContext();
            Sitio sitio = new Sitio();
            sitio.Nombre = "Default Site";
            contexto.Sitios.Add(sitio);
            contexto.SaveChanges();
        }

        private static void CrearBienesFalsos()
        {
            BienContext contexto = new BienContext();
            Bien bien = new Bien();
            bien.Nombre = "Casa en Piriapolis";
            bien.Descripcion = bien.Nombre;
            bien.Latitud = -34.900574;
            bien.Longitud = -56.172409;
            contexto.Bienes.Add(bien);
            bien = new Bien();
            bien.Nombre = "Casa en Pueblo Ansina";
            bien.Descripcion = bien.Nombre;
            bien.Latitud = -34.887057;
            bien.Longitud = -56.171036;
            contexto.Bienes.Add(bien);
            bien = new Bien();
            bien.Nombre = "Casa en Cerro Chato";
            bien.Descripcion = bien.Nombre;
            bien.Latitud = -34.851002;
            bien.Longitud = -56.206055;
            contexto.Bienes.Add(bien);
            bien = new Bien();
            bien.Nombre = "Casa en San Bautista";
            bien.Descripcion = bien.Nombre;
            bien.Latitud = -34.839168;
            bien.Longitud = -56.15387;
            contexto.Bienes.Add(bien);
            contexto.SaveChanges();
        }

        private static void CrearNovedadesFalsas()
        {
            NovedadContext contexto = new NovedadContext();
            Novedad novedad = new Novedad();
            novedad.Nombre = "Alquileres de casas en Punta Espinillos";
            contexto.Novedades.Add(novedad);
            novedad = new Novedad();
            novedad.Nombre = "Nueva ley para alquileres";
            contexto.Novedades.Add(novedad);
            novedad = new Novedad();
            novedad.Nombre = "Siguen subiendo los precios de los inmuebles";
            contexto.Novedades.Add(novedad);
            novedad = new Novedad();
            novedad.Nombre = "Paco Casal se mete en el negocio";
            contexto.Novedades.Add(novedad);
            novedad = new Novedad();
            novedad.Nombre = "Aparecen nuevos fondos";
            contexto.Novedades.Add(novedad);
            novedad = new Novedad();
            novedad.Nombre = "Mas alquileres disponibles a orillas del Olimar";
            contexto.Novedades.Add(novedad);
            novedad = new Novedad();
            novedad.Nombre = "Se derrumbo casa de alquiler en Punta Colorada";
            contexto.Novedades.Add(novedad);
            novedad = new Novedad();
            novedad.Nombre = "Los alquileres siguen caros";
            contexto.Novedades.Add(novedad);
            novedad = new Novedad();
            novedad.Nombre = "Nuevo sitio: OL4RENT";
            contexto.Novedades.Add(novedad);
            contexto.SaveChanges();
        }
    }
}