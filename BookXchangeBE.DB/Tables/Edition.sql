CREATE TABLE [dbo].[Edition]
(
    [Id_Edition] int  NOT NULL IDENTITY,
    [ISBN] NVARCHAR(50)  NOT NULL ,
    [Parution] date  NOT NULL ,
    [Format] NVARCHAR(50)  NOT NULL ,
    [Id_Livre] int  NOT NULL ,
    CONSTRAINT [PK_Edition] PRIMARY KEY ([Id_Edition]),
    CONSTRAINT [FK_Edition_Id_Livre] FOREIGN KEY([Id_Livre])
        REFERENCES [Livre] ([Id_Livre])
        ON UPDATE CASCADE
		ON DELETE NO ACTION
)
