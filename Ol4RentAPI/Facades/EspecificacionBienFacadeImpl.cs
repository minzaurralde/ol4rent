using Ol4RentAPI.DTO;
using Ol4RentAPI.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.Mime;

namespace Ol4RentAPI.Facades
{
    class EspecificacionBienFacadeImpl : IEspecificacionBienFacade
    {
        public List<EspecificacionBien> Todos 
        {
            get {
                using (ModelContainer db = new ModelContainer())
                {
                    return db.EspecificacionesBienes.ToList();
                }
            }
        }

        public EspecificacionBienDTO Obtener(int id)
        {
            try
            {
                using (ModelContainer db = new ModelContainer())
                {
                    return AutoMapperUtils<EspecificacionBien, EspecificacionBienDTO>.Map(db.EspecificacionesBienes.Find(id));
                }
            }
            catch
            {
                return null;
            }
        }

        public bool Crear(EspecificacionBienAltaDTO wishDTO)
        {
            using (ModelContainer db = new ModelContainer())
            {
                IQueryable<Usuario> query =
                    from u in db.Usuarios
                    where u.NombreUsuario == wishDTO.Usuario
                    select u;
                EspecificacionBien wish = new EspecificacionBien()
                {
                    Titulo = wishDTO.Titulo,
                    Latitud = wishDTO.Latitud,
                    Longitud = wishDTO.Longitud,
                    Rango = wishDTO.Rango,
                    TipoBien = db.TiposBienes.Find(wishDTO.TipoBien),
                    Usuario = query.First(),
                    ValoresCaracteristicas = new List<ValorCaracteristica>()
                };

                foreach (ValorCaracteristicaAltaDTO valorCaracteristicaDTO in wishDTO.ValoresCaracteristicas)
                {
                    wish.ValoresCaracteristicas.Add(new ValorCaracteristica() 
                    {
                        Valor = valorCaracteristicaDTO.Valor,
                        Caracteristica = db.Caracteristicas.Find(valorCaracteristicaDTO.IdCaracteristica)
                    });
                }

                try
                {
                    db.EspecificacionesBienes.Add(wish);
                    db.SaveChanges();
                    return true;
                }catch
                {
                    return false;
                }
            }
        }

        public bool Editar(EspecificacionBienDTO wishDTO)
        {
            try
            {
                using (ModelContainer db = new ModelContainer())
                {
                    EspecificacionBien wish = db.EspecificacionesBienes.Find(wishDTO.Id);
                    bool seModifico = false;
                    if (wish.Titulo != wishDTO.Titulo)
                    {
                        wish.Titulo = wishDTO.Titulo;
                        seModifico = true;
                    }
                    if (wish.Latitud != wishDTO.Latitud)
                    {
                        wish.Latitud = wishDTO.Latitud;
                        seModifico = true;
                    }
                    if (wish.Longitud != wishDTO.Longitud)
                    {
                        wish.Longitud = wishDTO.Longitud;
                        seModifico = true;
                    }
                    if (wish.Rango != wishDTO.Rango)
                    {
                        wish.Rango = wishDTO.Rango;
                        seModifico = true;
                    }
                    bool salvar = false;
                    foreach (ValorCaracteristicaListadoDTO valorDTO in wishDTO.ValoresCaracteristicas)
                    {
                        ValorCaracteristica valor = wish.ValoresCaracteristicas.Where(a => a.Id == valorDTO.Id).First();
                        if (valor.Valor != valorDTO.Valor)
                        {
                            valor.Valor = valorDTO.Valor;
                            db.Entry(valor).State = EntityState.Modified;
                            salvar = true;
                        }
                    }
                    if (seModifico)
                    {
                        db.Entry(wish).State = EntityState.Modified;
                    }
                    if (seModifico || salvar)
                    {
                        db.SaveChanges();
                    }
                }
                return true;
            }catch
            {
                return false;
            }
        }

        public void Eliminar(int id)
        {
            using (ModelContainer db = new ModelContainer())
            {
                EspecificacionBien wish = db.EspecificacionesBienes.Find(id);
                List<ValorCaracteristica> valores = new List<ValorCaracteristica>(wish.ValoresCaracteristicas);
                foreach (ValorCaracteristica vc in valores)
                {
                     db.ValoresCaracteristicas.Remove(vc);
                }
                wish.ValoresCaracteristicas.Clear();
                db.EspecificacionesBienes.Remove(wish);
                db.SaveChanges();
            }
        }

        public List<EspecificacionBienListadoDTO> Wishlist(string usuario, int sitio)
        {
            using (ModelContainer db = new ModelContainer())
            {
                IQueryable<EspecificacionBien> queryWish =
                    from w in db.EspecificacionesBienes
                    where w.Usuario.NombreUsuario == usuario && w.TipoBien.Sitio.Id == sitio
                    select w;
                if (queryWish.Count() > 0)
                {
                    return AutoMapperUtils<EspecificacionBien,EspecificacionBienListadoDTO>.Map(queryWish.ToList());
                }
                else
                {
                    return new List<EspecificacionBienListadoDTO>();
                }
            }
        }

        public void BuscarCoincidencias(int idBien)
        {
            using (ModelContainer db = new ModelContainer())
            {
                IQueryable<Bien> queryBien =
                    from b in db.Bienes
                    where b.Id == idBien
                    select b;
                if (queryBien.Count() > 0)
                {
                    Bien bien = queryBien.First();
                    IQueryable<EspecificacionBien> queryWish =
                        from w in db.EspecificacionesBienes
                        where w.TipoBien.Id == bien.TipoBien.Id && w.Usuario.Id != bien.Usuario.Id
                        select w;
                    if (queryWish.Count() > 0)
                    {
                        var cant = queryWish.Count();
                        for (int i = 0; i < cant; i++)
                        {
                            EspecificacionBien wish = queryWish.ToList()[i];
                            Usuario usuario = wish.Usuario;
                            if (distance(Convert.ToDouble(wish.Latitud), Convert.ToDouble(wish.Longitud), Convert.ToDouble(bien.Latitud), Convert.ToDouble(bien.Longitud)) <= wish.Rango)
                            {
                                if (compatibilidad(wish.ValoresCaracteristicas.ToList(), bien.ValoresCaracteristicas.ToList(), wish.TipoBien.Sitio.Id))
                                {
                                   //Envio de mail
                                    MailMessage mail = new MailMessage();
                                    SmtpClient sc = new SmtpClient();
                                    mail.From = new MailAddress("gr6tsi1@gmail.com", "Ol4Rent");
                                    mail.To.Add(new MailAddress(usuario.Mail, usuario.Nombre + " " + usuario.Apellido));
                                    //m.CC.Add(new MailAddress("CC@yahoo.com", "Display name CC"));
                                    //similarly BCC
                                    mail.Subject = "Concidencia con Wish";
                                    var body = "Estimado Cliente, se a encontrado una coincidencia con su Wish";
                                    body = body + "\n La dirección del " + wish.TipoBien.Nombre + ": ";
                                    body = body + wish.TipoBien.Sitio.URL + "/Bien/Details/" + bien.Id;
                                    mail.Body = body;
                                    sc.Host = "smtp.gmail.com";
                                    sc.Port = 587;
                                    sc.Credentials = new System.Net.NetworkCredential("gr6tsi1@gmail.com", "gr643210");
                                    sc.EnableSsl = true; // runtime encrypt the SMTP communications using SSL
                                    sc.Send(mail);
                                }
                            }
                        }
                    }
                }
            }
        }

        private double distance(double lat1, double lon1, double lat2, double lon2) 
        {
            double theta = lon1 - lon2;
            double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            dist = dist * 1.609344 * 1000;
            return (dist);
        }
        private double deg2rad(double deg) 
        {
            return (deg * Math.PI / 180.0);
        }
        private double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }

        private bool compatibilidad(List<ValorCaracteristica> vWish, List<ValorCaracteristica> vBien, int idSitio)
        {
            var total = vWish.Count();
            var cont = 0;
            foreach (ValorCaracteristica vcW in vWish)
            {
                ValorCaracteristica vcB = vBien.Where(item => item.Caracteristica.Id == vcW.Caracteristica.Id).First();
                if (vcW.Valor == vcB.Valor)
                {
                    cont++;
                }
            }
            using (ModelContainer db = new ModelContainer())
            {
                IQueryable<Sitio> querySitio =
                    from s in db.Sitios
                    where s.Id == idSitio
                    select s;
                if (querySitio.Count() > 0)
                {
                    Sitio sitio = querySitio.First();
                    var porsentaje = cont * 100 / total;
                    if (porsentaje >= sitio.AproximacionWish)
                    {
                        return true;
                    }
                }
            }
            return true;
        }
    }
}
