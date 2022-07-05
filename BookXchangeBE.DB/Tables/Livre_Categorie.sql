CREATE TABLE [dbo].[Livre_Categorie]
(
	[Id_Livre] int  NOT NULL IDENTITY,
    [Id_Categorie] int  NOT NULL,
	CONSTRAINT [FK_Livre_Categorie_Id_Livre] FOREIGN KEY([Id_Livre])
		REFERENCES [Livre] ([Id_Livre])
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
	CONSTRAINT [FK_Livre_Categorie_Id_Categorie] FOREIGN KEY([Id_Categorie])
		REFERENCES [Categorie] ([Id_Categorie])
		ON UPDATE CASCADE
		ON DELETE NO ACTION
)
