CREATE TABLE [dbo].[Echange]
(
    [Id_Echange] int  NOT NULL IDENTITY,
    [Status] int  NOT NULL ,
    [Date_Sortie] date  NOT NULL ,
    [Date_Retour] date  NOT NULL ,
    [Id_Exemplaire] int  NOT NULL ,
    [Id_Membre] int  NOT NULL ,
    CONSTRAINT [PK_Echange] PRIMARY KEY ([Id_Echange]),
    CONSTRAINT [FK_Echange_Id_Membre] FOREIGN KEY([Id_Membre])
        REFERENCES [Membre] ([Id_Membre])
        ON UPDATE CASCADE
		ON DELETE NO ACTION,
    CONSTRAINT [FK_Echange_Id_Exemplaire] FOREIGN KEY([Id_Exemplaire])
        REFERENCES [Exemplaire] ([Id_Exemplaire])
        ON UPDATE CASCADE
		ON DELETE CASCADE
)
