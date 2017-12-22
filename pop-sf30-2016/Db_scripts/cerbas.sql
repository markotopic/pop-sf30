--crebas.sql

CREATE TABLE TipNamestaja (
	Id INT PRIMARY KEY IDENTITY (1,1),
    Naziv VARCHAR(80),
    Obrisan BIT
)
GO

CREATE TABLE Namestaj (
	Id INT PRIMARY KEY IDENTITY (1,1),
    TipNamestajaId INT,
    Naziv VARCHAR (100),
    Sifra VARCHAR(20),
    Cena NUMERIC(9,2),
    Kolicina INT,
    Obrisan BIT,
    FOREIGN KEY (TipNamestajaId) REFERENCES TipNamestaja(Id) ON DELETE CASCADE
)
GO

CREATE TABLE DodatnaUsluga (
	Id INT PRIMARY KEY IDENTITY (1,1),
    CenaUsluge NUMERIC(9,2),
	Naziv VARCHAR (20),
    Obrisan BIT
)
GO

CREATE TABLE Korisnik (
	Id INT PRIMARY KEY IDENTITY (1,1),
    Ime VARCHAR (20),
    Prezime VARCHAR(20),
	KorisnickoIme VARCHAR(20),
	Sifra VARCHAR(20),
	TipKorisnika INT,
    Obrisan BIT
)
GO

--///
CREATE TABLE Akcija (
	Id INT PRIMARY KEY IDENTITY (1,1),
	DatumPocetka DATETIME,
	DatumZavrsetka DATETIME,
    Popust NUMERIC(9,2),
    Obrisan BIT
)
GO

CREATE TABLE Racun (
	Id INT PRIMARY KEY IDENTITY (1,1)

)
GO