using Ol4RentAPI.DTO;
using Ol4RentAPI.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool Editar(EspecificacionBienDTO w)
        {
            try
            {
                using (ModelContainer db = new ModelContainer())
                {
                    EspecificacionBien wish = db.EspecificacionesBienes.Find(w.Id);
                    bool seModifico = false;
                    if (wish.Titulo != w.Titulo)
                    {
                        wish.Titulo = w.Titulo;
                        seModifico = true;
                    }
                    if (wish.Latitud != w.Latitud)
                    {
                        wish.Latitud = w.Latitud;
                        seModifico = true;
                    }
                    if (wish.Longitud != w.Longitud)
                    {
                        wish.Longitud = w.Longitud;
                        seModifico = true;
                    }
                    if (wish.Rango != w.Rango)
                    {
                        wish.Rango = w.Rango;
                        seModifico = true;
                    }
                    bool salvar = false;
                    if (wish.Usuario.NombreUsuario != w.Usuario)
                    {
                        wish.Usuario.NombreUsuario = w.Usuario;
                        db.Entry(wish.Usuario).State = EntityState.Modified;
                        salvar = true;
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
                    List<EspecificacionBienListadoDTO> list = new List<EspecificacionBienListadoDTO>();
                    for (int i = 0; i < queryWish.Count(); i++)
                    {
                        list.Add(new EspecificacionBienListadoDTO()
                        {
                            Id = queryWish.First().Id, 
                            Titulo = queryWish.First().Titulo,
                        });
                    }
                    return list;
                }
                else
                {
                    return new List<EspecificacionBienListadoDTO>();
                }
            }
        }
    }
}
