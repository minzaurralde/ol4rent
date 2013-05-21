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

        public EspecificacionBien Obtener(int id)
        {
            using (ModelContainer db = new ModelContainer())
            {
                return db.EspecificacionesBienes.Find(id);
            }
        }

        public bool Crear(EspecificacionBienDTO w)
        {
            using (ModelContainer db = new ModelContainer())
            {

                EspecificacionBien wish = new EspecificacionBien()
                {
                    Titulo = w.Titulo,
                    Direccion = w.Direccion,
                    Latitud = w.Latitud,
                    Longitud = w.Longitud,
                    Pais = w.Pais,
                    Ciudad = w.Ciudad,
                    Rango = w.Rango,
                    TipoBien = db.TiposBienes.Find(w.TipoBien),
                    Usuario = db.Usuarios.Find(w.Usuario),
                    ValoresCaracteristicas = new List<ValorCaracteristica>()
                };

                foreach (ValorCaracteristicaAltaDTO valorCaracteristicaDTO in w.ValoresCaracteristicas)
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
                    if (wish.Ciudad != w.Ciudad)
                    {
                        wish.Ciudad = w.Ciudad;
                        seModifico = true;
                    }
                    if (wish.Direccion != w.Direccion)
                    {
                        wish.Direccion = w.Direccion;
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
                    if (wish.Pais != w.Pais)
                    {
                        wish.Pais = w.Pais;
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

        public List<EspecificacionBienListadoDTO> Wishlist(string usuario, string tipoBien)
        {
            using (ModelContainer db = new ModelContainer())
            {
                IQueryable<EspecificacionBien> queryWish =
                    from w in db.EspecificacionesBienes
                    where w.Usuario.NombreUsuario == usuario && w.TipoBien.Nombre == tipoBien
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
                            Ciudad = queryWish.First().Ciudad,
                            Pais = queryWish.First().Pais
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
