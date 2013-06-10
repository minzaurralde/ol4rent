using Ol4RentAPI.DTO;
using Ol4RentAPI.Model;
using Ol4RentAPI.Facades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net.Mail;
using System.Net.Mime;
using System.Data.Objects.SqlClient;

namespace Ol4RentAPI.Facades
{
    class BienFacadeImpl : IBienFacade
    {
        public BienEdicionDTO Obtener(int id)
        {
            using (ModelContainer db = new ModelContainer())
            {
                IQueryable<Bien> queryBien =
                    from b in db.Bienes
                    where b.Id == id
                    select b;
                if (queryBien.Count() > 0)
                {
                    return AutoMapperUtils<Bien, BienEdicionDTO>.Map(queryBien.First());
                }
                else
                {
                    return null;
                }
            }
        }

        public BienArrendarDTO ObtenerArrendar(int id)
        {
            using (ModelContainer db = new ModelContainer())
            {
                IQueryable<Bien> queryBien =
                    from b in db.Bienes
                    where b.Id == id
                    select b;
                if (queryBien.Count() > 0)
                {
                    return AutoMapperUtils<Bien, BienArrendarDTO>.Map(queryBien.First());
                }
                else
                {
                    return null;
                }
            }
        }

        public bool Arrendar(BienArrendarDTO bienDTO, string usuario)
        {
            try
            {
               using (ModelContainer db = new ModelContainer())
                {
                    IQueryable<Bien> queryBien =
                        from b in db.Bienes
                        where b.Id == bienDTO.Id && b.Usuario.NombreUsuario != usuario && b.FechaAlquiler == null && b.DuracionAlquiler == null
                        select b;
                    if (queryBien.Count() > 0)
                    {
                        Bien bien = queryBien.First();
                        bien.FechaAlquiler = bienDTO.FechaAlquiler;
                        bien.DuracionAlquiler = bienDTO.DuracionAlquiler;
                        db.Entry(bien).State = EntityState.Modified;
                        db.SaveChanges();
                        //Envío de mail de alerta
                        MailMessage mail = new MailMessage();
                        SmtpClient sc = new SmtpClient();
                        mail.From = new MailAddress("gr6tsi1@gmail.com", "Ol4Rent");
                        mail.To.Add(new MailAddress(bien.Usuario.Mail, bien.Usuario.Nombre + " " + bien.Usuario.Apellido));
                        //m.CC.Add(new MailAddress("CC@yahoo.com", "Display name CC"));
                        //similarly BCC
                        mail.Subject = "Se arrendo un bien suyo";
                        var body = "Estimado Cliente, se a Arrendado el Bien: " + bien.Titulo + "\n";
                        body = body + "Desde la fecha: " + bien.FechaAlquiler.ToString() + "\n";
                        body = body + "Por un periodo: " + bien.DuracionAlquiler.ToString();
                        mail.Body = body;
                        sc.Host = "smtp.gmail.com";
                        sc.Port = 587;
                        sc.Credentials = new System.Net.NetworkCredential("gr6tsi1@gmail.com", "gr643210");
                        sc.EnableSsl = true; // runtime encrypt the SMTP communications using SSL
                        sc.Send(mail);
                        // Fin
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }catch
            {
                return false;
            }
        }

        public bool Crear(BienAltaDTO bienDTO)
        {

            using (ModelContainer db = new ModelContainer())
            {
                // Obtengo el usuario
                IQueryable<Usuario> usuarios =
                    from u in db.Usuarios
                    where u.NombreUsuario == bienDTO.Usuario
                    select u;
                Usuario usuario = null;
                if (usuarios.Count() > 0)
                {
                    usuario = usuarios.First();
                }
                if (usuario == null) return false;


                Bien bien = new Bien()
                {
                    Titulo = bienDTO.Titulo,
                    Descripcion = bienDTO.Descripcion,
                    Foto = bienDTO.Foto,
                    Latitud = bienDTO.Latitud,
                    Longitud = bienDTO.Longitud,
                    Direccion = bienDTO.Direccion,
                    Normas = bienDTO.Normas,
                    Capacidad = bienDTO.Capacidad,
                    Precio = bienDTO.Precio,
                    TipoBien = db.TiposBienes.Find(bienDTO.TipoBien),
                    Usuario = usuario,
                    FechaAlta = DateTime.Now,
                    ValoresCaracteristicas = new List<ValorCaracteristica>()
                };
                foreach (ValorCaracteristicaAltaDTO valorCaracteristicaDTO in bienDTO.ValoresCaracteristicas)
                {
                    bien.ValoresCaracteristicas.Add(new ValorCaracteristica()
                    {
                        Valor = valorCaracteristicaDTO.Valor,
                        Caracteristica = db.Caracteristicas.Find(valorCaracteristicaDTO.IdCaracteristica)
                    });
                }
                try
                {
                    db.Bienes.Add(bien);
                    db.SaveChanges();
                    ServiceFacadeFactory.Instance.EspecificacionBienFacade.BuscarCoincidencias(bien.Id);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool Editar(BienEdicionDTO bienDTO)
        {
            try
            {
                using (ModelContainer db = new ModelContainer())
                {
                    Bien bien = db.Bienes.Find(bienDTO.Id);
                    bool seModifico = false;
                    if (bien.Titulo != bienDTO.Titulo)
                    {
                        bien.Titulo = bienDTO.Titulo;
                        seModifico = true;
                    }
                    if (bien.Descripcion != bienDTO.Descripcion)
                    {
                        bien.Descripcion = bienDTO.Descripcion;
                        seModifico = true;
                    }
                    if (bien.Capacidad != bienDTO.Capacidad)
                    {
                        bien.Capacidad = bienDTO.Capacidad;
                        seModifico = true;
                    }
                    if (bien.Direccion != bienDTO.Direccion)
                    {
                        bien.Direccion = bienDTO.Direccion;
                        seModifico = true;
                    }
                    if (bien.Foto != bienDTO.Foto)
                    {
                        bien.Foto = bienDTO.Foto;
                        seModifico = true;
                    }
                    if (bien.Normas != bienDTO.Normas)
                    {
                        bien.Normas = bienDTO.Normas;
                        seModifico = true;
                    }
                    if (bien.Precio != bienDTO.Precio)
                    {
                        bien.Precio = bienDTO.Precio;
                        seModifico = true;
                    }
                    if (bien.Latitud != bienDTO.Latitud)
                    {
                        bien.Latitud = bienDTO.Latitud;
                        seModifico = true;
                    }
                    if (bien.Longitud != bienDTO.Longitud)
                    {
                        bien.Longitud = bienDTO.Longitud;
                        seModifico = true;
                    }
                    bool salvar = false;
                    foreach (ValorCaracteristicaListadoDTO valorDTO in bienDTO.ValoresCaracteristicas)
                    {
                        ValorCaracteristica valor = bien.ValoresCaracteristicas.Where(a => a.Id == valorDTO.Id).First();
                        if (valor.Valor != valorDTO.Valor)
                        {
                            valor.Valor = valorDTO.Valor;
                            db.Entry(valor).State = EntityState.Modified;
                            salvar = true;
                        }
                    }
                    if (seModifico)
                    {
                        db.Entry(bien).State = EntityState.Modified;
                    }
                    if (seModifico || salvar)
                    {
                        db.SaveChanges();
                    }
                }
                return true;
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
                Bien bien = db.Bienes.Find(id);
                List<ValorCaracteristica> valores = new List<ValorCaracteristica>(bien.ValoresCaracteristicas);
                foreach (ValorCaracteristica vc in valores)
                {
                    db.ValoresCaracteristicas.Remove(vc);
                }
                bien.ValoresCaracteristicas.Clear();
                db.Bienes.Remove(bien);
                db.SaveChanges();
            }
        }

        public List<BienListadoDTO> Buscar(string query)
        {
            if (query != null)
            {
                // TODO pasar a linq
                using (ModelContainer db = new ModelContainer())
                {
                    return AutoMapperUtils<Bien, BienListadoDTO>.Map(db.Bienes.Where(b => b.Descripcion.ToLower().Contains(query.ToLower()) || b.Titulo.ToLower().Contains(query.ToLower())).ToList());
                }
            }
            else
            {
                return new List<BienListadoDTO>();
            }
        }

        public List<BienListadoDTO> BusquedaAvanzada(BusquedaAvanzadaDTO templateBien)
        {
            using (ModelContainer db = new ModelContainer())
            {
                List<Bien> bienes = db.Bienes.ToList();
                bool huboBusqueda = false;
                // busco por titulo
                if (templateBien.Titulo != null && templateBien.Titulo.Trim() != "")
                {
                    huboBusqueda = true;
                    bienes = bienes.Where(b => b.Titulo.ToLower().Contains(templateBien.Titulo.ToLower())).ToList();
                }
                // busco por descripcion
                if (templateBien.Descripcion != null && templateBien.Descripcion.Trim() != "")
                {
                    huboBusqueda = true;
                    bienes = bienes.Where(b => b.Descripcion.ToLower().Contains(templateBien.Descripcion.ToLower())).ToList();
                }
                // busco por normas
                if (templateBien.Normas != null && templateBien.Normas.Trim() != "")
                {
                    huboBusqueda = true;
                    bienes = bienes.Where(b => b.Normas.ToLower().Contains(templateBien.Normas.ToLower())).ToList();
                }
                // busco por propietario
                if (templateBien.Propietario != null && templateBien.Propietario.Trim() != "")
                {
                    huboBusqueda = true;
                    bienes = bienes.Where(b => b.Usuario.NombreUsuario.ToLower().Contains(templateBien.Propietario.ToLower())).ToList();
                }
                // busco por precio
                decimal precioMinimo = decimal.MinValue;
                decimal precioMaximo = decimal.MaxValue;
                try
                {
                    precioMinimo = decimal.Parse(templateBien.PrecioMinimo);
                    huboBusqueda = true;
                }
                catch
                {
                }
                try
                {
                    precioMaximo = decimal.Parse(templateBien.PrecioMaximo);
                    huboBusqueda = true;
                }
                catch
                {
                }
                bienes = bienes.Where(b => b.Precio <= precioMaximo && b.Precio >= precioMinimo).ToList();
                // busco por caracteristicas
                foreach (ValorCaracteristicaAltaDTO valorCaracteristica in templateBien.ValoresCaracteristicas)
                {
                    if (valorCaracteristica.Valor != null && valorCaracteristica.Valor.Trim() != "")
                    {
                        Caracteristica caracteristica = db.Caracteristicas.Find(valorCaracteristica.IdCaracteristica);
                        if (caracteristica.Tipo == TipoDato.STRING)
                        {
                            bienes = bienes.Where(b => b.ValoresCaracteristicas.Where(vc => vc.Caracteristica.Id == valorCaracteristica.IdCaracteristica && vc.Valor.ToLower().Contains(valorCaracteristica.Valor.ToLower())).Count() > 0).ToList();
                        }
                        else if (caracteristica.Tipo == TipoDato.BOOLEANO)
                        {
                            bool valor;
                            if (bool.TryParse(valorCaracteristica.Valor, out valor))
                            {
                                if (valor)
                                {
                                    bienes = bienes.Where(b => b.ValoresCaracteristicas.Where(vc => vc.Caracteristica.Id == valorCaracteristica.IdCaracteristica && vc.Valor == valorCaracteristica.Valor).Count() > 0).ToList();
                                }
                            }
                        }
                        else
                        {
                            bienes = bienes.Where(b => b.ValoresCaracteristicas.Where(vc => vc.Caracteristica.Id == valorCaracteristica.IdCaracteristica && vc.Valor == valorCaracteristica.Valor).Count() > 0).ToList();
                        }
                        huboBusqueda = true;
                    }
                }
                // retorno
                if (huboBusqueda)
                {
                    return AutoMapperUtils<Bien, BienListadoDTO>.Map(bienes);
                }
                else
                {
                    return new List<BienListadoDTO>();
                }
            }
        }

        public List<BienListadoDTO> MisBienes(string usuario, int sitio)
        {
            using (ModelContainer db = new ModelContainer())
            {
                IQueryable<Bien> queryBien =
                    from b in db.Bienes
                    where b.Usuario.NombreUsuario == usuario && b.TipoBien.Sitio.Id == sitio
                    select b;
                if (queryBien.Count() > 0)
                {
                    return AutoMapperUtils<Bien, BienListadoDTO>.Map(queryBien.ToList());
                }
                else
                {
                    return new List<BienListadoDTO>();
                }
            }
        }

        public List<BienListadoDTO> BienesPopulares()
        {
            {
                using (ModelContainer db = new ModelContainer())
                {
                    try
                    {
                        SitioListadoDTO sitioDTO = HttpContext.Current.Session["sitio"] as SitioListadoDTO;
                        Sitio sitio = db.Sitios.Find(sitioDTO.Id);
                        int maximaCantidadPopulares = sitio.CantBienesPopulares;
                        IQueryable<Bien> query =
                            from mg in db.MeGusta
                            where mg.Bien.TipoBien.Sitio.Id == sitio.Id
                            group mg by mg.Bien into mgg
                            orderby mgg.Count() descending
                            select mgg.Key;
                        if (query.Count() > 0)
                        {
                            return AutoMapperUtils<Bien, BienListadoDTO>.Map(query.Take(maximaCantidadPopulares).ToList());
                        }
                        else
                        {
                            // Si la query es vacia, es porque ningun bien tiene marcas de me gusta
                            // Devuelvo todos
                            query =
                                from b in db.Bienes
                                where b.TipoBien.Sitio.Id == sitio.Id
                                select b;
                            if (query.Count() > 0)
                                return AutoMapperUtils<Bien, BienListadoDTO>.Map(query.Take(maximaCantidadPopulares).ToList());
                            else
                                return new List<BienListadoDTO>();
                        }
                    }
                    catch
                    {
                        return new List<BienListadoDTO>();
                    }
                }
            }
        }

        public List<BienListadoDTO> Todos()
        {
            {
                using (ModelContainer db = new ModelContainer())
                {
                    return AutoMapperUtils<Bien, BienListadoDTO>.Map(db.Bienes.ToList());
                }
            }
        }

        public BienEdicionDTO ObtenerBienParaContenido(int idContenido)
        {
            using (ModelContainer db = new ModelContainer())
            {
                IQueryable<Bien> query =
                    from b in db.Bienes
                    where b.Contenidos.Where(c => c.Id == idContenido).Count() > 0
                    select b;
                if (query.Count() > 0)
                {
                    return AutoMapperUtils<Bien, BienEdicionDTO>.Map(query.First());
                }
                else
                {
                    return null;
                }
            }
        }

        public List<ContenidoDTO> ContenidosInadecuadosPorSitio(int idSitio)
        {
            using (ModelContainer db = new ModelContainer())
            {
                IQueryable<Contenido> query =
                    from cont in db.Contenidos
                    where db.Bienes.Where(b =>
                                b.TipoBien.Sitio.Id == idSitio
                                && b.Contenidos.Where(c => c.Id == cont.Id).Count() > 0).Count() > 0
                    orderby cont.CantMarcas descending
                    select cont;
                if (query.Count() > 0)
                {
                    return AutoMapperUtils<Contenido, ContenidoDTO>.Map(query.ToList());
                }
                else
                {
                    return new List<ContenidoDTO>();
                }
            }
        }

        public List<ContenidoDTO> ObtenerComentariosBien(int idBien)
        {
            using (ModelContainer db = new ModelContainer())
            {
                Bien bien = db.Bienes.Find(idBien);
                return AutoMapperUtils<Contenido, ContenidoDTO>.Map(bien.Contenidos.ToList());
            }
        }

        public RegistroBienDTO RegistroDeBienesEnTiempo(int idSitio, DateTime fechaInicio, DateTime fechaFin)
        {
            using (ModelContainer db = new ModelContainer())
            {
                TimeSpan diff = fechaFin - fechaInicio;
                // TODO falta la fecha de alta en el bien
                IQueryable<Bien> query =
                    from b in db.Bienes
                    where b.TipoBien.Sitio.Id == idSitio
                    where b.FechaAlta >= fechaInicio
                    where b.FechaAlta <= fechaFin
                    select b;
                if (diff.Days > 750)
                {
                    return new RegistroBienDTO()
                    {
                        Valores = query
                            .GroupBy(b => SqlFunctions.StringConvert((decimal)b.FechaAlta.Year).Trim())
                            .Select(mes => new ValorRegistroBienDTO() { Etiqueta = mes.Key, Cantidad = mes.Count() })
                            .ToList(),
                        Tipo = "Año"
                    };
                }
                else if (diff.Days > 31)
                {
                    return new RegistroBienDTO()
                    {
                        Valores = query
                            .GroupBy(b => SqlFunctions.StringConvert((decimal)b.FechaAlta.Month).Trim() + "-" + SqlFunctions.StringConvert((decimal)b.FechaAlta.Year).Trim())
                            .Select(mes => new ValorRegistroBienDTO() { Etiqueta = mes.Key, Cantidad = mes.Count() })
                            .ToList(),
                        Tipo = "Mes"
                    };
                }
                else
                {
                    return new RegistroBienDTO()
                    {
                        Valores = query
                            .GroupBy(b => SqlFunctions.StringConvert((decimal)b.FechaAlta.Day).Trim() + "-" + SqlFunctions.StringConvert((decimal)b.FechaAlta.Month).Trim())
                            .Select(dia => new ValorRegistroBienDTO() { Etiqueta = dia.Key, Cantidad = dia.Count() })
                            .ToList(),
                        Tipo = "Día"
                    };
                }
            }
        }

        public void Like(string nombreUsuario, int idBien)
        {
            using (ModelContainer db = new ModelContainer())
            {
                IQueryable<MeGusta> queryVerificacion =
                    from mg in db.MeGusta
                    where mg.Usuario.NombreUsuario == nombreUsuario
                    where mg.Bien.Id == idBien
                    select mg;
                if (queryVerificacion.Count() == 0)
                {
                    Usuario usuario = (from usu in db.Usuarios where usu.NombreUsuario == nombreUsuario select usu).First();
                    Bien bien = db.Bienes.Find(idBien);
                    if (bien.Usuario.NombreUsuario != nombreUsuario)
                    {
                        MeGusta megusta = new MeGusta() { Fecha = DateTime.Now, Usuario = usuario, Bien = bien };
                        db.MeGusta.Add(megusta);
                        db.SaveChanges();
                    }
                }
			}
		}

        public byte[] Foto(int idBien)
        {
            using (ModelContainer db = new ModelContainer())
            {
                Bien bien = db.Bienes.Find(idBien);
                if (bien != null)
                {
                    return bien.Foto;
                }
                else
                {
                    return null;
                }
            }
        }


        public bool PuedeMostrarMeGusta(int idBien)
        {
            using (ModelContainer db = new ModelContainer())
            {
                string nombreUsuario = HttpContext.Current.User.Identity.Name;
                IQueryable<Usuario> queryUsuario =
                    from usu in db.Usuarios where usu.NombreUsuario == nombreUsuario select usu;
                if (queryUsuario.Count() == 0)
                {
                    return false;
                }
                else
                {
                    Usuario usuario = queryUsuario.First();
                    if (usuario == null)
                    {
                        return false;
                    }
                    else
                    {
                        Bien bien = db.Bienes.Find(idBien);
                        if (bien == null)
                        {
                            return false;
                        }
                        else if (bien.Usuario.Id.Equals(usuario.Id))
                        {
                            return false;
                        }
                        else
                        {
                            IQueryable<MeGusta> query =
                                from mg in db.MeGusta
                                where mg.Usuario.NombreUsuario == nombreUsuario
                                where mg.Bien.Id == idBien
                                select mg;
                            return query.Count() == 0;
                        }
                    }
                }
            }
        }

        public List<BienCercanoDTO> ObtenerBienesCercanos(double longitud, double latitud)
        {
            using (ModelContainer db = new ModelContainer())
            {
                IQueryable<Bien> bienescer = 
                    (
                        from bienescerc in db.Bienes
                        orderby Math.Pow((double)((double)bienescerc.Longitud - longitud), 2) + Math.Pow((double)((double)bienescerc.Latitud - latitud), 2)
                        select bienescerc
                    ).Take(10);

                return AutoMapperUtils<Bien, BienCercanoDTO>.Map(bienescer.ToList());
            }
        }

        public int CantidadLikes(int idBien)
        {
            using (ModelContainer db = new ModelContainer())
            {
                IQueryable<MeGusta> query =
                    (
                        from mg in db.MeGusta
                        where mg.Bien.Id == idBien
                        select mg
                    );

                return query.Count();
            }
        }
    }
}

