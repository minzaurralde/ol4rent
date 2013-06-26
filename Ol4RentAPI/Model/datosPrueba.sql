USE OL4RENT;

SET IDENTITY_INSERT [dbo].[Usuarios] ON
INSERT INTO [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Mail], [NombreUsuario], [Contraseña], [UsuarioFacebook], [UsuarioTwitter]) VALUES (3002, N'Super', N'Administrador', N'eminzaurralde@gmail.com', N'superadmin', N'superadmin', NULL, NULL)
INSERT INTO [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Mail], [NombreUsuario], [Contraseña], [UsuarioFacebook], [UsuarioTwitter]) VALUES (3003, N'Usuario', N'Uno', N'gr6tsi1@gmail.com', N'usuario1', N'usuario1', NULL, NULL)
INSERT INTO [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Mail], [NombreUsuario], [Contraseña], [UsuarioFacebook], [UsuarioTwitter]) VALUES (3004, N'Usuario', N'Dos', N'gr6tsi1@gmail.com', N'usuario2', N'usuario2', NULL, NULL)
INSERT INTO [dbo].[Usuarios] ([Id], [Nombre], [Apellido], [Mail], [NombreUsuario], [Contraseña], [UsuarioFacebook], [UsuarioTwitter]) VALUES (3005, N'Usuario', N'Tres', N'pedro.osimani@gmail.com', N'usuario3', N'usuario3', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF

SET IDENTITY_INSERT [dbo].[webpages_Roles] ON
INSERT INTO [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (1, N'PUBLIC_USER')
INSERT INTO [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (2, N'SITE_ADMIN')
INSERT INTO [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (3, N'SUPER_ADMIN')
SET IDENTITY_INSERT [dbo].[webpages_Roles] OFF

INSERT INTO [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (3002, N'2013-06-26 04:43:38', NULL, 1, NULL, 0, N'ACHrpuuqsbmlcfOKoML0nDjMvn0XkczVhegm00YW8IQOs5DckysLjtmAu69tUvBO6A==', N'2013-06-26 04:43:38', N'', NULL, NULL)
INSERT INTO [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (3003, N'2013-06-26 04:48:00', NULL, 1, NULL, 0, N'AFVEFmz0bVK1RIDfNdbr/vbjD8C9qdZw7hmB0Yyc3YaD41PQgsJtDDp1mpO4e2CwxQ==', N'2013-06-26 04:48:00', N'', NULL, NULL)
INSERT INTO [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (3004, N'2013-06-26 04:48:18', NULL, 1, NULL, 0, N'AL+GpCdkyO0DIGbSG1CbVwradyqQkgtsUORKGOm1nNAd7QF5tD8HFNsHYaUpKIwMvA==', N'2013-06-26 04:48:18', N'', NULL, NULL)
INSERT INTO [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (3005, N'2013-06-26 04:48:49', NULL, 1, NULL, 0, N'AF3fIaY/kbQkHoz3L+UiXSacVsVZ0JE503+Es16KeMSo5gvDgxdE977VlJaWhD5F6w==', N'2013-06-26 04:48:49', N'', NULL, NULL)

INSERT INTO [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (3002, 1)
INSERT INTO [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (3002, 3)
INSERT INTO [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (3003, 1)
INSERT INTO [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (3004, 1)
INSERT INTO [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (3004, 2)
INSERT INTO [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (3005, 1)

SET IDENTITY_INSERT [dbo].[Sitios] ON
INSERT INTO [dbo].[Sitios] ([Id], [Nombre], [Descripcion], [MailAdmin], [URL], [CantBienesPopulares], [CantMarcasXCont], [CantContBloqXUsu], [CantNovedadesHome], [AproximacionWish], [UsuarioSitio_Sitio_Id]) VALUES (1, N'Autos', N'Sitio para el alquiler de tu auto', N'gr6tsi1@gmail.com', N'www.autos.com.uy', 6, 3, 2, 10, 80, 3004)
SET IDENTITY_INSERT [dbo].[Sitios] OFF

SET IDENTITY_INSERT [dbo].[TiposBienes] ON
INSERT INTO [dbo].[TiposBienes] ([Id], [Nombre], [Sitio_Id]) VALUES (1, N'Auto', 1)
SET IDENTITY_INSERT [dbo].[TiposBienes] OFF

SET IDENTITY_INSERT [dbo].[Caracteristicas] ON
INSERT INTO [dbo].[Caracteristicas] ([Id], [Nombre], [Tipo], [TipoBienCaracteristica_Caracteristica_Id]) VALUES (1, N'Marca', 2, 1)
INSERT INTO [dbo].[Caracteristicas] ([Id], [Nombre], [Tipo], [TipoBienCaracteristica_Caracteristica_Id]) VALUES (2, N'Modelo', 2, 1)
INSERT INTO [dbo].[Caracteristicas] ([Id], [Nombre], [Tipo], [TipoBienCaracteristica_Caracteristica_Id]) VALUES (3, N'Año', 1, 1)
INSERT INTO [dbo].[Caracteristicas] ([Id], [Nombre], [Tipo], [TipoBienCaracteristica_Caracteristica_Id]) VALUES (4, N'Cantidad de Puertas', 1, 1)
INSERT INTO [dbo].[Caracteristicas] ([Id], [Nombre], [Tipo], [TipoBienCaracteristica_Caracteristica_Id]) VALUES (5, N'Techo solar', 4, 1)
INSERT INTO [dbo].[Caracteristicas] ([Id], [Nombre], [Tipo], [TipoBienCaracteristica_Caracteristica_Id]) VALUES (6, N'Alarma', 4, 1)
SET IDENTITY_INSERT [dbo].[Caracteristicas] OFF

SET IDENTITY_INSERT [dbo].[OrigenesDatos] ON
INSERT INTO [dbo].[OrigenesDatos] ([Id], [Nombre]) VALUES (1, N'WS Local')
INSERT INTO [dbo].[OrigenesDatos] ([Id], [Nombre]) VALUES (2, N'RSS')
SET IDENTITY_INSERT [dbo].[OrigenesDatos] OFF

SET IDENTITY_INSERT [dbo].[Atributos] ON
INSERT INTO [dbo].[Atributos] ([Id], [Nombre], [AtributoOrigenDatos_Atributo_Id]) VALUES (1, N'Nombre', 1)
INSERT INTO [dbo].[Atributos] ([Id], [Nombre], [AtributoOrigenDatos_Atributo_Id]) VALUES (2, N'Filtro', 1)
INSERT INTO [dbo].[Atributos] ([Id], [Nombre], [AtributoOrigenDatos_Atributo_Id]) VALUES (3, N'Url', 1)
INSERT INTO [dbo].[Atributos] ([Id], [Nombre], [AtributoOrigenDatos_Atributo_Id]) VALUES (4, N'Nombre', 2)
INSERT INTO [dbo].[Atributos] ([Id], [Nombre], [AtributoOrigenDatos_Atributo_Id]) VALUES (5, N'Filtro', 2)
INSERT INTO [dbo].[Atributos] ([Id], [Nombre], [AtributoOrigenDatos_Atributo_Id]) VALUES (6, N'URL', 2)
SET IDENTITY_INSERT [dbo].[Atributos] OFF

SET IDENTITY_INSERT [dbo].[Dependencias] ON
INSERT INTO [dbo].[Dependencias] ([Id], [Nombre], [OrigenDatosDependencia_Dependencia_Id]) VALUES (1, N'Newtonsoft.Json.dll', 1)
SET IDENTITY_INSERT [dbo].[Dependencias] OFF

SET IDENTITY_INSERT [dbo].[ConfiguracionesOrigenesDatos] ON
INSERT INTO [dbo].[ConfiguracionesOrigenesDatos] ([Id], [Sitio_Id], [OrigenDatos_Id]) VALUES (1, 1, 1)
INSERT INTO [dbo].[ConfiguracionesOrigenesDatos] ([Id], [Sitio_Id], [OrigenDatos_Id]) VALUES (2, 1, 2)
SET IDENTITY_INSERT [dbo].[ConfiguracionesOrigenesDatos] OFF

SET IDENTITY_INSERT [dbo].[ValoresAtributos] ON
INSERT INTO [dbo].[ValoresAtributos] ([Id], [Valor], [Atributo_Id], [ValorAtributoNovedadSitioOrigenDatos_ValorAtributoNovedad_Id]) VALUES (4, N'El Pais', 4, 2)
INSERT INTO [dbo].[ValoresAtributos] ([Id], [Valor], [Atributo_Id], [ValorAtributoNovedadSitioOrigenDatos_ValorAtributoNovedad_Id]) VALUES (5, N'auto', 5, 2)
INSERT INTO [dbo].[ValoresAtributos] ([Id], [Valor], [Atributo_Id], [ValorAtributoNovedadSitioOrigenDatos_ValorAtributoNovedad_Id]) VALUES (6, N'http://elpais.com/tag/rss/deportes_motor/a/', 6, 2)
SET IDENTITY_INSERT [dbo].[ValoresAtributos] OFF

SET IDENTITY_INSERT [dbo].[HabilitacionesUsuarios] ON
INSERT INTO [dbo].[HabilitacionesUsuarios] ([Id], [CantContBloq], [Habilitado], [Usuario_Id], [Sitio_Id]) VALUES (1, 0, 1, 3002, 1)
INSERT INTO [dbo].[HabilitacionesUsuarios] ([Id], [CantContBloq], [Habilitado], [Usuario_Id], [Sitio_Id]) VALUES (2, 2, 1, 3003, 1)
INSERT INTO [dbo].[HabilitacionesUsuarios] ([Id], [CantContBloq], [Habilitado], [Usuario_Id], [Sitio_Id]) VALUES (3, 0, 1, 3004, 1)
INSERT INTO [dbo].[HabilitacionesUsuarios] ([Id], [CantContBloq], [Habilitado], [Usuario_Id], [Sitio_Id]) VALUES (4, 0, 1, 3005, 1)
SET IDENTITY_INSERT [dbo].[HabilitacionesUsuarios] OFF

SET IDENTITY_INSERT [dbo].[Bienes] ON
INSERT INTO [dbo].[Bienes] ([Id], [Titulo], [Latitud], [Longitud], [Direccion], [Normas], [Capacidad], [Precio], [Descripcion], [FechaAlquiler], [DuracionAlquiler], [FechaAlta], [TipoBien_Id], [Usuario_Id]) VALUES (1, N'Aventador', CAST(-34.920059882936910 AS Decimal(18, 15)), CAST(-56.163117885589600 AS Decimal(18, 15)), NULL, N'No rayar', 1, CAST(1000 AS Decimal(18, 0)), N'Lamborghini Aventador en perfecto estado', NULL, 0, N'2013-06-21 02:09:54', 1, 3003)
INSERT INTO [dbo].[Bienes] ([Id], [Titulo], [Latitud], [Longitud], [Direccion], [Normas], [Capacidad], [Precio], [Descripcion], [FechaAlquiler], [DuracionAlquiler], [FechaAlta], [TipoBien_Id], [Usuario_Id]) VALUES (2, N'Mazda 323', CAST(-34.919954317364954 AS Decimal(18, 15)), CAST(-56.158912181854250 AS Decimal(18, 15)), NULL, N'Ninguna', 1, CAST(1100 AS Decimal(18, 0)), N'Gris, impecable', NULL, 0, N'2013-06-23 02:10:54', 1, 3003)
INSERT INTO [dbo].[Bienes] ([Id], [Titulo], [Latitud], [Longitud], [Direccion], [Normas], [Capacidad], [Precio], [Descripcion], [FechaAlquiler], [DuracionAlquiler], [FechaAlta], [TipoBien_Id], [Usuario_Id]) VALUES (3, N'Porsche 911 Carrera', CAST(-34.918223462477016 AS Decimal(18, 15)), CAST(-56.162281036376950 AS Decimal(18, 15)), NULL, N'Solo ciudad', 1, CAST(900 AS Decimal(18, 0)), N'Un clásico', NULL, 0, N'2013-06-23 02:11:48', 1, 3003)
INSERT INTO [dbo].[Bienes] ([Id], [Titulo], [Latitud], [Longitud], [Direccion], [Normas], [Capacidad], [Precio], [Descripcion], [FechaAlquiler], [DuracionAlquiler], [FechaAlta], [TipoBien_Id], [Usuario_Id]) VALUES (4, N'Maruti azul', CAST(-34.912874516309394 AS Decimal(18, 15)), CAST(-56.177730560302734 AS Decimal(18, 15)), NULL, N'Ninguna', 1, CAST(500 AS Decimal(18, 0)), N'Impecable', NULL, 0, N'2013-06-23 02:17:42', 1, 3005)
INSERT INTO [dbo].[Bienes] ([Id], [Titulo], [Latitud], [Longitud], [Direccion], [Normas], [Capacidad], [Precio], [Descripcion], [FechaAlquiler], [DuracionAlquiler], [FechaAlta], [TipoBien_Id], [Usuario_Id]) VALUES (5, N'Renault Clio', CAST(-34.906117454530740 AS Decimal(18, 15)), CAST(-56.168804168701170 AS Decimal(18, 15)), NULL, N'No hay', 1, CAST(950 AS Decimal(18, 0)), N'Amarillo, nuevito... ', NULL, 0, N'2013-06-24 02:18:31', 1, 3005)
INSERT INTO [dbo].[Bienes] ([Id], [Titulo], [Latitud], [Longitud], [Direccion], [Normas], [Capacidad], [Precio], [Descripcion], [FechaAlquiler], [DuracionAlquiler], [FechaAlta], [TipoBien_Id], [Usuario_Id]) VALUES (6, N'Ferrari 458', CAST(-34.915403872289160 AS Decimal(18, 15)), CAST(-56.160435676574710 AS Decimal(18, 15)), NULL, N'No hay', 1, CAST(1050 AS Decimal(18, 0)), N'Casi nuevo', NULL, 0, N'2013-06-25 02:21:43', 1, 3005)
INSERT INTO [dbo].[Bienes] ([Id], [Titulo], [Latitud], [Longitud], [Direccion], [Normas], [Capacidad], [Precio], [Descripcion], [FechaAlquiler], [DuracionAlquiler], [FechaAlta], [TipoBien_Id], [Usuario_Id]) VALUES (7, N'Tiida', CAST(-34.910622224173245 AS Decimal(18, 15)), CAST(-56.154727935791016 AS Decimal(18, 15)), NULL, N'No subir animales', 1, CAST(960 AS Decimal(18, 0)), N'Coupe, impecable', NULL, 0, N'2013-06-25 02:22:35', 1, 3005)
INSERT INTO [dbo].[Bienes] ([Id], [Titulo], [Latitud], [Longitud], [Direccion], [Normas], [Capacidad], [Precio], [Descripcion], [FechaAlquiler], [DuracionAlquiler], [FechaAlta], [TipoBien_Id], [Usuario_Id]) VALUES (8, N'Camaro', CAST(-34.913156048481680 AS Decimal(18, 15)), CAST(-56.180477142333984 AS Decimal(18, 15)), NULL, N'No hay', 1, CAST(1350 AS Decimal(18, 0)), N'Como el de Transformers', NULL, 0, N'2013-06-25 02:25:41', 1, 3004)
INSERT INTO [dbo].[Bienes] ([Id], [Titulo], [Latitud], [Longitud], [Direccion], [Normas], [Capacidad], [Precio], [Descripcion], [FechaAlquiler], [DuracionAlquiler], [FechaAlta], [TipoBien_Id], [Usuario_Id]) VALUES (9, N'Camioneta Willys', CAST(-34.901894008529740 AS Decimal(18, 15)), CAST(-56.156444549560550 AS Decimal(18, 15)), NULL, N'No meterla en el agua', 1, CAST(450 AS Decimal(18, 0)), N'Clásica!', NULL, 0, N'2013-06-25 02:27:13', 1, 3004)
INSERT INTO [dbo].[Bienes] ([Id], [Titulo], [Latitud], [Longitud], [Direccion], [Normas], [Capacidad], [Precio], [Descripcion], [FechaAlquiler], [DuracionAlquiler], [FechaAlta], [TipoBien_Id], [Usuario_Id]) VALUES (10, N'Fordson del 54', CAST(-34.909214510209950 AS Decimal(18, 15)), CAST(-56.189746856689450 AS Decimal(18, 15)), NULL, N'Ojo con el repecho', 1, CAST(250 AS Decimal(18, 0)), N'Bien cuidada', NULL, 0, N'2013-06-26 02:28:21', 1, 3004)
SET IDENTITY_INSERT [dbo].[Bienes] OFF

SET IDENTITY_INSERT [dbo].[ValoresCaracteristicas] ON
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (1, N'Lamborghini', NULL, 1, 1)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (2, N'Aventador', NULL, 2, 1)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (3, N'2011', NULL, 3, 1)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (4, N'2', NULL, 4, 1)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (5, N'False', NULL, 5, 1)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (6, N'True', NULL, 6, 1)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (7, N'Mazda', NULL, 1, 2)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (8, N'323', NULL, 2, 2)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (9, N'2010', NULL, 3, 2)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (10, N'4', NULL, 4, 2)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (11, N'False', NULL, 5, 2)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (12, N'True', NULL, 6, 2)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (13, N'Porsche', NULL, 1, 3)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (14, N'911', NULL, 2, 3)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (15, N'1993', NULL, 3, 3)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (16, N'2', NULL, 4, 3)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (17, N'False', NULL, 5, 3)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (18, N'False', NULL, 6, 3)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (19, N'Suzuki', NULL, 1, 4)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (20, N'Maruti', NULL, 2, 4)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (21, N'1997', NULL, 3, 4)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (22, N'4', NULL, 4, 4)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (23, N'False', NULL, 5, 4)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (24, N'False', NULL, 6, 4)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (25, N'Renault', NULL, 1, 5)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (26, N'Clio', NULL, 2, 5)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (27, N'2009', NULL, 3, 5)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (28, N'4', NULL, 4, 5)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (29, N'True', NULL, 5, 5)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (30, N'False', NULL, 6, 5)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (31, N'Ferrari', NULL, 1, 6)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (32, N'458', NULL, 2, 6)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (33, N'2010', NULL, 3, 6)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (34, N'2', NULL, 4, 6)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (35, N'False', NULL, 5, 6)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (36, N'True', NULL, 6, 6)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (37, N'Nissan', NULL, 1, 7)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (38, N'Tiida', NULL, 2, 7)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (39, N'2011', NULL, 3, 7)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (40, N'4', NULL, 4, 7)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (41, N'False', NULL, 5, 7)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (42, N'True', NULL, 6, 7)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (43, N'Chevrolet', NULL, 1, 8)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (44, N'Camaro', NULL, 2, 8)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (45, N'2010', NULL, 3, 8)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (46, N'2', NULL, 4, 8)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (47, N'False', NULL, 5, 8)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (48, N'True', NULL, 6, 8)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (49, N'Willys', NULL, 1, 9)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (50, N'72', NULL, 2, 9)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (51, N'1973', NULL, 3, 9)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (52, N'2', NULL, 4, 9)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (53, N'False', NULL, 5, 9)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (54, N'False', NULL, 6, 9)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (55, N'Fordson', NULL, 1, 10)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (56, N'54', NULL, 2, 10)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (57, N'1954', NULL, 3, 10)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (58, N'2', NULL, 4, 10)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (59, N'False', NULL, 5, 10)
INSERT INTO [dbo].[ValoresCaracteristicas] ([Id], [Valor], [EspecificacionBienValorCaracteristicaEspecificacion_ValorCaracteristicaEspecificacion_Id], [Caracteristica_Id], [ValorCaracteristicaBien_ValorCaracteristica_Id]) VALUES (60, N'False', NULL, 6, 10)
SET IDENTITY_INSERT [dbo].[ValoresCaracteristicas] OFF

SET IDENTITY_INSERT [dbo].[Novedades] ON
INSERT INTO [dbo].[Novedades] ([Id], [Titulo], [Contenido], [FechaHora], [Prioridad], [Configuracion_Id]) VALUES (1, N'Nuevo sitio en OL4RENT', N'Se ha creado un nuevo sitio en OL4RENT para el alquiler de autos.', N'2013-06-26 00:50:00', 1, 1)
SET IDENTITY_INSERT [dbo].[Novedades] OFF

SET IDENTITY_INSERT [dbo].[Sesiones] ON
INSERT INTO [dbo].[Sesiones] ([Id], [FechaConexion], [UltimoUso], [FechaCierre], [SesionID], [Usuario_Id]) VALUES (1, N'2013-06-26 01:43:39', N'2013-06-26 01:46:53', N'2013-06-26 01:46:54', N'iifbehdpkzqmj3havtasj1kf', 3002)
INSERT INTO [dbo].[Sesiones] ([Id], [FechaConexion], [UltimoUso], [FechaCierre], [SesionID], [Usuario_Id]) VALUES (2, N'2013-06-26 02:29:15', N'2013-06-26 02:32:30', N'2013-06-26 02:32:30', N'0b4daly4ewixm5shkqpavwre', 3003)
INSERT INTO [dbo].[Sesiones] ([Id], [FechaConexion], [UltimoUso], [FechaCierre], [SesionID], [Usuario_Id]) VALUES (3, N'2013-06-26 02:32:42', N'2013-06-26 02:47:10', NULL, N'0b4daly4ewixm5shkqpavwre', 3004)
INSERT INTO [dbo].[Sesiones] ([Id], [FechaConexion], [UltimoUso], [FechaCierre], [SesionID], [Usuario_Id]) VALUES (4, N'2013-06-26 02:13:45', N'2013-06-26 02:22:45', N'2013-06-26 02:22:45', N'0b4daly4ewixm5shkqpavwre', 3005)
SET IDENTITY_INSERT [dbo].[Sesiones] OFF

SET IDENTITY_INSERT [dbo].[Contenidos] ON
INSERT INTO [dbo].[Contenidos] ([Id], [Mensaje], [CantMarcas], [ContenidoBien_Contenido_Id], [Usuario_Id]) VALUES (3, N'no me gusta este auto!', 3, 4, 3003)
INSERT INTO [dbo].[Contenidos] ([Id], [Mensaje], [CantMarcas], [ContenidoBien_Contenido_Id], [Usuario_Id]) VALUES (4, N'felicitaciones che!', 0, 4, 3004)
INSERT INTO [dbo].[Contenidos] ([Id], [Mensaje], [CantMarcas], [ContenidoBien_Contenido_Id], [Usuario_Id]) VALUES (5, N'que bien loco, esta impecable ese maruti', 0, 4, 3004)
INSERT INTO [dbo].[Contenidos] ([Id], [Mensaje], [CantMarcas], [ContenidoBien_Contenido_Id], [Usuario_Id]) VALUES (6, N'flor de auto te mandaste', 0, 4, 3004)
INSERT INTO [dbo].[Contenidos] ([Id], [Mensaje], [CantMarcas], [ContenidoBien_Contenido_Id], [Usuario_Id]) VALUES (7, N'el amigo haciendo gala de su maruti', 0, 4, 3004)
INSERT INTO [dbo].[Contenidos] ([Id], [Mensaje], [CantMarcas], [ContenidoBien_Contenido_Id], [Usuario_Id]) VALUES (8, N'mira el cochazo del flaco!', 0, 4, 3004)
SET IDENTITY_INSERT [dbo].[Contenidos] OFF

SET IDENTITY_INSERT [dbo].[Adjuntos] ON
INSERT INTO [dbo].[Adjuntos] ([Id], [NombreArchivo], [Formato], [Tipo], [AdjuntoContenido_Adjunto_Id]) VALUES (1, N'4-7-0-maruti2.jpg', N'jpg', 1, 7)
INSERT INTO [dbo].[Adjuntos] ([Id], [NombreArchivo], [Formato], [Tipo], [AdjuntoContenido_Adjunto_Id]) VALUES (2, N'4-8-0-maruti3.jpg', N'jpg', 1, 8)
INSERT INTO [dbo].[Adjuntos] ([Id], [NombreArchivo], [Formato], [Tipo], [AdjuntoContenido_Adjunto_Id]) VALUES (3, N'4-8-1-Suzuki Maruti 2 ADIOS[1].swf', N'mpg', 2, 8)
SET IDENTITY_INSERT [dbo].[Adjuntos] OFF
