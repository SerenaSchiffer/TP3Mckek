USE logements;

CREATE TABLE membre
(
ID int PRIMARY KEY AUTO_INCREMENT,
nom varchar(255) NOT NULL,
prenom varchar(255) NOT NULL,
Addresse varchar(255) NOT NULL,
telephone varchar(255) NOT NULL,
courriel varchar(255) NOT NULL,
motDePasse varchar(255) NOT NULL,
isAdmin boolean NOT NULL DEFAULT false
);

CREATE TABLE chambre
(
ID int PRIMARY KEY AUTO_INCREMENT,
IDMembre int NOT NULL,
prix double NOT NULL,
adresse varchar(255),
distance double,
animaux boolean NOT NULL DEFAULT false,
details varchar(255),
internet boolean NOT NULL DEFAULT false,
stationnement boolean NOT NULL DEFAULT false,
deneigement boolean NOT NULL DEFAULT false,
meuble boolean NOT NULL DEFAULT false,
mobiliteReduite boolean NOT NULL DEFAULT false,
fumeur boolean NOT NULL DEFAULT FALSE,
quantite tinyint NOT NULL DEFAULT 1,
FOREIGN KEY(IDMembre) REFERENCES membre(ID)
);

CREATE TABLE image
(
ID int PRIMARY KEY AUTO_INCREMENT,
IDChambre int NOT NULL,
image blob NOT NULL,
FOREIGN KEY (IDChambre) REFERENCES chambre(ID)
);