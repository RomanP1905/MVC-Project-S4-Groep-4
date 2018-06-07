CREATE TABLE auto 
(
kenteken   NCHAR(6) NOT NULL,
merk       nvarchar (25) , 
Type NVARCHAR (25) , 
DEALER_DealerNr INTEGER NOT NULL 
)
ALTER TABLE AUTO ADD constraint auto_pk PRIMARY KEY CLUSTERED (Kenteken)
CREATE TABLE dealer 
(
dealernr   INTEGER NOT NULL,
naam       nvarchar
(20) 
)
ALTER TABLE DEALER ADD constraint dealer_pk PRIMARY KEY CLUSTERED (DealerNr)
CREATE TABLE onderhoud (
onderhoudsdatum           DATE NOT NULL,
kosten                    smallmoney,
auto_kenteken             NCHAR(6) NOT NULL,
werkplaats_werkplaatsnr   INTEGER NOT NULL
)
ALTER TABLE ONDERHOUD ADD constraint onderhoud_pk PRIMARY KEY CLUSTERED
(AUTO_Kenteken, OnderhoudsDatum)
CREATE TABLE werkplaats 
(
werkplaatsnr   INTEGER NOT NULL,
naam           nvarchar (50) NOT NULL 
)
ALTER TABLE WERKPLAATS ADD constraint werkplaats_pk PRIMARY KEY CLUSTERED (WerkplaatsNr)
ALTER TABLE AUTO ADD CONSTRAINT auto_dealer_fk FOREIGN KEY ( dealer_dealernr ) REFERENCES dealer ( dealernr )
ON DELETE NO ACTION 
ON UPDATE 
NO ACTION
ALTER TABLE ONDERHOUD ADD CONSTRAINT onderhoud_auto_fk FOREIGN KEY ( auto_kenteken )
REFERENCES auto ( kenteken )
ON DELETE NO ACTION 
ON UPDATE
NO ACTION
ALTER TABLE ONDERHOUD
ADD CONSTRAINT onderhoud_werkplaats_fk FOREIGN KEY ( werkplaats_werkplaatsnr )
REFERENCES werkplaats ( werkplaatsnr )
ON DELETE NO ACTION 
ON UPDATE 
NO ACTION