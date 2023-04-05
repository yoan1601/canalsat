CREATE TABLE abonnements_clients (
  id BIGINT IDENTITY(1,1) PRIMARY KEY,
  idAbonnement BIGINT NOT NULL, 
  idClient BIGINT NOT NULL,
  dateDeb date NOT NULL,
  dateFin date NOT NULL
);

CREATE TABLE regions (
  id BIGINT IDENTITY(1,1) PRIMARY KEY,
  description TEXT NOT NULL,
  t_reception_signal real NOT NULL
);

CREATE TABLE chaines (
  id BIGINT IDENTITY(1,1) PRIMARY KEY,
  description TEXT NOT NULL,
  prix real NOT NULL
);

CREATE TABLE abonnements (
  id BIGINT IDENTITY(1,1) PRIMARY KEY,
  description TEXT NOT NULL,
  idClient BIGINT 
);

CREATE TABLE abonnements_remises (
  id BIGINT IDENTITY(1,1) PRIMARY KEY,
  idAbonnement BIGINT,
  remise real DEFAULT 0,
  dateDeb date NOT NULL,
  dateFin date
);

CREATE TABLE abonnements_chaines (
  id BIGINT IDENTITY(1,1) PRIMARY KEY,
  idAbonnement BIGINT NOT NULL, 
  idChaine BIGINT NOT NULL
);
