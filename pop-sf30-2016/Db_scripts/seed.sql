--seed.sql

insert into TipNamestaja(Naziv, Obrisan) values('Kuhinja', 0);
insert into TipNamestaja(Naziv, Obrisan) values('Dnevni boravak', 0);
insert into TipNamestaja(Naziv, Obrisan) values('Spavaca soba', 0);

INSERT INTO Korisnik(Ime, Prezime, KorisnickoIme, Sifra, TipKorisnika, Obrisan) VALUES('Marko', 'Topic', 'mare', '123', 1, 0);
INSERT INTO Korisnik(Ime, Prezime, KorisnickoIme, Sifra, TipKorisnika, Obrisan) VALUES('Petar', 'Petrovic', 'pera', '321', 0, 0);

INSERT INTO DodatnaUsluga(CenaUsluge, Naziv, Obrisan) VALUES (1500, 'Dostava', 0);
INSERT INTO DodatnaUsluga(CenaUsluge, Naziv, Obrisan) VALUES (1500, 'Montaza', 0);

INSERT INTO Akcija(datumPocetka, datumZavrsetka, popust, obrisan) VALUES ('1/10/2018 1:27:31 PM', '3/31/2018 12:00:00 AM', 00.00, 0);
INSERT INTO Akcija(datumPocetka, datumZavrsetka, popust, obrisan) VALUES ('1/10/2018 1:27:31 PM', '3/31/2018 12:00:00 AM', 15.00, 0);
INSERT INTO Akcija(datumPocetka, datumZavrsetka, popust, obrisan) VALUES ('1/10/2018 1:27:31 PM', '3/31/2018 12:00:00 AM', 30.00, 0);

INSERT INTO Namestaj(TipNamestajaId, AkcijaId, Naziv, Sifra, Cena, Kolicina, Obrisan)
VALUES (1, 1, 'Polica', 'Po1Ku', 3000, 5, 0);
INSERT INTO Namestaj(TipNamestajaId, AkcijaId, Naziv, Sifra, Cena, Kolicina, Obrisan)
VALUES (2, 2, 'Sofa', 'So2Dn', 4000, 5, 0);
INSERT INTO Namestaj(TipNamestajaId, AkcijaId, Naziv, Sifra, Cena, Kolicina, Obrisan)
VALUES (3, 3, 'Krevet', 'Kr3Sp', 5000, 5, 0);

INSERT INTO SALON(id, naziv, adresa, telefon, email, adresasajta, pib, maticnibroj, brziroracuna)
VALUES(1, 'FTN Salon', 'Trg Dositeja Obradovica', 06386482, 'salon@ftn.rs', 'www.ftn.uns.ac.rs', 1111, 12345, '54425-2452')

INSERT INTO Racun(DatumProdaje, BrojRacuna, Kupac, UkupnaCena, Obrisan) VALUES ('1/10/2018 1:27:31 PM', '255255255', 'Nikola', 9000, 0 );

