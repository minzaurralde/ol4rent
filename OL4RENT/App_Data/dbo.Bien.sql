CREATE TABLE [dbo].[Bien]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Nombre] NVARCHAR(128) NOT NULL, 
    [Descripcion] NVARCHAR(1024) NOT NULL, 
    [CantidadLikes] INT NOT NULL DEFAULT 0
)
