using OL4RENT.DatosExternosDACAPI;
using Ol4RentAPI.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.Facades.Novedades
{
    public class NovedadesExternasFactory
    {

        /// <summary>
        /// Cantidad de minutos en la que es válida una instancia que habita el caché
        /// </summary>
        public const int MINUTOS_VALIDEZ_INSTANCIAS = 1440;

        /// <summary>
        /// Cantidad de minutos en la que es válida una clase de Proveedor de noticias que habita el caché
        /// </summary>
        public const int MINUTOS_VALIDEZ_TIPOS = 1440;

        private Hashtable CacheTipos = new Hashtable();
        private Hashtable ValidezTipos = new Hashtable();
        private Hashtable CacheDependencias = new Hashtable();
        private Hashtable CacheInstancias = new Hashtable();
        private Hashtable ValidezInstancias = new Hashtable();

        private static NovedadesExternasFactory instance = null;

        private NovedadesExternasFactory() {
            //ResetearCaché();
        }

        /// <summary>
        /// Obtiene la instancia de la Factory
        /// </summary>
        public static NovedadesExternasFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NovedadesExternasFactory();
                }
                return instance;
            }
        }

        public IProveedorNoticias ObtenerProveedor(ConfiguracionOrigenDatos cod)
        {
            // Se chequea la existencia de una instancia válida en el caché de instancias para el Id de la Config
            if (TieneInstanciaValida(cod.Id))
            {
                // Si es válida la instancia que tengo el caché, e devuelve para evitar tanto uso de reflection
                return ObtenerInstanciaDeCache(cod.Id);
            }
            else
            {
                // Si no existe una instancia válida en el cache, entonces se crea
                Type tipo = null;
                // Primero se verifica si existe la clase que corresponde al Origen de Datos en el caché de tipos
                if (TieneTipoValido(cod.OrigenDatos.Id))
                {
                    // Si existe una clase válida en el caché, entonces se utilizará
                    tipo = ObtenerTipoDeCache(cod.OrigenDatos.Id);
                }
                else
                {
                    // Se levantan las dependencias primero
                    LevantarDependencias(cod);
                    // Si no existe en el caché la clase, se crea levantando la Dll "Manejador" por reflection
                    tipo = CrearTipo(cod);
                }
                if (tipo == null)
                {
                    // Si no se encuentra el tipo en el cache ni se pudo levantar de la Dll cargada en el Origen de Datos, 
                    // se retorna una instacia nula
                    return null;
                }
                else
                {
                    // Si se encuentra el tipo ya sea en el caché o lo creé de la dll, se crea la instancia
                    return CrearInstancia(tipo, cod);
                }
            }
        }

        private void LevantarDependencias(ConfiguracionOrigenDatos cod)
        {
            foreach (Dependencia dependencia in cod.OrigenDatos.Dependencias)
            {
                // Se levanta la Assembly (dll)
                Assembly assembly = Assembly.Load(dependencia.Dll);
                // Se agrega al caché: se cache por el mismo tiempo que se cachea la clase
                CacheDependencias.Add(dependencia.Id, assembly);
            }
        }

        private Type CrearTipo(ConfiguracionOrigenDatos cod)
        {
            // Se levanta la Assembly (dll)
            Assembly assembly = Assembly.Load(cod.OrigenDatos.Manejador);
            // Se recorren los tipos definidos en la Assembly buscando una Clase que implemente la interfaz IProveedorNoticias
            foreach (Type tipoCandidato in assembly.GetTypes())
            {
                if (tipoCandidato.GetInterfaces().Where(t => t.FullName == typeof(IProveedorNoticias).FullName).Count() > 0)
                {
                    // Cuando se encuentra una clase que implemente la interfaz, se agrega el tipo al caché y se retorna
                    AgregarTipo(cod.OrigenDatos.Id, tipoCandidato);
                    return tipoCandidato;
                }
            }
            // Si no se encuentra, se retorna una referencia nula
            return null;
        }

        private IProveedorNoticias CrearInstancia(Type tipo, ConfiguracionOrigenDatos cod)
        {
            // Se crea una instancia casteada a IProveedorNoticias
            IProveedorNoticias instancia = (IProveedorNoticias)Activator.CreateInstance(tipo);
            // Se crea la tabla de propiedades de inicialización de la instancia del proveedor
            Hashtable properties = new Hashtable();
            foreach (ValorAtributo valor in cod.ValoresAtributo)
            {
                // Para cada atributo definido en el Origen de datos y configurado con un valor en la configuración
                // específica del origen de datos para el sitio, se crea una propiedad con el nombre (sin espacios)
                // como clave y el valor definido en la configuración del origen de datos para el sitio
                properties.Add(valor.Atributo.Nombre.Trim().Replace(" ", ""), valor.Valor);
            }
            // Una vez armada la tabla de propiedades, se configura la instacia del proveedor
            instancia.Configurar(properties, ObtenerPropiedad(properties, "Filtro") as string, ObtenerPropiedad(properties, "Nombre") as string);
            // Se agrega la instancia al caché de instancias
            AgregarInstancia(cod.Id, instancia);
            // Se retorna la instancia
            return instancia;
        }

        private object ObtenerPropiedad(Hashtable tabla, string nombre)
        {
            if (tabla.ContainsKey(nombre))
            {
                return tabla[nombre];
            }
            else if (tabla.ContainsKey(nombre.ToLower()))
            {
                return tabla[nombre.ToLower()];
            }
            else if (tabla.ContainsKey(nombre.ToUpper()))
            {
                return tabla[nombre.ToUpper()];
            }
            else
            {
                foreach (string key in tabla.Keys)
                {
                    if (key.ToLower() == nombre.ToLower())
                    {
                        return tabla[key];
                    }
                }
            }
            return null;
        }

        private bool TieneInstanciaValida(int id)
        {
            if (CacheInstancias.ContainsKey(id) && ValidezInstancias.ContainsKey(id))
            {
                DateTime fechaAlta = (DateTime) ValidezInstancias[id];
                return (fechaAlta.AddMinutes(Convert.ToDouble(MINUTOS_VALIDEZ_INSTANCIAS)) > DateTime.Now);
            }
            else
            {
                return false;
            }
        }

        private void AgregarInstancia(int id, IProveedorNoticias instancia)
        {
            CacheInstancias.Add(id, instancia);
            ValidezInstancias.Add(id, DateTime.Now);
        }

        private IProveedorNoticias ObtenerInstanciaDeCache(int id)
        {
            return CacheInstancias[id] as IProveedorNoticias;
        }

        private bool TieneTipoValido(int id)
        {
            if (CacheTipos.ContainsKey(id) && ValidezTipos.ContainsKey(id))
            {
                DateTime fechaAlta = (DateTime)ValidezTipos[id];
                return (fechaAlta.AddMinutes(Convert.ToDouble(MINUTOS_VALIDEZ_TIPOS)) > DateTime.Now);
            }
            else
            {
                return false;
            }
        }

        private void AgregarTipo(int id, Type tipo)
        {
            CacheTipos.Add(id, tipo);
            ValidezTipos.Add(id, DateTime.Now);
        }

        private Type ObtenerTipoDeCache(int id)
        {
            return CacheTipos[id] as Type;
        }

        public void ResetearCache()
        {
            ResetearCacheTipos();
            ResetearCacheInstancias();
        }

        public void ResetearCacheTipos()
        {
            CacheTipos = new Hashtable();
            ValidezTipos = new Hashtable();
            CacheDependencias = new Hashtable();
        }

        public void ResetearCacheInstancias()
        {
            CacheInstancias = new Hashtable();
            ValidezInstancias = new Hashtable();
        }

        public void ResetearCacheTipoDeOrigenDatos(int idOrigenDatos)
        {
            if (TieneTipoValido(idOrigenDatos))
            {
                CacheTipos.Remove(idOrigenDatos);
                ValidezTipos.Remove(idOrigenDatos);
            }
            ResetearCache();
        }

        public void ResetearCacheInstanciaDeConfiguracion(int idConfiguracion)
        {
            if (TieneInstanciaValida(idConfiguracion))
            {
                CacheInstancias.Remove(idConfiguracion);
                ValidezInstancias.Remove(idConfiguracion);
            }
            ResetearCache();
        }
    }
}
