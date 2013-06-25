using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ol4RentAPI.DTO;
using Ol4RentAPI.Model;
using System.Data;
using System.IO;
using System.Diagnostics;

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

                int nro = 0;
                foreach (AdjuntoDTO adjunto in dto.Adjuntos)
                {
                    // Nombre de Archivo: idBien-idContenido-nroAdjunto-Nombre
                    adjunto.Nombre = dto.IdBien + "-" + cont.Id + "-" + nro + "-" + adjunto.Nombre;

                    string extension = System.IO.Path.GetExtension(adjunto.Nombre).ToLower().Replace(".", "");

                    //// Inicializar con tipo de adjunto igual a cero
                    TipoAdjunto tipo = TipoAdjunto.OTRO;

                    //// Extensiones valida de imagen: "jpg","jpeg", "png","gif", "bmp"
                    if (extension == "jpg" || extension == "jpeg" || extension == "png" || extension == "gif" || extension == "bmp")
                    {
                        tipo = TipoAdjunto.IMAGEN;
                    }

                    //// Opciones para formato de video "mpg" , "mpeg", "avi","flv","mp4"
                    if (extension == "mpg" || extension == "mpeg" || extension == "avi" || extension == "flv" || extension == "mp4")
                    {
                        tipo = TipoAdjunto.VIDEO;
                    }

                    if (tipo != TipoAdjunto.OTRO)
                    {

                        if (tipo == TipoAdjunto.VIDEO)
                        {
                            // Video
                            string PathVideo = AppDomain.CurrentDomain.BaseDirectory + "Upload\\Video\\";

                            // Guardo el archivo
                            File.WriteAllBytes(PathVideo + adjunto.Nombre, adjunto.Contenido);

                            // 1. CONVIERTO A SWF

                            // Nombre de archivo sin extension
                            String FileName = Path.GetFileNameWithoutExtension(PathVideo + adjunto.Nombre);

                            // Archivo Original
                            String inputfile = PathVideo + adjunto.Nombre;

                            // Archivo convertido a swf
                            String outputfile = PathVideo + "swf\\" + FileName + ".swf";

                            // Parametros para FFMEPG - conversion a swf
                            String filargs = "-i " + "\"" + inputfile + "\"" + " -ar 22050 " + "\"" + outputfile + "\"";

                            //// Problema en la ruta, verificar mejor entre el equipo del desarrollador y el de testeo
                            String PathFFMPEG = AppDomain.CurrentDomain.BaseDirectory.TrimEnd("OL4RENT\\".ToCharArray()) + "\\ext\\ffmpeg\\ffmpeg.exe";
                            
                            Process proc;
                            proc = new Process();
                            proc.StartInfo.FileName = PathFFMPEG;
                            proc.StartInfo.Arguments = filargs;
                            proc.StartInfo.UseShellExecute = false;
                            proc.StartInfo.CreateNoWindow = false;
                            proc.StartInfo.RedirectStandardOutput = false;
                            try
                            {
                                proc.Start();
                            }
                            catch (Exception ex)
                            {
                            }
                            proc.WaitForExit();
                            proc.Close();


                            // 2. GENERO EL THUMBNAIL

                            String PathThumb = AppDomain.CurrentDomain.BaseDirectory + "Upload\\Video\\thumb\\";

                            String NombreThumb = PathThumb + FileName + "%d" + ".jpg";

                            // Parametros para FFMPEG - generar thumbnail
                            String thumbargs = "-i " + "\"" + inputfile + "\"" + " -vframes 1 -ss 00:00:07 -s 150x150 " + "\"" + NombreThumb + "\"";

                            Process thumbproc = new Process();
                            thumbproc = new Process();
                            thumbproc.StartInfo.FileName = PathFFMPEG;
                            thumbproc.StartInfo.Arguments = thumbargs;
                            thumbproc.StartInfo.UseShellExecute = false;
                            thumbproc.StartInfo.CreateNoWindow = false;
                            thumbproc.StartInfo.RedirectStandardOutput = false;
                            try
                            {
                                thumbproc.Start();
                            }
                            catch (Exception ex)
                            {
                            }
                            thumbproc.WaitForExit();
                            thumbproc.Close();

                            // Borro el archivo original
                            File.Delete(inputfile);

                            // Obtengo el thumbnail, lo voy a guardar en la base (en el adjunto)
                            byte[] bytes = new byte[0];
                            FileStream fs = null;
                            try
                            {
                                fs = File.OpenRead(PathThumb + FileName + "1" + ".jpg");
                                bytes = new byte[fs.Length];
                                fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
                                fs.Close();
                            }
                            finally
                            {
                                if (fs != null)
                                {
                                    fs.Close();
                                }
                            }

                            adjunto.Contenido = bytes;
                            adjunto.Nombre = FileName + ".swf";
                        }
                        else
                        {
                            // Imagen
                            string SavePath = AppDomain.CurrentDomain.BaseDirectory + "Upload\\Image\\";
                            string Filenamewithpath = SavePath + adjunto.Nombre;

                            File.WriteAllBytes(Filenamewithpath, adjunto.Contenido);
                        }

                        // Guardo en la base
                        Adjunto adj = new Adjunto() { Data = adjunto.Contenido, NombreArchivo = adjunto.Nombre, Formato = extension, Tipo = tipo };
                        cont.Adjuntos.Add(adj);
                        db.Adjuntos.Add(adj);
                        db.SaveChanges();

                        nro++;

                    } //// fin tipo distinto de otro=0

                }
            }
        }
    }
}
