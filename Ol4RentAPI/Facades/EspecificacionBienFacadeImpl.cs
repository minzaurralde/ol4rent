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
    }
}
