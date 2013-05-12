using Ol4RentAPI.DTO;
using Ol4RentAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.Facades
{
    class OrigenDatosFacade: IOrigenDatosFacade
    {
        public List<OrigenDatosListaDTO> ObtenerPorSitio(int idSitio)
        {
            using (ModelContainer db = new ModelContainer())
            {
                IQueryable<OrigenDatos> origenesDatos =
                    from cod in db.ConfiguracionesOrigenesDatos
                    where cod.Sitio.Id == idSitio
                    select cod.OrigenDatos;
                return AutoMapperUtils<OrigenDatos, OrigenDatosListaDTO>.Map(origenesDatos.ToList());
            }
        }

        public List<OrigenDatosListaDTO> ObtenerTodos()
        {
            using (ModelContainer db = new ModelContainer())
            {
                return AutoMapperUtils<OrigenDatos, OrigenDatosListaDTO>.Map(db.OrigenesDatos.ToList());
            }
        }

        public bool Crear(OrigenDatosAltaDTO dto)
        {
            try
            {
                using (ModelContainer db = new ModelContainer())
                {
                    OrigenDatos origenDatos = AutoMapperUtils<OrigenDatosAltaDTO, OrigenDatos>.Map(dto);
                    db.OrigenesDatos.Add(origenDatos);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public OrigenDatosEdicionDTO ObtenerParaEdicion(int id)
        {
            using (ModelContainer db = new ModelContainer())
            {
                return AutoMapperUtils<OrigenDatos, OrigenDatosEdicionDTO>.Map(db.OrigenesDatos.Find(id));
            }
        }

        public bool Editar(OrigenDatosEdicionDTO dto)
        {
            try
            {
                using (ModelContainer db = new ModelContainer())
                {
                    // Se obtiene el origen de datos a partir de su id
                    OrigenDatos origenDatos = db.OrigenesDatos.Find(dto.Id);
                    // Se verifica que se hayan modificado las propiedades del origen de datos
                    bool seModifica = false;
                    if (origenDatos.Nombre != dto.Nombre)
                    {
                        origenDatos.Nombre = dto.Nombre;
                        seModifica = true;
                    }
                    if (origenDatos.Manejador != dto.Manejador)
                    {
                        origenDatos.Manejador = dto.Manejador;
                        seModifica = true;
                    }
                    // Si se modificó alguna propiedad del origen de datos, se guarda en la base
                    if (seModifica)
                    {
                        db.Entry<OrigenDatos>(origenDatos).State = System.Data.EntityState.Modified;
                        db.SaveChanges();
                    }
                    // Se obtiene de la coleccion de atributos pasada por parametro, la lista de los Ids
                    List<int> idsAtributosNuevos = dto.Atributos.Select(a => a.Id).ToList();
                    // Se obtiene una lista de los atributos que deben ser eliminados
                    IQueryable<Atributo> atributosBorrables =
                        from at in db.Atributos
                        where !idsAtributosNuevos.Contains(at.Id)
                        select at;
                    // Se eliminan los atributos
                    bool seEliminaAlguno = false;
                    foreach (Atributo atributoBorrable in atributosBorrables)
                    {
                        origenDatos.Atributos.Remove(atributoBorrable);
                        db.Atributos.Remove(atributoBorrable);
                        seEliminaAlguno = true;
                    }
                    // Se guardan los cambios en caso que corresponda
                    if (seEliminaAlguno)
                    {
                        db.SaveChanges();
                    }
                    // Se recorren todos los atributos viejos que no se eliminaron en busca de modificaciones
                    bool seModificoAlguno = false;
                    foreach (Atributo atributoViejo in origenDatos.Atributos)
                    {
                        AtributoEdicionDTO atributoDto = dto.Atributos.Where(a => a.Id == atributoViejo.Id).First();
                        if (!atributoViejo.Nombre.Equals(atributoDto.Nombre))
                        {
                            atributoViejo.Nombre = atributoDto.Nombre;
                            db.Entry<Atributo>(atributoViejo).State = System.Data.EntityState.Modified;
                            seModificoAlguno = true;
                        }
                    }
                    // Se guardan los cambios en caso que corresponda
                    if (seModificoAlguno)
                    {
                        db.SaveChanges();
                    }
                    // Se obtiene una lista de los atributos nuevos y se agregan
                    bool seAgregoAlguno = false;
                    List<AtributoEdicionDTO> atributosNuevos = dto.Atributos.Where(a => a.Id < 0).ToList();
                    foreach (AtributoEdicionDTO atributoNuevo in atributosNuevos)
                    {
                        Atributo atributo = new Atributo() { Nombre = atributoNuevo.Nombre };
                        db.Atributos.Add(atributo);
                        origenDatos.Atributos.Add(atributo);
                        seAgregoAlguno = true;
                    }
                    // Se guardan los cambios en la base en caso que corresponda
                    if (seAgregoAlguno)
                    {
                        db.SaveChanges();
                    }
                    return true;
                }
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
                OrigenDatos od = db.OrigenesDatos.Find(id);
                db.OrigenesDatos.Remove(od);
                db.SaveChanges();
            }
        }

        public bool Configurar(ConfiguracionOrigenDatosAltaDTO dto)
        {
            try
            {
                using (ModelContainer db = new ModelContainer())
                {
                    ConfiguracionOrigenDatos configuracion = AutoMapperUtils<ConfiguracionOrigenDatosAltaDTO, ConfiguracionOrigenDatos>.Map(dto);
                    db.ConfiguracionesOrigenesDatos.Add(configuracion);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public ConfiguracionOrigenDatosEdicionDTO ObtenerConfiguracionParaEdicion(int idSitio, int idOrigenDatos)
        {
            using (ModelContainer db = new ModelContainer())
            {
                IQueryable<ConfiguracionOrigenDatos> configuraciones =
                    from cfg in db.ConfiguracionesOrigenesDatos
                    where cfg.Sitio.Id == idSitio
                        && cfg.OrigenDatos.Id == idOrigenDatos
                    select cfg;
                return AutoMapperUtils<ConfiguracionOrigenDatos, ConfiguracionOrigenDatosEdicionDTO>.Map(configuraciones.First());
            }
        }

        public bool EditarConfiguracion(ConfiguracionOrigenDatosEdicionDTO dto)
        {
            try
            {
                using (ModelContainer db = new ModelContainer())
                {
                    // Se obtiene la configuració a partir del id
                    ConfiguracionOrigenDatos configuracion = db.ConfiguracionesOrigenesDatos.Find(dto.Id);
                    // Se obtiene la lista de ids de los valores de atributo que se pasaron por parametro
                    List<int> idsValoresNuevos = dto.ValoresAtributo.Select(v => v.Id).ToList();
                    // Se obtiene la lista de valores de atributo que se deben borrar de la base
                    List<ValorAtributo> valoresBorrables = 
                        (from va in db.ValoresAtributos
                        where !idsValoresNuevos.Contains(va.Id)
                        select va).ToList();
                    // Se recorre la lista obtenida y se van borrando de la base y de la colección de valores de la configuracion
                    bool seBorraAlguno = false;
                    foreach (ValorAtributo valorBorrable in valoresBorrables)
                    {
                        configuracion.ValoresAtributo.Remove(valorBorrable);
                        db.ValoresAtributos.Remove(valorBorrable);
                        seBorraAlguno = true;
                    }
                    // Se guardan los cambios en la base en caso que corresponda
                    if (seBorraAlguno)
                    {
                        db.SaveChanges();
                    }
                    // Se recorren los valores de los atributos que no se borraron en busca de modificaciones
                    bool seModificoAlguno = false;
                    foreach (ValorAtributo valorViejo in configuracion.ValoresAtributo)
                    {
                        ValorAtributoEdicionDTO atributoDto = dto.ValoresAtributo.Where(a => a.Id == valorViejo.Id).First();
                        if (!valorViejo.Valor.Equals(atributoDto.Valor))
                        {
                            valorViejo.Valor = atributoDto.Valor;
                            db.Entry<ValorAtributo>(valorViejo).State = System.Data.EntityState.Modified;
                            seModificoAlguno = true;
                        }
                    }
                    // Se guardan los cambios en la base en caso que corresponda
                    if (seModificoAlguno)
                    {
                        db.SaveChanges();
                    }
                    // Se obtiene una lista de los valores nuevos y se agregan
                    bool seAgregoAlguno = false;
                    List<ValorAtributoEdicionDTO> valoresNuevos = dto.ValoresAtributo.Where(a => a.Id < 0).ToList();
                    foreach (ValorAtributoEdicionDTO valorNuevo in valoresNuevos)
                    {
                        Atributo atributo = db.Atributos.Find(valorNuevo.IdAtributo);
                        ValorAtributo valor = new ValorAtributo() { Valor = valorNuevo.Valor, Atributo = atributo };
                        db.ValoresAtributos.Add(valor);
                        configuracion.ValoresAtributo.Add(valor);
                        seAgregoAlguno = true;
                    }
                    // Se guardan los cambios en la base en caso que corresponda
                    if (seAgregoAlguno)
                    {
                        db.SaveChanges();
                    }
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public void EliminarConfiguracion(int idSitio, int idOrigenDatos)
        {
            using (ModelContainer db = new ModelContainer())
            {
                IQueryable<ConfiguracionOrigenDatos> configuraciones =
                    from cfg in db.ConfiguracionesOrigenesDatos
                    where cfg.Sitio.Id == idSitio
                        && cfg.OrigenDatos.Id == idOrigenDatos
                    select cfg;
                db.ConfiguracionesOrigenesDatos.Remove(configuraciones.First());
                db.SaveChanges();
            }
        }


        public List<AtributoEdicionDTO> ObtenerAtributos(int idOrigenDatos)
        {
            using (ModelContainer db = new ModelContainer())
            {
                OrigenDatos od = db.OrigenesDatos.Find(idOrigenDatos);
                return AutoMapperUtils<Atributo, AtributoEdicionDTO>.Map(od.Atributos.ToList());
            }
        }
    }
}
