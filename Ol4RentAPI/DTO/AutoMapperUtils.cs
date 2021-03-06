﻿using AutoMapper;
using OL4RENT.DatosExternosDACAPI;
using Ol4RentAPI.Facades;
using Ol4RentAPI.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
            Mapper.CreateMap<CaracteristicaEdicionDTO, Caracteristica>();
            Mapper.CreateMap<Sitio, SitioListadoDTO>()
                .ForMember(dest => dest.NombreTipoBien, dat => dat.MapFrom(src => src.TipoBien.Nombre));
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
            Mapper.CreateMap<OrigenDatos, OrigenDatosListaDTO>()
                .ForMember(dest => dest.SePuedeEliminar, dat => dat.MapFrom(src => ServiceFacadeFactory.Instance.OrigenDatosFacade.ChequearEliminacion(src.Id)));
            Mapper.CreateMap<OrigenDatos, OrigenDatosEdicionDTO>();
            Mapper.CreateMap<OrigenDatosAltaDTO, OrigenDatos>()
                .ForMember(dest => dest.Manejador, dat => dat.MapFrom(src => Read(src.Manejador.InputStream)))
                .ForMember(dest => dest.Dependencias, dat => dat.MapFrom(src => src.Dependencias.Select(d => new Dependencia() { Id = -1, Dll = Read(d.InputStream), Nombre = d.FileName } ).ToList()))
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
                .ForMember(dest => dest.CantAdjuntos, dat => dat.MapFrom(src => src.Adjuntos.Count))
                .ForMember(dest => dest.Bien, dat => dat.MapFrom(src => ServiceFacadeFactory.Instance.BienFacade.ObtenerBienParaContenido(src.Id)));
            Mapper.CreateMap<Mensaje, MensajeDTO>();
            Mapper.CreateMap<EspecificacionBien, EspecificacionBienDTO>()
                .ForMember(dest => dest.TipoBien, dat => dat.MapFrom(src => src.TipoBien.Id))
                .ForMember(dest => dest.Usuario, dat => dat.MapFrom(src => src.Usuario.NombreUsuario));
            Mapper.CreateMap<EspecificacionBien, EspecificacionBienListadoDTO>();
            Mapper.CreateMap<ValorCaracteristica, ValorCaracteristicaAltaDTO>()
                .ForMember(dest => dest.IdCaracteristica, dat => dat.MapFrom(src => src.Caracteristica.Id));
            Mapper.CreateMap<ValorCaracteristicaAltaDTO, ValorCaracteristica>()
                .ForMember(dest => dest.Caracteristica, dat => dat.MapFrom(src => ServiceFacadeFactory.Instance.CaracteristicaFacade.Obtener(src.IdCaracteristica)))
                .ForMember(dest => dest.Id, dat => dat.UseValue(-1)); ;
            Mapper.CreateMap<ValorCaracteristica, ValorCaracteristicaListadoDTO>()
                .ForMember(dest => dest.IdCaracteristica, dat => dat.MapFrom(src => src.Caracteristica.Id))
                .ForMember(dest => dest.Caracteristica, dat => dat.MapFrom(src => ServiceFacadeFactory.Instance.CaracteristicaFacade.Obtener(src.Caracteristica.Id)));
            Mapper.CreateMap<Novedad, NovedadExternaDTO>()
                .ForMember(dest => dest.Fecha, dat => dat.MapFrom(src => src.FechaHora))
                .ForMember(dest => dest.Proveedor, dat => dat.MapFrom(src => src.Configuracion.ValoresAtributo.Where(va => va.Atributo.Nombre.ToLower() == "nombre").DefaultIfEmpty(new ValorAtributo() { Valor = src.Configuracion.OrigenDatos.Nombre }).FirstOrDefault().Valor));
            Mapper.CreateMap<Novedad, NovedadListadoDTO>()
                .ForMember(dest => dest.Fecha, dat => dat.MapFrom(src => src.FechaHora))
                .ForMember(dest => dest.Proveedor, dat => dat.MapFrom(src => src.Configuracion.ValoresAtributo.Where(va => va.Atributo.Nombre.ToLower() == "nombre").DefaultIfEmpty(new ValorAtributo() { Valor = src.Configuracion.OrigenDatos.Nombre }).FirstOrDefault().Valor));
            Mapper.CreateMap<NovedadAltaDTO, Novedad>()
                .ForMember(dest => dest.Id, dat => dat.UseValue(-1))
                .ForMember(dest => dest.Configuracion, dat => dat.Ignore());
            Mapper.CreateMap<Novedad, NovedadEdicionDTO>()
                .ForMember(dest => dest.IdConfiguracionOrigenDeDatos, dat => dat.MapFrom(src => src.Configuracion.Id));
            Mapper.CreateMap<NovedadEdicionDTO, Novedad>()
                .ForMember(dest => dest.Configuracion, dat => dat.Ignore());
            Mapper.CreateMap<Dependencia, DependenciaDTO>();
            Mapper.CreateMap<DependenciaDTO, Dependencia>();
            Mapper.CreateMap<Bien, BienListadoDTO>()
                .ForMember(dest => dest.MostrarMeGusta, dat => dat.MapFrom(src => ServiceFacadeFactory.Instance.BienFacade.PuedeMostrarMeGusta(src.Id)))
                .ForMember(dest => dest.CantidadLikes, dat => dat.MapFrom(src => ServiceFacadeFactory.Instance.BienFacade.CantidadLikes(src.Id)))
                .ForMember(dest => dest.Propietario, dat => dat.MapFrom(src => src.Usuario.NombreUsuario));
            Mapper.CreateMap<Bien, BienAltaDTO>()
                .ForMember(dest => dest.TipoBien, dat => dat.MapFrom(src => src.TipoBien.Id))
                .ForMember(dest => dest.Usuario, dat => dat.MapFrom(src => src.Usuario.NombreUsuario));
            Mapper.CreateMap<Bien, BienEdicionDTO>()
                .ForMember(dest => dest.TipoBien, dat => dat.MapFrom(src => src.TipoBien.Id))
                .ForMember(dest => dest.Usuario, dat => dat.MapFrom(src => src.Usuario.NombreUsuario))
                .ForMember(dest => dest.CantidadLikes, dat => dat.MapFrom(src => ServiceFacadeFactory.Instance.BienFacade.CantidadLikes(src.Id)));
            Mapper.CreateMap<Bien, BienCercanoDTO>()
                 .ForMember(dest => dest.TipoDeBien, dat => dat.MapFrom(src => src.TipoBien.Nombre));
            Mapper.CreateMap<Bien, BienArrendarDTO>();
            Mapper.CreateMap<Adjunto, AdjuntoDTO>()
                .ForMember(dest => dest.Contenido, dat => dat.MapFrom(src => src.Data))
                .ForMember(dest => dest.Nombre, dat => dat.MapFrom(src => src.NombreArchivo));
            Mapper.AssertConfigurationIsValid();
        }

        public static byte[] Read(Stream stream)
        {
            byte[] res = new byte[Convert.ToInt32(stream.Length)];
            stream.Read(res, 0, Convert.ToInt32(stream.Length));
            return res;
        }
    }

    public class AutoMapperUtils<TOrigen, TDestino>
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