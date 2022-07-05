CREATE TABLE [dbo].[Categorie]
(
	[Id_Categorie] int  NOT NULL IDENTITY,
    [Nom] NVARCHAR(50)  NOT NULL ,
    CONSTRAINT [PK_Categorie] PRIMARY KEY ([Id_Categorie])
)
