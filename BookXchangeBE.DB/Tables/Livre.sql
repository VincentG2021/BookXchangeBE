CREATE TABLE [dbo].[Livre]
(
	[Id_Livre] int  NOT NULL IDENTITY,
    [Titre] NVARCHAR(50)  NOT NULL ,
    [Auteur] NVARCHAR(50)  NOT NULL ,
    [Synopsis] NVARCHAR(500)  NOT NULL ,
    CONSTRAINT [PK_Livre] PRIMARY KEY ([Id_Livre])
)
