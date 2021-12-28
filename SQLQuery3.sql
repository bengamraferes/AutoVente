SET IDENTITY_INSERT [dbo].[marques] ON
INSERT INTO [dbo].[marques] ([Id], [Origine], [Nom]) VALUES (1, 5, N'Ford')
INSERT INTO [dbo].[marques] ([Id], [Origine], [Nom]) VALUES (2, 2, N'Mercedes')
INSERT INTO [dbo].[marques] ([Id], [Origine], [Nom]) VALUES (3, 1, N'Peugeot')
INSERT INTO [dbo].[marques] ([Id], [Origine], [Nom]) VALUES (4, 2, N'Porsche')
INSERT INTO [dbo].[marques] ([Id], [Origine], [Nom]) VALUES (5, 7, N'toyota')
INSERT INTO [dbo].[marques] ([Id], [Origine], [Nom]) VALUES (6, 4, N'Seat')
INSERT INTO [dbo].[marques] ([Id], [Origine], [Nom]) VALUES (7, 3, N'Alpha Romeo')
INSERT INTO [dbo].[marques] ([Id], [Origine], [Nom]) VALUES (8, 6, N'Jaguar')
INSERT INTO [dbo].[marques] ([Id], [Origine], [Nom]) VALUES (9, 1, N'Reunault')
INSERT INTO [dbo].[marques] ([Id], [Origine], [Nom]) VALUES (10, 1, N'Wallys')
SET IDENTITY_INSERT [dbo].[marques] OFF


SET IDENTITY_INSERT [dbo].[couleurs] ON
INSERT INTO [dbo].[couleurs] ([Id], [CodeCouleur], [Nom]) VALUES (1, N'#000000', N'Noir')
INSERT INTO [dbo].[couleurs] ([Id], [CodeCouleur], [Nom]) VALUES (2, N'#FFFFFF', N'Blanc')
INSERT INTO [dbo].[couleurs] ([Id], [CodeCouleur], [Nom]) VALUES (3, N'#f00020', N'Rouge')
SET IDENTITY_INSERT [dbo].[couleurs] OFF

SET IDENTITY_INSERT [dbo].[models] ON
INSERT INTO [dbo].[models] ([Id], [Numero], [Carburent], [EmissionCo2], [Annee], [PuissanceReel], [NbPlaces], [Type], [Prix], [BoiteDeVitesse], [MarqueId], [Nom]) VALUES (1, N'25904', 1, CAST(137.00 AS Decimal(18, 2)), N'2017', 163, 5, 2, CAST(14124.00 AS Decimal(18, 2)), 2, 1, N'106')
INSERT INTO [dbo].[models] ([Id], [Numero], [Carburent], [EmissionCo2], [Annee], [PuissanceReel], [NbPlaces], [Type], [Prix], [BoiteDeVitesse], [MarqueId], [Nom]) VALUES (2, N'53697', 2, CAST(131.00 AS Decimal(18, 2)), N'2009', 252, 5, 1, CAST(20638.00 AS Decimal(18, 2)), 1, 2, N'Benz')
INSERT INTO [dbo].[models] ([Id], [Numero], [Carburent], [EmissionCo2], [Annee], [PuissanceReel], [NbPlaces], [Type], [Prix], [BoiteDeVitesse], [MarqueId], [Nom]) VALUES (3, N'66154', 3, CAST(185.00 AS Decimal(18, 2)), N'2001', 103, 1, 2, CAST(19055.00 AS Decimal(18, 2)), 1, 9, N'Twizy')
INSERT INTO [dbo].[models] ([Id], [Numero], [Carburent], [EmissionCo2], [Annee], [PuissanceReel], [NbPlaces], [Type], [Prix], [BoiteDeVitesse], [MarqueId], [Nom]) VALUES (4, N'60050', 4, CAST(114.00 AS Decimal(18, 2)), N'2000', 287, 5, 4, CAST(38828.00 AS Decimal(18, 2)), 2, 5, N'Yaris')
INSERT INTO [dbo].[models] ([Id], [Numero], [Carburent], [EmissionCo2], [Annee], [PuissanceReel], [NbPlaces], [Type], [Prix], [BoiteDeVitesse], [MarqueId], [Nom]) VALUES (5, N'58706', 1, CAST(127.00 AS Decimal(18, 2)), N'2021', 142, 4, 6, CAST(15000.00 AS Decimal(18, 2)), 2, 10, N'Iris')
INSERT INTO [dbo].[models] ([Id], [Numero], [Carburent], [EmissionCo2], [Annee], [PuissanceReel], [NbPlaces], [Type], [Prix], [BoiteDeVitesse], [MarqueId], [Nom]) VALUES (6, N'5445', 1, CAST(127.00 AS Decimal(18, 2)), N'2020', 140, 5, 5, CAST(12000.00 AS Decimal(18, 2)), 2, 6, N'test')
INSERT INTO [dbo].[models] ([Id], [Numero], [Carburent], [EmissionCo2], [Annee], [PuissanceReel], [NbPlaces], [Type], [Prix], [BoiteDeVitesse], [MarqueId], [Nom]) VALUES (7, N'78954', 1, CAST(12.00 AS Decimal(18, 2)), N'1990', 80, 3, 2, CAST(13000.00 AS Decimal(18, 2)), 1, 2, N'test2')
SET IDENTITY_INSERT [dbo].[models] OFF

SET IDENTITY_INSERT [dbo].[Vehicules] ON
INSERT INTO [dbo].[Vehicules] ([Immatriculation], [Id], [DateMisEnCirculation], [Kilometrage], [Etat], [IdModel], [IdCouleur], [Prix], [Vendu]) VALUES (N'TY-236-OP', 1, N'2018', 50000, 1, 7, 2, 20000, 1)
INSERT INTO [dbo].[Vehicules] ([Immatriculation], [Id], [DateMisEnCirculation], [Kilometrage], [Etat], [IdModel], [IdCouleur], [Prix], [Vendu]) VALUES (N'YU-236-LP', 2, N'1990', 202000, 4, 6, 1, 15000, 1)
INSERT INTO [dbo].[Vehicules] ([Immatriculation], [Id], [DateMisEnCirculation], [Kilometrage], [Etat], [IdModel], [IdCouleur], [Prix], [Vendu]) VALUES (N'KO-326-PO', 3, N'2005', 225000, 3, 5, 3, 35000, 1)
INSERT INTO [dbo].[Vehicules] ([Immatriculation], [Id], [DateMisEnCirculation], [Kilometrage], [Etat], [IdModel], [IdCouleur], [Prix], [Vendu]) VALUES (N'PO-365-LO', 4, N'2019', 40000, 1, 4, 2, 17500, 1)
INSERT INTO [dbo].[Vehicules] ([Immatriculation], [Id], [DateMisEnCirculation], [Kilometrage], [Etat], [IdModel], [IdCouleur], [Prix], [Vendu]) VALUES (N'OP-986-OR', 5, N'2003', 182000, 4, 2, 1, 29500, 1)
INSERT INTO [dbo].[Vehicules] ([Immatriculation], [Id], [DateMisEnCirculation], [Kilometrage], [Etat], [IdModel], [IdCouleur], [Prix], [Vendu]) VALUES (N'KI-563-RF', 6, N'2015', 135000, 2, 3, 3, 37000, 1)
SET IDENTITY_INSERT [dbo].[Vehicules] OFF


SET IDENTITY_INSERT [dbo].[adresses] ON
INSERT INTO [dbo].[adresses] ([Id], [Ville], [CodePostale], [Rue], [ComplementAdresse]) VALUES (1, N'La roche sur yon', N'85000', N'Louis auguste lansier', NULL)
INSERT INTO [dbo].[adresses] ([Id], [Ville], [CodePostale], [Rue], [ComplementAdresse]) VALUES (2, N'Nantes', N'44000', N'Marechal du cul', N'3 eme porte a gauche')
INSERT INTO [dbo].[adresses] ([Id], [Ville], [CodePostale], [Rue], [ComplementAdresse]) VALUES (3, N'AubignÃ© racan', N'72800', N'7 Rue lettre potier', NULL)
INSERT INTO [dbo].[adresses] ([Id], [Ville], [CodePostale], [Rue], [ComplementAdresse]) VALUES (4, N'Rennes', N'35000', N'Rue de la soif', N'La bonne bouteille')
INSERT INTO [dbo].[adresses] ([Id], [Ville], [CodePostale], [Rue], [ComplementAdresse]) VALUES (5, N'Nantes', N'44000', N'12 Rue des fleurs', NULL)
INSERT INTO [dbo].[adresses] ([Id], [Ville], [CodePostale], [Rue], [ComplementAdresse]) VALUES (6, N'Paris', N'93000', N'Bois de boulogne', NULL)
SET IDENTITY_INSERT [dbo].[adresses] OFF


SET IDENTITY_INSERT [dbo].[utilisateur] ON
INSERT INTO [dbo].[utilisateur] ([Id], [Prenom], [Password], [Email], [Telephone], [IdAdress], [Role], [Nom]) VALUES (1, N'Joshua', N'Admin', N'joshuavadrot@gmail.com', N'0624781591', 1, 3, N'Vadrot')
INSERT INTO [dbo].[utilisateur] ([Id], [Prenom], [Password], [Email], [Telephone], [IdAdress], [Role], [Nom]) VALUES (2, N'Damien', N'Admin', N'damien@gmail.com', N'0780315688', 3, 3, N'Goussin')
INSERT INTO [dbo].[utilisateur] ([Id], [Prenom], [Password], [Email], [Telephone], [IdAdress], [Role], [Nom]) VALUES (3, N'Feres', N'Admin', N'feres@gmail.com', N'0761897294', 4, 3, N'Bengamra')
INSERT INTO [dbo].[utilisateur] ([Id], [Prenom], [Password], [Email], [Telephone], [IdAdress], [Role], [Nom]) VALUES (4, N'Vada', N'User', N'morbi@yahoo.edu', N'0612231545', 2, 1, N'Knox')
INSERT INTO [dbo].[utilisateur] ([Id], [Prenom], [Password], [Email], [Telephone], [IdAdress], [Role], [Nom]) VALUES (5, N'Vivian', N'User', N'eu.enim@hotmail.ca', N'0645789652', 2, 1, N'Preston')
INSERT INTO [dbo].[utilisateur] ([Id], [Prenom], [Password], [Email], [Telephone], [IdAdress], [Role], [Nom]) VALUES (6, N'Chantale', N'Secretaire', N'chantale@gmail.com', N'0285963625', 5, 2, N'Goyave')
INSERT INTO [dbo].[utilisateur] ([Id], [Prenom], [Password], [Email], [Telephone], [IdAdress], [Role], [Nom]) VALUES (7, N'Mourad', N'Client', N'Mourad@gmail.com', N'0605040201', 6, 0, N'Mahrane')
SET IDENTITY_INSERT [dbo].[utilisateur] OFF


INSERT INTO [dbo].[ModelCouleurs] ([Model_Id], [Couleur_Id]) VALUES (2, 2)
INSERT INTO [dbo].[ModelCouleurs] ([Model_Id], [Couleur_Id]) VALUES (1, 1)
INSERT INTO [dbo].[ModelCouleurs] ([Model_Id], [Couleur_Id]) VALUES (1, 2)
INSERT INTO [dbo].[ModelCouleurs] ([Model_Id], [Couleur_Id]) VALUES (4, 3)
INSERT INTO [dbo].[ModelCouleurs] ([Model_Id], [Couleur_Id]) VALUES (4, 2)
INSERT INTO [dbo].[ModelCouleurs] ([Model_Id], [Couleur_Id]) VALUES (4, 1)