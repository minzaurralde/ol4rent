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
        public static IProveedorNoticias ObtenerProveedor(int idOrigenDatos, int idSitio)
        {
            using (ModelContainer db = new ModelContainer())
            {
                ConfiguracionOrigenDatos cod = (from cfg in db.ConfiguracionesOrigenesDatos where cfg.Sitio.Id == idSitio && cfg.OrigenDatos.Id == idOrigenDatos select cfg).First();
                Assembly assembly = Assembly.Load(cod.OrigenDatos.Manejador);
                foreach (TypeInfo tipo in assembly.DefinedTypes)
                {
                    if (tipo.ImplementedInterfaces.Contains(typeof(IProveedorNoticias)))
                    {
                        IProveedorNoticias instancia = (IProveedorNoticias) Activator.CreateInstance(tipo.ReflectedType);
                        Hashtable properties = new Hashtable();
                        foreach (ValorAtributo valor in cod.ValoresAtributo) {
                            properties.Add(valor.Atributo.Nombre, valor.Valor);
                        }
                        instancia.Configurar(properties);
                        return instancia;
                    }
                }
            }
            return null;
        }
    }
}
