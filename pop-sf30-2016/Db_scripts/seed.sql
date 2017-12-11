#--seed.sql

insert into TipNamestaja(Naziv, Obrisan) values('Polica', 0);
insert into TipNamestaja(Naziv, Obrisan) values('Regal', 0);
insert into TipNamestaja(Naziv, Obrisan) values('Krevet', 0);

insert into Namestaj(TipNamestajaId, Naziv, Sifra, Cena, Kolicina, Obrisan)
values (1, 'Neka polica', 'Ne1PO', 123.5, 2,0);
insert into Namestaj(TipNamestajaId, Naziv, Sifra, Cena, Kolicina, Obrisan)
values (1, 'Neki regal', 'Ne1Re', 123.5, 2,0);
insert into Namestaj(TipNamestajaId, Naziv, Sifra, Cena, Kolicina, Obrisan)
values (1, 'Neki krevet', 'Ne1Kr', 123.5, 2,0);


