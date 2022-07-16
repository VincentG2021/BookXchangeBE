
USE BooksXchangeDB
GO

-- Member
SET IDENTITY_INSERT [Membre] ON;
GO
INSERT INTO [Membre]([Id_Membre], [Pseudo], [Email], [Prenom], [Nom], [Localisation], [Pwd_Hash], [Role])
 VALUES (1, 'Vinsooe', 'atortetatravers@gmail.com', 'Vincent', 'Gadé', 'Bruxelles', '$argon2id$v=19$m=65536,t=3,p=1$/8iMVvfjmYbdwgmmSU2VMQ$bTSTfC2gqenk72HxTxoOhCbkkimyWPTOnA9k9uCvYOI', 1), -- pwd: dd
 (2, 'Yolo', 'yolo@ymail.com', 'Yohann', 'Nayo', 'Liège', '$argon2id$v=19$m=65536,t=3,p=1$/8iMVvfjmYbdwgmmSU2VMQ$bTSTfC2gqenk72HxTxoOhCbkkimyWPTOnA9k9uCvYOI', 2), -- pwd: dd
 (3, 'VincentHome', 'v@v', null, null, null, '$argon2id$v=19$m=65536,t=3,p=1$50FW4HC6hy0DfOr5gc3oOg$ZD2CRVxvLqWb26lIoxeabfkaz6IGmwUN8i/1MybkxXw', 3), -- pwd: Test1234=
 (4, 'VGH', 'v@g', null, null, null, '$argon2id$v=19$m=65536,t=3,p=1$bBAIiIyBkt4dyRuSDYKrQg$9fvsWfhY8sWqP2naJ4teZK+ioykJAU7DKfPeXroh+DI', 1); -- pwd: Book4ever

SET IDENTITY_INSERT [Membre] OFF;
GO

-- Livre
SET IDENTITY_INSERT [Livre] ON;
GO

INSERT INTO [Livre]([Id_Livre], [Titre], [Auteur], [Synopsis])
 VALUES (1, N'Grabuge chez les autres', 'Bibi', 'Incroyable, mais non peut-être !'),
        (2, N'Décembre au balcon', 'Paco Tison', 'Maestro Mateo souffle le chaud et le froid dans les chaumières locales.'),
        (3, N'Vivi la taupe cherche son chemin', 'Jules Verbes', 'Heureusement que Vivi a plein d''amis.'),
        (4, N'Sages commes des e-mages', 'Valère Cyberian', 'Nouvelle enquête pour Valère au pays des voisins connectés.');

SET IDENTITY_INSERT [Livre] OFF;
GO

-- Edition
SET IDENTITY_INSERT [Edition] ON;
GO

INSERT INTO [Edition]([Id_Edition], [ISBN], [Parution], [Format], [Id_Livre])
 VALUES (1, N'978-1-4028-9462-6', '2001-01-01', 'Poche', 1),
        (2, N'978-1-4028-9000-3', '2020-03-21', 'Limitée', 2),
        (3, N'978-1-4028-1000-1', '2022-01-01', 'Plastifié', 3),
        (4, N'978-1-4028-2222-2', '2005-06-21', 'Illustrée', 4),
        (5, N'978-1-4028-9400-1', '1992-12-25', 'Reliure maison', 1),
        (6, N'978-1-4028-9000-6', '2012-12-31', 'Poche', 2);

SET IDENTITY_INSERT [Edition] OFF;
GO


-- Categorie
SET IDENTITY_INSERT [Categorie] ON;
GO

INSERT INTO [Categorie]([Id_Categorie], [Nom])
 VALUES (1, 'Policier'),
        (2, 'Jeunesse'),
        (3, 'Horreur'),
        (4, 'Fantaisie');

SET IDENTITY_INSERT [Categorie] OFF;
GO

-- Livre_Categorie
SET IDENTITY_INSERT [Livre_Categorie] ON;
GO

INSERT INTO [Livre_Categorie]([Id_Livre], [Id_Categorie])
 VALUES (1, 4),
        (2, 3),
        (3, 2),
        (4, 1);

SET IDENTITY_INSERT [Livre_Categorie] OFF;
GO

-- Exemplaire
SET IDENTITY_INSERT [Exemplaire] ON;
GO

INSERT INTO [Exemplaire]([Id_Exemplaire], [Id_Membre], [Id_Edition])
 VALUES (1, 1, 1),
        (2, 1, 2),
        (3, 2, 3),
        (4, 2, 4),
        (5, 3, 5),
        (6, 3, 6);


SET IDENTITY_INSERT [Exemplaire] OFF;
GO

-- Echange
SET IDENTITY_INSERT [Echange] ON;
GO

INSERT INTO [Echange]([Id_Echange], [Status], [Date_Sortie], [Date_Retour], [Id_Exemplaire], [Id_Membre])
 VALUES (1, 1, '2022-06-22', '2022-06-22', 1, 1),
        (2, 2, '2022-06-22', '2022-06-22', 2, 2),
        (3, 3, '2022-06-22', '2022-06-22', 3, 1);

SET IDENTITY_INSERT [Echange] OFF;
GO
