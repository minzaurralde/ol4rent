
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/04/2013 02:18:10
-- Generated from EDMX file: C:\Users\Usuario\Documents\Visual Studio 2012\Projects\ol4rent\Ol4RentAPI\Model\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [OL4RENT];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TipoBienSitio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TiposBienes] DROP CONSTRAINT [FK_TipoBienSitio];
GO
IF OBJECT_ID(N'[dbo].[FK_TipoBienCaracteristica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Caracteristicas] DROP CONSTRAINT [FK_TipoBienCaracteristica];
GO
IF OBJECT_ID(N'[dbo].[FK_ContenidoBien]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contenidos] DROP CONSTRAINT [FK_ContenidoBien];
GO
IF OBJECT_ID(N'[dbo].[FK_AdjuntoContenido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Adjuntos] DROP CONSTRAINT [FK_AdjuntoContenido];
GO
IF OBJECT_ID(N'[dbo].[FK_SitioSitioOrigenDatos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConfiguracionesOrigenesDatos] DROP CONSTRAINT [FK_SitioSitioOrigenDatos];
GO
IF OBJECT_ID(N'[dbo].[FK_SitioOrigenDatosOrigenDato]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConfiguracionesOrigenesDatos] DROP CONSTRAINT [FK_SitioOrigenDatosOrigenDato];
GO
IF OBJECT_ID(N'[dbo].[FK_NovedadSitioOrigenDatos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Novedades] DROP CONSTRAINT [FK_NovedadSitioOrigenDatos];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioSitio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sitios] DROP CONSTRAINT [FK_UsuarioSitio];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioHabilitacionUsuarioSitio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HabilitacionesUsuarios] DROP CONSTRAINT [FK_UsuarioHabilitacionUsuarioSitio];
GO
IF OBJECT_ID(N'[dbo].[FK_HabilitacionUsuarioSitioSitio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HabilitacionesUsuarios] DROP CONSTRAINT [FK_HabilitacionUsuarioSitioSitio];
GO
IF OBJECT_ID(N'[dbo].[FK_BienTipoBien]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bienes] DROP CONSTRAINT [FK_BienTipoBien];
GO
IF OBJECT_ID(N'[dbo].[FK_BienUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bienes] DROP CONSTRAINT [FK_BienUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioBuzonMensajes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BuzonesMensajes] DROP CONSTRAINT [FK_UsuarioBuzonMensajes];
GO
IF OBJECT_ID(N'[dbo].[FK_MensajeBuzonMensaje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Mensajes] DROP CONSTRAINT [FK_MensajeBuzonMensaje];
GO
IF OBJECT_ID(N'[dbo].[FK_MensajeUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Mensajes] DROP CONSTRAINT [FK_MensajeUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioWishList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EspecificacionesBienes] DROP CONSTRAINT [FK_UsuarioWishList];
GO
IF OBJECT_ID(N'[dbo].[FK_EspecificacionBienTipoBien]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EspecificacionesBienes] DROP CONSTRAINT [FK_EspecificacionBienTipoBien];
GO
IF OBJECT_ID(N'[dbo].[FK_EspecificacionBienValorCaracteristicaEspecificacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ValoresCaracteristicas] DROP CONSTRAINT [FK_EspecificacionBienValorCaracteristicaEspecificacion];
GO
IF OBJECT_ID(N'[dbo].[FK_ValorCaracteristicaEspecificacionCaracteristica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ValoresCaracteristicas] DROP CONSTRAINT [FK_ValorCaracteristicaEspecificacionCaracteristica];
GO
IF OBJECT_ID(N'[dbo].[FK_MeGustaBien]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MeGusta] DROP CONSTRAINT [FK_MeGustaBien];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioMeGusta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MeGusta] DROP CONSTRAINT [FK_UsuarioMeGusta];
GO
IF OBJECT_ID(N'[dbo].[FK_ContenidoUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contenidos] DROP CONSTRAINT [FK_ContenidoUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_AtributoOrigenDatos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Atributos] DROP CONSTRAINT [FK_AtributoOrigenDatos];
GO
IF OBJECT_ID(N'[dbo].[FK_AtributoValorAtributoNovedad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ValoresAtributos] DROP CONSTRAINT [FK_AtributoValorAtributoNovedad];
GO
IF OBJECT_ID(N'[dbo].[FK_ValorAtributoNovedadSitioOrigenDatos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ValoresAtributos] DROP CONSTRAINT [FK_ValorAtributoNovedadSitioOrigenDatos];
GO
IF OBJECT_ID(N'[dbo].[FK_SesionUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sesiones] DROP CONSTRAINT [FK_SesionUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_ValorCaracteristicaBien]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ValoresCaracteristicas] DROP CONSTRAINT [FK_ValorCaracteristicaBien];
GO
IF OBJECT_ID(N'[dbo].[FK_OrigenDatosDependencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dependencias] DROP CONSTRAINT [FK_OrigenDatosDependencia];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Sitios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sitios];
GO
IF OBJECT_ID(N'[dbo].[OrigenesDatos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrigenesDatos];
GO
IF OBJECT_ID(N'[dbo].[Caracteristicas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Caracteristicas];
GO
IF OBJECT_ID(N'[dbo].[Novedades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Novedades];
GO
IF OBJECT_ID(N'[dbo].[Bienes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bienes];
GO
IF OBJECT_ID(N'[dbo].[TiposBienes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TiposBienes];
GO
IF OBJECT_ID(N'[dbo].[Contenidos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contenidos];
GO
IF OBJECT_ID(N'[dbo].[Adjuntos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Adjuntos];
GO
IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];
GO
IF OBJECT_ID(N'[dbo].[ConfiguracionesOrigenesDatos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConfiguracionesOrigenesDatos];
GO
IF OBJECT_ID(N'[dbo].[HabilitacionesUsuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HabilitacionesUsuarios];
GO
IF OBJECT_ID(N'[dbo].[BuzonesMensajes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BuzonesMensajes];
GO
IF OBJECT_ID(N'[dbo].[Mensajes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mensajes];
GO
IF OBJECT_ID(N'[dbo].[EspecificacionesBienes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EspecificacionesBienes];
GO
IF OBJECT_ID(N'[dbo].[ValoresCaracteristicas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ValoresCaracteristicas];
GO
IF OBJECT_ID(N'[dbo].[MeGusta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MeGusta];
GO
IF OBJECT_ID(N'[dbo].[Atributos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Atributos];
GO
IF OBJECT_ID(N'[dbo].[ValoresAtributos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ValoresAtributos];
GO
IF OBJECT_ID(N'[dbo].[Sesiones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sesiones];
GO
IF OBJECT_ID(N'[dbo].[Dependencias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dependencias];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Sitios'
CREATE TABLE [dbo].[Sitios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(64)  NOT NULL,
    [Descripcion] nvarchar(128)  NOT NULL,
    [Logo] varbinary(max)  NOT NULL,
    [CSS] varbinary(max)  NOT NULL,
    [MailAdmin] nvarchar(64)  NOT NULL,
    [URL] nvarchar(256)  NOT NULL,
    [CantBienesPopulares] smallint  NOT NULL,
    [CantMarcasXCont] smallint  NOT NULL,
    [CantContBloqXUsu] smallint  NOT NULL,
    [CantNovedadesHome] int  NOT NULL,
    [AproximacionWish] smallint  NOT NULL,
    [UsuarioSitio_Sitio_Id] int  NOT NULL
);
GO

-- Creating table 'OrigenesDatos'
CREATE TABLE [dbo].[OrigenesDatos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(64)  NOT NULL,
    [Manejador] varbinary(max)  NOT NULL
);
GO

-- Creating table 'Caracteristicas'
CREATE TABLE [dbo].[Caracteristicas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(64)  NOT NULL,
    [Tipo] int  NOT NULL,
    [TipoBienCaracteristica_Caracteristica_Id] int  NOT NULL
);
GO

-- Creating table 'Novedades'
CREATE TABLE [dbo].[Novedades] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titulo] nvarchar(64)  NOT NULL,
    [Contenido] nvarchar(4000)  NOT NULL,
    [FechaHora] datetime  NOT NULL,
    [Prioridad] int  NOT NULL,
    [Configuracion_Id] int  NOT NULL
);
GO

-- Creating table 'Bienes'
CREATE TABLE [dbo].[Bienes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titulo] nvarchar(64)  NOT NULL,
    [Foto] varbinary(max)  NULL,
    [Latitud] decimal(18,15)  NOT NULL,
    [Longitud] decimal(18,15)  NOT NULL,
    [Direccion] nvarchar(128)  NULL,
    [Normas] nvarchar(4000)  NOT NULL,
    [Capacidad] smallint  NOT NULL,
    [Precio] decimal(18,0)  NOT NULL,
    [Descripcion] nvarchar(4000)  NOT NULL,
    [FechaAlquiler] datetime  NULL,
    [DuracionAlquiler] smallint  NOT NULL,
    [FechaAlta] datetime  NOT NULL,
    [TipoBien_Id] int  NOT NULL,
    [Usuario_Id] int  NOT NULL
);
GO

-- Creating table 'TiposBienes'
CREATE TABLE [dbo].[TiposBienes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(64)  NOT NULL,
    [Sitio_Id] int  NOT NULL
);
GO

-- Creating table 'Contenidos'
CREATE TABLE [dbo].[Contenidos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Mensaje] nvarchar(1024)  NOT NULL,
    [CantMarcas] smallint  NOT NULL,
    [ContenidoBien_Contenido_Id] int  NOT NULL,
    [Usuario_Id] int  NOT NULL
);
GO

-- Creating table 'Adjuntos'
CREATE TABLE [dbo].[Adjuntos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Data] varbinary(max)  NOT NULL,
    [NombreArchivo] nvarchar(64)  NOT NULL,
    [Formato] nvarchar(64)  NOT NULL,
    [Tipo] int  NOT NULL,
    [AdjuntoContenido_Adjunto_Id] int  NOT NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(64)  NOT NULL,
    [Apellido] nvarchar(64)  NOT NULL,
    [Mail] nvarchar(64)  NOT NULL,
    [NombreUsuario] nvarchar(64)  NOT NULL,
    [Contraseña] nvarchar(64)  NOT NULL,
    [UsuarioFacebook] nvarchar(128)  NULL,
    [UsuarioTwitter] nvarchar(128)  NULL
);
GO

-- Creating table 'ConfiguracionesOrigenesDatos'
CREATE TABLE [dbo].[ConfiguracionesOrigenesDatos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Sitio_Id] int  NOT NULL,
    [OrigenDatos_Id] int  NOT NULL
);
GO

-- Creating table 'HabilitacionesUsuarios'
CREATE TABLE [dbo].[HabilitacionesUsuarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CantContBloq] smallint  NOT NULL,
    [Habilitado] bit  NOT NULL,
    [Usuario_Id] int  NOT NULL,
    [Sitio_Id] int  NOT NULL
);
GO

-- Creating table 'BuzonesMensajes'
CREATE TABLE [dbo].[BuzonesMensajes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UsuarioBuzonMensajes_BuzonMensajes_Id] int  NOT NULL
);
GO

-- Creating table 'Mensajes'
CREATE TABLE [dbo].[Mensajes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Texto] nvarchar(4000)  NOT NULL,
    [FechaHora] datetime  NOT NULL,
    [Leido] bit  NOT NULL,
    [MensajeBuzonMensaje_Mensaje_Id] int  NOT NULL,
    [Remitente_Id] int  NOT NULL
);
GO

-- Creating table 'EspecificacionesBienes'
CREATE TABLE [dbo].[EspecificacionesBienes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Latitud] decimal(18,15)  NOT NULL,
    [Longitud] decimal(18,15)  NOT NULL,
    [Rango] smallint  NOT NULL,
    [Titulo] nvarchar(64)  NOT NULL,
    [Usuario_Id] int  NOT NULL,
    [TipoBien_Id] int  NOT NULL
);
GO

-- Creating table 'ValoresCaracteristicas'
CREATE TABLE [dbo].[ValoresCaracteristicas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Valor] nvarchar(1024)  NOT NULL,
    [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id] int  NULL,
    [Caracteristica_Id] int  NOT NULL,
    [ValorCaracteristicaBien_ValorCaracteristica_Id] int  NULL
);
GO

-- Creating table 'MeGusta'
CREATE TABLE [dbo].[MeGusta] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Fecha] datetime  NOT NULL,
    [Bien_Id] int  NOT NULL,
    [Usuario_Id] int  NOT NULL
);
GO

-- Creating table 'Atributos'
CREATE TABLE [dbo].[Atributos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(64)  NOT NULL,
    [AtributoOrigenDatos_Atributo_Id] int  NOT NULL
);
GO

-- Creating table 'ValoresAtributos'
CREATE TABLE [dbo].[ValoresAtributos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Valor] nvarchar(max)  NOT NULL,
    [Atributo_Id] int  NOT NULL,
    [ValorAtributoNovedadSitioOrigenDatos_ValorAtributoNovedad_Id] int  NOT NULL
);
GO

-- Creating table 'Sesiones'
CREATE TABLE [dbo].[Sesiones] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FechaConexion] datetime  NOT NULL,
    [UltimoUso] datetime  NOT NULL,
    [FechaCierre] datetime  NULL,
    [SesionID] nvarchar(256)  NOT NULL,
    [Usuario_Id] int  NOT NULL
);
GO

-- Creating table 'Dependencias'
CREATE TABLE [dbo].[Dependencias] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(64)  NOT NULL,
    [Dll] varbinary(max)  NOT NULL,
    [OrigenDatosDependencia_Dependencia_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Sitios'
ALTER TABLE [dbo].[Sitios]
ADD CONSTRAINT [PK_Sitios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrigenesDatos'
ALTER TABLE [dbo].[OrigenesDatos]
ADD CONSTRAINT [PK_OrigenesDatos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Caracteristicas'
ALTER TABLE [dbo].[Caracteristicas]
ADD CONSTRAINT [PK_Caracteristicas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Novedades'
ALTER TABLE [dbo].[Novedades]
ADD CONSTRAINT [PK_Novedades]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Bienes'
ALTER TABLE [dbo].[Bienes]
ADD CONSTRAINT [PK_Bienes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TiposBienes'
ALTER TABLE [dbo].[TiposBienes]
ADD CONSTRAINT [PK_TiposBienes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Contenidos'
ALTER TABLE [dbo].[Contenidos]
ADD CONSTRAINT [PK_Contenidos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Adjuntos'
ALTER TABLE [dbo].[Adjuntos]
ADD CONSTRAINT [PK_Adjuntos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ConfiguracionesOrigenesDatos'
ALTER TABLE [dbo].[ConfiguracionesOrigenesDatos]
ADD CONSTRAINT [PK_ConfiguracionesOrigenesDatos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HabilitacionesUsuarios'
ALTER TABLE [dbo].[HabilitacionesUsuarios]
ADD CONSTRAINT [PK_HabilitacionesUsuarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BuzonesMensajes'
ALTER TABLE [dbo].[BuzonesMensajes]
ADD CONSTRAINT [PK_BuzonesMensajes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Mensajes'
ALTER TABLE [dbo].[Mensajes]
ADD CONSTRAINT [PK_Mensajes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EspecificacionesBienes'
ALTER TABLE [dbo].[EspecificacionesBienes]
ADD CONSTRAINT [PK_EspecificacionesBienes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ValoresCaracteristicas'
ALTER TABLE [dbo].[ValoresCaracteristicas]
ADD CONSTRAINT [PK_ValoresCaracteristicas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MeGusta'
ALTER TABLE [dbo].[MeGusta]
ADD CONSTRAINT [PK_MeGusta]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Atributos'
ALTER TABLE [dbo].[Atributos]
ADD CONSTRAINT [PK_Atributos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ValoresAtributos'
ALTER TABLE [dbo].[ValoresAtributos]
ADD CONSTRAINT [PK_ValoresAtributos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Sesiones'
ALTER TABLE [dbo].[Sesiones]
ADD CONSTRAINT [PK_Sesiones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Dependencias'
ALTER TABLE [dbo].[Dependencias]
ADD CONSTRAINT [PK_Dependencias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Sitio_Id] in table 'TiposBienes'
ALTER TABLE [dbo].[TiposBienes]
ADD CONSTRAINT [FK_TipoBienSitio]
    FOREIGN KEY ([Sitio_Id])
    REFERENCES [dbo].[Sitios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TipoBienSitio'
CREATE INDEX [IX_FK_TipoBienSitio]
ON [dbo].[TiposBienes]
    ([Sitio_Id]);
GO

-- Creating foreign key on [TipoBienCaracteristica_Caracteristica_Id] in table 'Caracteristicas'
ALTER TABLE [dbo].[Caracteristicas]
ADD CONSTRAINT [FK_TipoBienCaracteristica]
    FOREIGN KEY ([TipoBienCaracteristica_Caracteristica_Id])
    REFERENCES [dbo].[TiposBienes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TipoBienCaracteristica'
CREATE INDEX [IX_FK_TipoBienCaracteristica]
ON [dbo].[Caracteristicas]
    ([TipoBienCaracteristica_Caracteristica_Id]);
GO

-- Creating foreign key on [ContenidoBien_Contenido_Id] in table 'Contenidos'
ALTER TABLE [dbo].[Contenidos]
ADD CONSTRAINT [FK_ContenidoBien]
    FOREIGN KEY ([ContenidoBien_Contenido_Id])
    REFERENCES [dbo].[Bienes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContenidoBien'
CREATE INDEX [IX_FK_ContenidoBien]
ON [dbo].[Contenidos]
    ([ContenidoBien_Contenido_Id]);
GO

-- Creating foreign key on [AdjuntoContenido_Adjunto_Id] in table 'Adjuntos'
ALTER TABLE [dbo].[Adjuntos]
ADD CONSTRAINT [FK_AdjuntoContenido]
    FOREIGN KEY ([AdjuntoContenido_Adjunto_Id])
    REFERENCES [dbo].[Contenidos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AdjuntoContenido'
CREATE INDEX [IX_FK_AdjuntoContenido]
ON [dbo].[Adjuntos]
    ([AdjuntoContenido_Adjunto_Id]);
GO

-- Creating foreign key on [Sitio_Id] in table 'ConfiguracionesOrigenesDatos'
ALTER TABLE [dbo].[ConfiguracionesOrigenesDatos]
ADD CONSTRAINT [FK_SitioSitioOrigenDatos]
    FOREIGN KEY ([Sitio_Id])
    REFERENCES [dbo].[Sitios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SitioSitioOrigenDatos'
CREATE INDEX [IX_FK_SitioSitioOrigenDatos]
ON [dbo].[ConfiguracionesOrigenesDatos]
    ([Sitio_Id]);
GO

-- Creating foreign key on [OrigenDatos_Id] in table 'ConfiguracionesOrigenesDatos'
ALTER TABLE [dbo].[ConfiguracionesOrigenesDatos]
ADD CONSTRAINT [FK_SitioOrigenDatosOrigenDato]
    FOREIGN KEY ([OrigenDatos_Id])
    REFERENCES [dbo].[OrigenesDatos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SitioOrigenDatosOrigenDato'
CREATE INDEX [IX_FK_SitioOrigenDatosOrigenDato]
ON [dbo].[ConfiguracionesOrigenesDatos]
    ([OrigenDatos_Id]);
GO

-- Creating foreign key on [Configuracion_Id] in table 'Novedades'
ALTER TABLE [dbo].[Novedades]
ADD CONSTRAINT [FK_NovedadSitioOrigenDatos]
    FOREIGN KEY ([Configuracion_Id])
    REFERENCES [dbo].[ConfiguracionesOrigenesDatos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_NovedadSitioOrigenDatos'
CREATE INDEX [IX_FK_NovedadSitioOrigenDatos]
ON [dbo].[Novedades]
    ([Configuracion_Id]);
GO

-- Creating foreign key on [UsuarioSitio_Sitio_Id] in table 'Sitios'
ALTER TABLE [dbo].[Sitios]
ADD CONSTRAINT [FK_UsuarioSitio]
    FOREIGN KEY ([UsuarioSitio_Sitio_Id])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioSitio'
CREATE INDEX [IX_FK_UsuarioSitio]
ON [dbo].[Sitios]
    ([UsuarioSitio_Sitio_Id]);
GO

-- Creating foreign key on [Usuario_Id] in table 'HabilitacionesUsuarios'
ALTER TABLE [dbo].[HabilitacionesUsuarios]
ADD CONSTRAINT [FK_UsuarioHabilitacionUsuarioSitio]
    FOREIGN KEY ([Usuario_Id])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioHabilitacionUsuarioSitio'
CREATE INDEX [IX_FK_UsuarioHabilitacionUsuarioSitio]
ON [dbo].[HabilitacionesUsuarios]
    ([Usuario_Id]);
GO

-- Creating foreign key on [Sitio_Id] in table 'HabilitacionesUsuarios'
ALTER TABLE [dbo].[HabilitacionesUsuarios]
ADD CONSTRAINT [FK_HabilitacionUsuarioSitioSitio]
    FOREIGN KEY ([Sitio_Id])
    REFERENCES [dbo].[Sitios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HabilitacionUsuarioSitioSitio'
CREATE INDEX [IX_FK_HabilitacionUsuarioSitioSitio]
ON [dbo].[HabilitacionesUsuarios]
    ([Sitio_Id]);
GO

-- Creating foreign key on [TipoBien_Id] in table 'Bienes'
ALTER TABLE [dbo].[Bienes]
ADD CONSTRAINT [FK_BienTipoBien]
    FOREIGN KEY ([TipoBien_Id])
    REFERENCES [dbo].[TiposBienes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BienTipoBien'
CREATE INDEX [IX_FK_BienTipoBien]
ON [dbo].[Bienes]
    ([TipoBien_Id]);
GO

-- Creating foreign key on [Usuario_Id] in table 'Bienes'
ALTER TABLE [dbo].[Bienes]
ADD CONSTRAINT [FK_BienUsuario]
    FOREIGN KEY ([Usuario_Id])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BienUsuario'
CREATE INDEX [IX_FK_BienUsuario]
ON [dbo].[Bienes]
    ([Usuario_Id]);
GO

-- Creating foreign key on [UsuarioBuzonMensajes_BuzonMensajes_Id] in table 'BuzonesMensajes'
ALTER TABLE [dbo].[BuzonesMensajes]
ADD CONSTRAINT [FK_UsuarioBuzonMensajes]
    FOREIGN KEY ([UsuarioBuzonMensajes_BuzonMensajes_Id])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioBuzonMensajes'
CREATE INDEX [IX_FK_UsuarioBuzonMensajes]
ON [dbo].[BuzonesMensajes]
    ([UsuarioBuzonMensajes_BuzonMensajes_Id]);
GO

-- Creating foreign key on [MensajeBuzonMensaje_Mensaje_Id] in table 'Mensajes'
ALTER TABLE [dbo].[Mensajes]
ADD CONSTRAINT [FK_MensajeBuzonMensaje]
    FOREIGN KEY ([MensajeBuzonMensaje_Mensaje_Id])
    REFERENCES [dbo].[BuzonesMensajes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MensajeBuzonMensaje'
CREATE INDEX [IX_FK_MensajeBuzonMensaje]
ON [dbo].[Mensajes]
    ([MensajeBuzonMensaje_Mensaje_Id]);
GO

-- Creating foreign key on [Remitente_Id] in table 'Mensajes'
ALTER TABLE [dbo].[Mensajes]
ADD CONSTRAINT [FK_MensajeUsuario]
    FOREIGN KEY ([Remitente_Id])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MensajeUsuario'
CREATE INDEX [IX_FK_MensajeUsuario]
ON [dbo].[Mensajes]
    ([Remitente_Id]);
GO

-- Creating foreign key on [Usuario_Id] in table 'EspecificacionesBienes'
ALTER TABLE [dbo].[EspecificacionesBienes]
ADD CONSTRAINT [FK_UsuarioWishList]
    FOREIGN KEY ([Usuario_Id])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioWishList'
CREATE INDEX [IX_FK_UsuarioWishList]
ON [dbo].[EspecificacionesBienes]
    ([Usuario_Id]);
GO

-- Creating foreign key on [TipoBien_Id] in table 'EspecificacionesBienes'
ALTER TABLE [dbo].[EspecificacionesBienes]
ADD CONSTRAINT [FK_EspecificacionBienTipoBien]
    FOREIGN KEY ([TipoBien_Id])
    REFERENCES [dbo].[TiposBienes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EspecificacionBienTipoBien'
CREATE INDEX [IX_FK_EspecificacionBienTipoBien]
ON [dbo].[EspecificacionesBienes]
    ([TipoBien_Id]);
GO

-- Creating foreign key on [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id] in table 'ValoresCaracteristicas'
ALTER TABLE [dbo].[ValoresCaracteristicas]
ADD CONSTRAINT [FK_EspecificacionBienValorCaracteristicaEspecificacion]
    FOREIGN KEY ([EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id])
    REFERENCES [dbo].[EspecificacionesBienes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EspecificacionBienValorCaracteristicaEspecificacion'
CREATE INDEX [IX_FK_EspecificacionBienValorCaracteristicaEspecificacion]
ON [dbo].[ValoresCaracteristicas]
    ([EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id]);
GO

-- Creating foreign key on [Caracteristica_Id] in table 'ValoresCaracteristicas'
ALTER TABLE [dbo].[ValoresCaracteristicas]
ADD CONSTRAINT [FK_ValorCaracteristicaEspecificacionCaracteristica]
    FOREIGN KEY ([Caracteristica_Id])
    REFERENCES [dbo].[Caracteristicas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ValorCaracteristicaEspecificacionCaracteristica'
CREATE INDEX [IX_FK_ValorCaracteristicaEspecificacionCaracteristica]
ON [dbo].[ValoresCaracteristicas]
    ([Caracteristica_Id]);
GO

-- Creating foreign key on [Bien_Id] in table 'MeGusta'
ALTER TABLE [dbo].[MeGusta]
ADD CONSTRAINT [FK_MeGustaBien]
    FOREIGN KEY ([Bien_Id])
    REFERENCES [dbo].[Bienes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MeGustaBien'
CREATE INDEX [IX_FK_MeGustaBien]
ON [dbo].[MeGusta]
    ([Bien_Id]);
GO

-- Creating foreign key on [Usuario_Id] in table 'MeGusta'
ALTER TABLE [dbo].[MeGusta]
ADD CONSTRAINT [FK_UsuarioMeGusta]
    FOREIGN KEY ([Usuario_Id])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioMeGusta'
CREATE INDEX [IX_FK_UsuarioMeGusta]
ON [dbo].[MeGusta]
    ([Usuario_Id]);
GO

-- Creating foreign key on [Usuario_Id] in table 'Contenidos'
ALTER TABLE [dbo].[Contenidos]
ADD CONSTRAINT [FK_ContenidoUsuario]
    FOREIGN KEY ([Usuario_Id])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContenidoUsuario'
CREATE INDEX [IX_FK_ContenidoUsuario]
ON [dbo].[Contenidos]
    ([Usuario_Id]);
GO

-- Creating foreign key on [AtributoOrigenDatos_Atributo_Id] in table 'Atributos'
ALTER TABLE [dbo].[Atributos]
ADD CONSTRAINT [FK_AtributoOrigenDatos]
    FOREIGN KEY ([AtributoOrigenDatos_Atributo_Id])
    REFERENCES [dbo].[OrigenesDatos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AtributoOrigenDatos'
CREATE INDEX [IX_FK_AtributoOrigenDatos]
ON [dbo].[Atributos]
    ([AtributoOrigenDatos_Atributo_Id]);
GO

-- Creating foreign key on [Atributo_Id] in table 'ValoresAtributos'
ALTER TABLE [dbo].[ValoresAtributos]
ADD CONSTRAINT [FK_AtributoValorAtributoNovedad]
    FOREIGN KEY ([Atributo_Id])
    REFERENCES [dbo].[Atributos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AtributoValorAtributoNovedad'
CREATE INDEX [IX_FK_AtributoValorAtributoNovedad]
ON [dbo].[ValoresAtributos]
    ([Atributo_Id]);
GO

-- Creating foreign key on [ValorAtributoNovedadSitioOrigenDatos_ValorAtributoNovedad_Id] in table 'ValoresAtributos'
ALTER TABLE [dbo].[ValoresAtributos]
ADD CONSTRAINT [FK_ValorAtributoNovedadSitioOrigenDatos]
    FOREIGN KEY ([ValorAtributoNovedadSitioOrigenDatos_ValorAtributoNovedad_Id])
    REFERENCES [dbo].[ConfiguracionesOrigenesDatos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ValorAtributoNovedadSitioOrigenDatos'
CREATE INDEX [IX_FK_ValorAtributoNovedadSitioOrigenDatos]
ON [dbo].[ValoresAtributos]
    ([ValorAtributoNovedadSitioOrigenDatos_ValorAtributoNovedad_Id]);
GO

-- Creating foreign key on [Usuario_Id] in table 'Sesiones'
ALTER TABLE [dbo].[Sesiones]
ADD CONSTRAINT [FK_SesionUsuario]
    FOREIGN KEY ([Usuario_Id])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SesionUsuario'
CREATE INDEX [IX_FK_SesionUsuario]
ON [dbo].[Sesiones]
    ([Usuario_Id]);
GO

-- Creating foreign key on [ValorCaracteristicaBien_ValorCaracteristica_Id] in table 'ValoresCaracteristicas'
ALTER TABLE [dbo].[ValoresCaracteristicas]
ADD CONSTRAINT [FK_ValorCaracteristicaBien]
    FOREIGN KEY ([ValorCaracteristicaBien_ValorCaracteristica_Id])
    REFERENCES [dbo].[Bienes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ValorCaracteristicaBien'
CREATE INDEX [IX_FK_ValorCaracteristicaBien]
ON [dbo].[ValoresCaracteristicas]
    ([ValorCaracteristicaBien_ValorCaracteristica_Id]);
GO

-- Creating foreign key on [OrigenDatosDependencia_Dependencia_Id] in table 'Dependencias'
ALTER TABLE [dbo].[Dependencias]
ADD CONSTRAINT [FK_OrigenDatosDependencia]
    FOREIGN KEY ([OrigenDatosDependencia_Dependencia_Id])
    REFERENCES [dbo].[OrigenesDatos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrigenDatosDependencia'
CREATE INDEX [IX_FK_OrigenDatosDependencia]
ON [dbo].[Dependencias]
    ([OrigenDatosDependencia_Dependencia_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------