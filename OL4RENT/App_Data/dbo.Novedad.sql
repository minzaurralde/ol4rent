USE OL4RENT;
CREATE TABLE [dbo].[Novedad] (
    [Id]     BIGINT         IDENTITY (1, 1) NOT NULL,
    [Nombre] NVARCHAR (128) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

