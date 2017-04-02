use trajets

CREATE TABLE Membre
(
  ID int PRIMARY KEY AUTO_INCREMENT,
  nom varchar(255) NOT NULL,
  prenom varchar(255) NOT NULL,
  adresse varchar(255) NOT NULL,
  telephone varchar(255) NOT NULL,
  courriel varchar(255) NOT NULL,
  motDePasse varchar(255) NOT NULL,
  isAdmin boolean NOT NULL DEFAULT false,
  isDriver boolean NOT NULL DEFAULT false,
  fumeur boolean NOT NULL DEFAULT false,
  animaux boolean NOT NULL DEFAULT false,
  bienEquipe boolean NOT NULL DEFAULT false
);

CREATE TABLE Voyage
(
  ID int PRIMARY KEY AUTO_INCREMENT,
  IDConducteur int NOT NULL,
  prix double NOT NULL,
  depart varchar(255) NOT NULL,
  destination nvarchar(50) NOT NULL,
  heureDepart DATETIME NOT NULL,
  animaux boolean NOT NULL DEFAULT false,
  fumeur boolean NOT NULL DEFAULT false,
  bienEquipe boolean NOT NULL DEFAULT false,
  nbPassagers int NOT NULL,
  FOREIGN KEY(IDConducteur) REFERENCES Membre(ID)
);

CREATE TABLE Reservation
(
  IDVoyage int NOT NULL,
  IDPassager int NOT NULL,
  nbPassager int NOT NULL,
  FOREIGN KEY(IDPassager) REFERENCES Membre(ID),
  FOREIGN KEY(IDVoyage) REFERENCES Voyage(ID)
);
