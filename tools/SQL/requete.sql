SELECT * from v_ClientListe;

DROP VIEW IF EXISTS v_ClientListe;

CREATE VIEW v_ClientListe AS (
SELECT c.id idClient, c.nom, AB.id idAbonnement,AB.description, ABC.dateDeb, ABc.dateFin, dbo.getSituation(ABC.dateDeb, ABc.dateFin) AS situation
FROM clients c
JOIN abonnements_clients ABc ON ABc.idClient = c.id 
JOIN abonnements AB ON AB.id = ABc.idAbonnement
);

