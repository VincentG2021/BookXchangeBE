CREATE TABLE [dbo].[Membre]
(
	[Id_Membre] int  NOT NULL IDENTITY,
    [Pseudo] NVARCHAR(50)  NOT NULL ,
    [Email] NVARCHAR(50)  NOT NULL ,
    [Prenom] NVARCHAR(50)  NULL ,
    [Nom] NVARCHAR(50)  NULL ,
    [Pwd_Hash] NVARCHAR(100)  NOT NULL ,
    [Role] int  NOT NULL DEFAULT 1,
    [Localisation] NVARCHAR(150)  NULL ,
    [Image] NVARCHAR(500)  NULL ,
    CONSTRAINT [PK_Membre] PRIMARY KEY ([Id_Membre]),
    CONSTRAINT UK_Member__Pseudo UNIQUE([Pseudo]),
	CONSTRAINT UK_Member__Email UNIQUE([Email])
)
