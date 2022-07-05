CREATE TABLE [dbo].[Message]
(
   [Id_Message] int  NOT NULL IDENTITY,
   [Id__Membre_EnvoiMssg] INT NOT NULL,
   [Id__Membre_RecoitMssg] INT NOT NULL,
   [Date_Message] date  NOT NULL ,

   CONSTRAINT [PK_Message] PRIMARY KEY ([Id_Message]),
   CONSTRAINT [FK_Message_Id__Membre_EnvoiMssg] FOREIGN KEY([Id__Membre_EnvoiMssg])
		REFERENCES [Membre] ([Id_Membre])
		ON UPDATE NO ACTION
		ON DELETE NO ACTION,
   CONSTRAINT [FK_Message_Id__Membre_RecoitMssg] FOREIGN KEY([Id__Membre_RecoitMssg])
		REFERENCES [Membre] ([Id_Membre]) 
		ON UPDATE NO ACTION
		ON DELETE NO ACTION
)
