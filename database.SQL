/*
Created: 20-Sep-20
Modified: 09-Oct-20
Model: MySQL 5.7
Database: MySQL 5.7
*/

-- Create tables section -------------------------------------------------

-- Table donor

CREATE TABLE `donor`
(
  `donor_ID` Int NOT NULL AUTO_INCREMENT,
  `krvna_grupa_donor` Varchar(5),
  `pol` Char(1),
  `datum_poslednjeg_doniranja` Date,
  `datum_najranijeg_sledeceg_doniranja` Date,
  `tip_poslednjeg_doniranja` Varchar(24),
  `ime` Varchar(24),
  `prezime` Varchar(24),
  `registarski_broj` Varchar(24),
  `datum_rodjenja` Date,
  `lozinka` Varchar(24),
  PRIMARY KEY (`donor_ID`)
)
;

-- Table radnik

CREATE TABLE `radnik`
(
  `radnik_ID` Int NOT NULL AUTO_INCREMENT,
  `radno_mjesto` Varchar(32),
  `datum_zaposlenja` Date,
  `ime` Varchar(24),
  `prezime` Varchar(24),
  `korisnicko_ime` Varchar(24),
  `lozinka` Varchar(24),
  `datum_rodjenja` Date,
  `admin` Smallint DEFAULT 0,
  PRIMARY KEY (`radnik_ID`)
)
;

-- Table ljekarski_pregled

CREATE TABLE `ljekarski_pregled`
(
  `ljekarski_pregled_ID` Int NOT NULL AUTO_INCREMENT,
  `temperatura` Decimal(5,2),
  `krvni_pritisak` Varchar(7),
  `puls` Varchar(3),
  `nivo_hemoglobina` Decimal(5,2),
  `tezina_kg` Smallint,
  `napomena` Varchar(48),
  `donacija_ID` Int,
  PRIMARY KEY (`ljekarski_pregled_ID`)
)
;

CREATE INDEX `IX_Relationship33` ON `ljekarski_pregled` (`donacija_ID`)
;

-- Table donacija

CREATE TABLE `donacija`
(
  `donacija_ID` Int NOT NULL AUTO_INCREMENT,
  `tip_donacije` Varchar(24),
  `donirana_kolicina_ml` Smallint DEFAULT 450,
  `datum_doniranja` Date,
  `donor_ID` Int,
  PRIMARY KEY (`donacija_ID`)
)
;

CREATE INDEX `IX_Relationship9` ON `donacija` (`donor_ID`)
;

-- Table doza_krvi

CREATE TABLE `doza_krvi`
(
  `doza_krvi_ID` Int NOT NULL AUTO_INCREMENT,
  `serijska_oznaka` Varchar(32),
  `kolicina_krvnog_derivata_ml` Smallint DEFAULT 450,
  `tip_krvnog_derivata` Varchar(24),
  `krvna_grupa_doza` Varchar(5),
  `datum_isteka_roka` Date,
  `istekao_rok` Smallint DEFAULT 0,
  `donacija_ID` Int,
  `magacin_ID` Int,
  `isporuka_ID` Int,
  PRIMARY KEY (`doza_krvi_ID`)
)
;

CREATE INDEX `IX_Relationship11` ON `doza_krvi` (`donacija_ID`)
;

CREATE INDEX `IX_Relationship14` ON `doza_krvi` (`magacin_ID`)
;

CREATE INDEX `IX_Relationship29` ON `doza_krvi` (`isporuka_ID`)
;

-- Table magacin

CREATE TABLE `magacin`
(
  `magacin_ID` Int NOT NULL AUTO_INCREMENT,
  `krvna_grupa_magacin` Varchar(5),
  `broj_doza_krvi` Int DEFAULT 0,
  `broj_doza_plazme` Int DEFAULT 0,
  `broj_doza_trombocita` Int DEFAULT 0,
  `broj_doza_eritrocita` Int DEFAULT 0,
  `lokacija_ID` Int,
  PRIMARY KEY (`magacin_ID`)
)
;

CREATE INDEX `IX_Relationship13` ON `magacin` (`lokacija_ID`)
;

-- Table lokacija

CREATE TABLE `lokacija`
(
  `lokacija_ID` Int NOT NULL AUTO_INCREMENT,
  `adresa` Varchar(42),
  `mjesto` Varchar(32),
  `postanski_broj` Varchar(12),
  PRIMARY KEY (`lokacija_ID`)
)
;

-- Table zahtjev

CREATE TABLE `zahtjev`
(
  `zahtjev_ID` Int NOT NULL AUTO_INCREMENT,
  `krvna_grupa_zahtjev` Varchar(5),
  `tip_krvnog_derivata` Varchar(16),
  `zahtjevana_kolicina` Smallint,
  `datum_podnosenja_zahtjeva` Date,
  `zahtjev_prihvacen` Smallint DEFAULT 0,
  `napomena` Varchar(48),
  `zdravstvena_ustanova_ID` Int,
  PRIMARY KEY (`zahtjev_ID`)
)
;

CREATE INDEX `IX_Relationship24` ON `zahtjev` (`zdravstvena_ustanova_ID`)
;

-- Table kontakt

CREATE TABLE `kontakt`
(
  `kontakt_ID` Int NOT NULL AUTO_INCREMENT,
  `broj_telefona` Varchar(24),
  `email` Varchar(48),
  `lokacija_ID` Int,
  `zdravstvena_ustanova_ID` Int,
  `radnik_ID` Int,
  `donor_ID` Int,
  PRIMARY KEY (`kontakt_ID`)
)
;

CREATE INDEX `IX_Relationship16` ON `kontakt` (`lokacija_ID`)
;

CREATE INDEX `IX_Relationship27` ON `kontakt` (`zdravstvena_ustanova_ID`)
;

CREATE INDEX `IX_Relationship31` ON `kontakt` (`radnik_ID`)
;

CREATE INDEX `IX_Relationship32` ON `kontakt` (`donor_ID`)
;

-- Table potraznja

CREATE TABLE `potraznja`
(
  `potraznjaID` Int NOT NULL AUTO_INCREMENT,
  `krvna_grupa_potraznja` Varchar(5),
  `magacin_ID` Int,
  PRIMARY KEY (`potraznjaID`)
)
;

CREATE INDEX `IX_Relationship21` ON `potraznja` (`magacin_ID`)
;

-- Table zdravstvena_ustanova

CREATE TABLE `zdravstvena_ustanova`
(
  `zdravstvena_ustanova_ID` Int NOT NULL AUTO_INCREMENT,
  `naziv` Varchar(48),
  `verifikacioni_kod` Varchar(16),
  PRIMARY KEY (`zdravstvena_ustanova_ID`)
)
;

-- Table isporuka

CREATE TABLE `isporuka`
(
  `isporuka_ID` Int NOT NULL AUTO_INCREMENT,
  `datum_isporuke` Date,
  `zahtjev_ID` Int,
  PRIMARY KEY (`isporuka_ID`)
)
;

CREATE INDEX `IX_Relationship28` ON `isporuka` (`zahtjev_ID`)
;

-- Table vazece_doze

CREATE TABLE `vazece_doze`
(
  `doza_krvi_ID` Int NOT NULL
)
;

CREATE INDEX `IX_Relationship30` ON `vazece_doze` (`doza_krvi_ID`)
;

ALTER TABLE `vazece_doze` ADD PRIMARY KEY (`doza_krvi_ID`)
;

-- Create foreign keys (relationships) section -------------------------------------------------

ALTER TABLE `donacija` ADD CONSTRAINT `Relationship9` FOREIGN KEY (`donor_ID`) REFERENCES `donor` (`donor_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
;

ALTER TABLE `doza_krvi` ADD CONSTRAINT `Relationship11` FOREIGN KEY (`donacija_ID`) REFERENCES `donacija` (`donacija_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
;

ALTER TABLE `magacin` ADD CONSTRAINT `Relationship13` FOREIGN KEY (`lokacija_ID`) REFERENCES `lokacija` (`lokacija_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
;

ALTER TABLE `doza_krvi` ADD CONSTRAINT `Relationship14` FOREIGN KEY (`magacin_ID`) REFERENCES `magacin` (`magacin_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
;

ALTER TABLE `kontakt` ADD CONSTRAINT `Relationship16` FOREIGN KEY (`lokacija_ID`) REFERENCES `lokacija` (`lokacija_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
;

ALTER TABLE `potraznja` ADD CONSTRAINT `Relationship21` FOREIGN KEY (`magacin_ID`) REFERENCES `magacin` (`magacin_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
;

ALTER TABLE `zahtjev` ADD CONSTRAINT `Relationship24` FOREIGN KEY (`zdravstvena_ustanova_ID`) REFERENCES `zdravstvena_ustanova` (`zdravstvena_ustanova_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
;

ALTER TABLE `kontakt` ADD CONSTRAINT `Relationship27` FOREIGN KEY (`zdravstvena_ustanova_ID`) REFERENCES `zdravstvena_ustanova` (`zdravstvena_ustanova_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
;

ALTER TABLE `isporuka` ADD CONSTRAINT `Relationship28` FOREIGN KEY (`zahtjev_ID`) REFERENCES `zahtjev` (`zahtjev_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
;

ALTER TABLE `doza_krvi` ADD CONSTRAINT `Relationship29` FOREIGN KEY (`isporuka_ID`) REFERENCES `isporuka` (`isporuka_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
;

ALTER TABLE `vazece_doze` ADD CONSTRAINT `Relationship30` FOREIGN KEY (`doza_krvi_ID`) REFERENCES `doza_krvi` (`doza_krvi_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
;

ALTER TABLE `kontakt` ADD CONSTRAINT `Relationship31` FOREIGN KEY (`radnik_ID`) REFERENCES `radnik` (`radnik_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
;

ALTER TABLE `kontakt` ADD CONSTRAINT `Relationship32` FOREIGN KEY (`donor_ID`) REFERENCES `donor` (`donor_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
;

ALTER TABLE `ljekarski_pregled` ADD CONSTRAINT `Relationship33` FOREIGN KEY (`donacija_ID`) REFERENCES `donacija` (`donacija_ID`) ON DELETE RESTRICT ON UPDATE RESTRICT
;

