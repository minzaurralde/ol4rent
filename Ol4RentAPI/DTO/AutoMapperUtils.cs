using AutoMapper;
using OL4RENT.DatosExternosDACAPI;
using Ol4RentAPI.Facades;
using Ol4RentAPI.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ol4RentAPI.DTO
{
    public class AutoMapperInitializer
    {
        public static void Inicializar()
        {
            Mapper.CreateMap<ValorAtributo, ValorAtributoEdicionDTO>()
                .ForMember(dest => dest.IdAtributo, dat => dat.MapFrom(src => src.Atributo.Id))
                .ForMember(dest => dest.NombreAtributo, dat => dat.MapFrom(src => src.Atributo.Nombre));
            Mapper.CreateMap<ValorAtributoAltaDTO, ValorAtributo>()
                .ForMember(dest => dest.Id, dat => dat.Ignore())
                .ForMember(dest => dest.Atributo, dat => dat.MapFrom(src => ServiceFacadeFactory.Instance.OrigenDatosFacade.ObtenerAtributo(src.IdAtributo)));
            Mapper.CreateMap<Atributo, AtributoAltaDTO>();
            Mapper.CreateMap<Atributo, AtributoEdicionDTO>();
            Mapper.CreateMap<AtributoAltaDTO, Atributo>()
                .ForMember(dest => dest.Id, dat => dat.UseValue(-1));
            Mapper.CreateMap<AtributoEdicionDTO, Atributo>();
            Mapper.CreateMap<Caracteristica, CaracteristicaEdicionDTO>(); 
            Mapper.CreateMap<Sitio, SitioListadoDTO>();
            Mapper.CreateMap<Sitio, SitioEdicionDTO>()
                .ForMember(dest => dest.NombreTipoBien, dat => dat.MapFrom(src => src.TipoBien.Nombre))
                .ForMember(dest => dest.Caracteristicas, dat => dat.MapFrom(src => ServiceFacadeFactory.Instance.SitioFacade.ObtenerCaracteristicasParaEdicion(src.Id)))
                .ForMember(dest => dest.NombreUsuarioPropietario, dat => dat.MapFrom(src => ServiceFacadeFactory.Instance.SitioFacade.ObtenerNombreUsuarioPropietario(src.Id)));
            Mapper.CreateMap<HabilitacionUsuario, UsuarioSitioDTO>()
                .ForMember(dest => dest.Id, dat => dat.MapFrom(src => src.Usuario.Id))
                .ForMember(dest => dest.NombreUsuario, dat => dat.MapFrom(src => src.Usuario.NombreUsuario))
                .ForMember(dest => dest.Correo, dat => dat.MapFrom(src => src.Usuario.Mail))
                .ForMember(dest => dest.NombreCompleto, dat => dat.MapFrom(src => src.Usuario.Nombre + " " + src.Usuario.Apellido))
                .ForMember(dest => dest.CantidadContenidosBloqueados, dat => dat.MapFrom(src => src.CantContBloq));
            Mapper.CreateMap<OrigenDatos, OrigenDatosListaDTO>();
            Mapper.CreateMap<OrigenDatos, OrigenDatosEdicionDTO>();
            Mapper.CreateMap<OrigenDatosAltaDTO, OrigenDatos>()
                .ForMember(dest => dest.Id, dat => dat.Ignore());
            Mapper.CreateMap<ConfiguracionOrigenDatos, ConfiguracionOrigenDatosEdicionDTO>()
                .ForMember(dest => dest.IdOrigenDatos, dat => dat.MapFrom(src => src.OrigenDatos.Id))
                .ForMember(dest => dest.NombreOrigenDatos, dat => dat.MapFrom(src => src.OrigenDatos.Nombre))
                .ForMember(dest => dest.NombreSitio, dat => dat.MapFrom(src => src.Sitio.Nombre))
                .ForMember(dest => dest.IdSitio, dat => dat.MapFrom(src => src.Sitio.Id));
            Mapper.CreateMap<ConfiguracionOrigenDatosAltaDTO, ConfiguracionOrigenDatos>()
                .ForMember(dest => dest.Id, dat => dat.Ignore())
                .ForMember(dest => dest.OrigenDatos, dat => dat.MapFrom(src => ServiceFacadeFactory.Instance.OrigenDatosFacade.Obtener(src.IdOrigenDatos)))
                .ForMember(dest => dest.Sitio, dat => dat.MapFrom(src => ServiceFacadeFactory.Instance.SitioFacade.Obtener(src.IdSitio)));
            Mapper.CreateMap<Usuario, UsuarioDTO>();
            Mapper.CreateMap<Contenido, ContenidoDTO>()
                .ForMember(dest => dest.NombreUsuario, dat => dat.MapFrom(src => src.Usuario.NombreUsuario))
                .ForMember(dest => dest.TieneAdjuntos, dat => dat.MapFrom(src => src.Adjuntos.Count > 0))
                .ForMember(dest => dest.Bien, dat => dat.MapFrom(src => ServiceFacadeFactory.Instance.BienFacade.ObtenerBienParaContenido(src.Id)));
            Mapper.CreateMap<Mensaje, MensajeDTO>();
            Mapper.CreateMap<Novedad, NovedadExternaDTO>()
                .ForMember(dest => dest.Fecha, dat => dat.MapFrom(src => src.FechaHora));
            Mapper.AssertConfigurationIsValid();
        }
    }

    public class AutoMapperUtils <TOrigen,TDestino>
    {
        public static TDestino Map(TOrigen objeto)
        {
            return Mapper.Map<TOrigen, TDestino>(objeto);
        }

        public static List<TDestino> Map(List<TOrigen> lista)
        {
            return Mapper.Map<List<TOrigen>, List<TDestino>>(lista);
        }
    }
}