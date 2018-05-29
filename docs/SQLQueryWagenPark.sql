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

SELECT * FROM auto , dealer , Werkplaats , Onderhoud;
INSERT INTO Auto 
VALUES('8PTS26', 'Nissan' ,'Quasqai','34');
INSERT INTO Dealer
VALUES ('34','Vroegop');
INSERT INTO Auto
VALUES('4XJK76','Ford','Focus','73');
INSERT INTO Dealer
VALUES('73','Bosmans');
INSERT INTO Werkplaats
VALUES ('2','Quick');
INSERT INTO Werkplaats
VALUES ('18','Cheap');
INSERT INTO Werkplaats
VALUES ('14','Fixit');
INSERT INTO Werkplaats
VALUES ('6','C&G');
INSERT INTO Onderhoud
VALUES ('100316','345','8PTS26','2');
INSERT INTO Onderhoud
VALUES ('240916','128','8PTS26','18')
INSERT INTO Onderhoud
VALUES ('070317','175','8PTS26','2');
INSERT INTO Onderhoud
VALUES ('021117','405','8PTS26','14');
INSERT INTO Onderhoud
VALUES ('141016','190','4XJK76','6');
INSERT INTO Onderhoud
VALUES ('140417','225','4XJK76','6');
INSERT INTO Onderhoud
VALUES ('211017','310','4XJK76','6');
INSERT INTO Onderhoud
VALUES ('190418','290','4XJK76','6');