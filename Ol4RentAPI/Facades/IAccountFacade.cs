﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ol4RentAPI.Model;
using Ol4RentAPI.DTO;

namespace Ol4RentAPI.Facades
{
    public interface IAccountFacade
    {
        List<Usuario> Todos { get; }
        UsuarioDTO Obtener(int id);
        Usuario ObtenerPorNombre(string NombreUsuario);
        bool Crear(string NombreUsuario);
        bool Editar(UsuarioDTO usuario);
        void Eliminar(int id);

        List<UsuarioSitioDTO> ObtenerPorSitio(int idSitio);

        void DeshabilitarUsuarioEnSitio(int idUsuario, int idSitio);
        void DeshabilitarUsuarioEnSitio(String nombreUsuario, int idSitio);

        void HabilitarUsuarioEnSitio(int idUsuario, int idSitio);

        void ResetearUsuarioEnSitio(int idUsuario, int idSitio);

        List<UsuarioDTO> Buscar(string query);

        List<UsuarioDTO> ObtenerUsuariosConectados(int idUsuarioActual);

        Boolean UsuarioHabilitadoEnSitio(int idUsuario, int idSitio);
        Boolean UsuarioHabilitadoEnSitio(String nombreUsuario, int idSitio);

        int IncrementarCantContBloqUsuarioEnSitio(int idUsuario, int idSitio);
        int IncrementarCantContBloqUsuarioEnSitio(String nombreUsuario, int idSitio);
    }
}
