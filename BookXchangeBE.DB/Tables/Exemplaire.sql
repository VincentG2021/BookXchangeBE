CREATE TABLE [dbo].[Exemplaire]
(
    [Id_Exemplaire] int  NOT NULL IDENTITY,
    [Id_Membre] int  NOT NULL ,
    [Id_Edition] int  NOT NULL ,
    CONSTRAINT [PK_Exemplaire] PRIMARY KEY ([Id_Exemplaire]),
    CONSTRAINT [FK_Exemplaire_Id_Membre] FOREIGN KEY([Id_Membre])
        REFERENCES [Membre] ([Id_Membre])
        ON UPDATE NO ACTION
		ON DELETE NO ACTION,
    CONSTRAINT [FK_Exemplaire_Id_Edition] FOREIGN KEY([Id_Edition])
        REFERENCES [Edition] ([Id_Edition])
        ON UPDATE CASCADE
		ON DELETE CASCADE


)
