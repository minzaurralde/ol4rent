using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ol4RentAPI.DTO;
using Ol4RentAPI.Model;
using System.Data;

namespace Ol4RentAPI.Facades
{
    class ContenidoFacadeImpl : IContenidoFacade
    {
        public ContenidoDTO Obtener(int id)
        {
            using (ModelContainer db = new ModelContainer())
            {
                return AutoMapperUtils<Contenido, ContenidoDTO>.Map(db.Contenidos.Find(id));
            }
        }


        public void MarcarInadecuado(int id)
        {
            using (ModelContainer db = new ModelContainer())
            {
                Contenido cont = db.Contenidos.Find(id);
                if (cont != null)
                {
                    cont.CantMarcas++;
                    db.Entry(cont).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }


        public void Eliminar(int id)
        {
            using (ModelContainer db = new ModelContainer())
            {
                Contenido cont = db.Contenidos.Find(id);
                db.Contenidos.Remove(cont);
                db.SaveChanges();
            }
        }

        public void Agregar(ComentarioAltaDTO dto)
        {
            using (ModelContainer db = new ModelContainer())
            {
                Bien bien = db.Bienes.Find(dto.IdBien);
                Usuario usuario = (from usu in db.Usuarios where usu.NombreUsuario == dto.NombreUsuario select usu).First();
                Contenido cont = new Contenido() { CantMarcas = 0, Mensaje = dto.Texto, Usuario = usuario, Adjuntos = new List<Adjunto>() };
                db.Contenidos.Add(cont);
                if (bien.Contenidos == null)
                {
                    bien.Contenidos = new List<Contenido>();
                }
                bien.Contenidos.Add(cont);
                db.SaveChanges();
                foreach (AdjuntoDTO adjunto in dto.Adjuntos)
                {
                    string extension = System.IO.Path.GetExtension(adjunto.Nombre).ToLower();
                    TipoAdjunto tipo;
                    if (extension == "jpg" || extension == "jpeg" || extension == "png" || extension == "gif" || extension == "bmp")
                    {
                        tipo = TipoAdjunto.IMAGEN;
                    }
                    else
                    {
                        tipo = TipoAdjunto.VIDEO;
                    }
                    Adjunto adj = new Adjunto() { Data = adjunto.Contenido, NombreArchivo = adjunto.Nombre, Formato = extension, Tipo = tipo };
                    cont.Adjuntos.Add(adj);
                    db.Adjuntos.Add(adj);
                    db.SaveChanges();
                }
            }
        }
    }
}
