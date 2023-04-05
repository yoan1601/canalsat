INSERT INTO abonnements_clients (idAbonnement, idClient, dateDeb, dateFin) VALUES (4, 1, '2023-03-05', '2023-04-05');
INSERT INTO abonnements_clients (idAbonnement, idClient, dateDeb, dateFin) VALUES (3, 2, '2023-03-15', '2023-04-15');
INSERT INTO abonnements_clients (idAbonnement, idClient, dateDeb, dateFin) VALUES (6, 3, '2023-03-12', '2023-04-12');

INSERT INTO abonnements_clients (idAbonnement, idClient, dateDeb, dateFin) VALUES (3, 1, '2023-04-06', '2023-05-06');
INSERT INTO abonnements_clients (idAbonnement, idClient, dateDeb, dateFin) VALUES (2, 2, '2023-02-14', '2023-03-14');

INSERT INTO regions (description, t_reception_signal) VALUES ('Analamanga', 40);
INSERT INTO regions (description, t_reception_signal) VALUES ('Atsinanana', 55);
INSERT INTO regions (description, t_reception_signal) VALUES ('AtsimoAndrefana', 50);
INSERT INTO regions (description, t_reception_signal) VALUES ('Diana', 60);

INSERT INTO chaines (description, prix, signal)
VALUES 
('Canal+', 15, 70),
('OCS', 12, 70),
('beIN Sports', 15, 70),
('Eurosport', 6, 70),
('RMC Sport', 10, 70),
('Ciné+', 10, 70),
('National Geographic', 5, 70),
('Discovery', 5, 70),
('Planète+', 5, 70),
('Disney Channel', 5, 70),
('Cartoon Network', 4, 70),
('Nickelodeon', 4, 70),
('Comédie+', 4, 70),
('Syfy', 4, 70);


-- Bouquet Premium
INSERT INTO abonnements_chaines (idAbonnement, idChaine)
VALUES
(1, 1),
(1, 2),
(1, 3);

-- Bouquet Cinéma
INSERT INTO abonnements_chaines (idAbonnement, idChaine)
VALUES
(2, 1),
(2, 2),
(2, 6);

-- Bouquet Sport Max
INSERT INTO abonnements_chaines (idAbonnement, idChaine)
VALUES
(3, 3),
(3, 4),
(3, 5);

-- Bouquet Divertissement
INSERT INTO abonnements_chaines (idAbonnement, idChaine)
VALUES
(4, 1),
(4, 13),
(4, 14);

-- Bouquet Découverte
INSERT INTO abonnements_chaines (idAbonnement, idChaine)
VALUES
(5, 7),
(5, 8),
(5, 9);

-- Bouquet Jeunesse
INSERT INTO abonnements_chaines (idAbonnement, idChaine)
VALUES
(6, 10),
(6, 11),
(6, 12);


INSERT INTO Clients (Nom, IdRegion) VALUES ('Dupont', 1);
INSERT INTO Clients (Nom, IdRegion) VALUES ('Martin', 2);
INSERT INTO Clients (Nom, IdRegion) VALUES ('Durand', 3);

INSERT INTO abonnements (description) VALUES ('Premium');
INSERT INTO abonnements (description) VALUES ('Sport Max');
INSERT INTO abonnements (description) VALUES ('Cinéma');
INSERT INTO abonnements (description) VALUES ('Découverte');
INSERT INTO abonnements (description) VALUES ('Jeunesse');
INSERT INTO abonnements (description) VALUES ('Divertissement');


