using SF_30_2016.Model;
using SF_30_2016.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SF_30_2016.Modeli
{
    public class Projekat
    {
        public static Projekat Instace { get; private set; } = new Projekat();

        public ObservableCollection<TipNamestaja> tipnamestaja;
        public ObservableCollection<Namestaj> Namestaj;
        public ObservableCollection<Korisnik> Korisnik;
        public ObservableCollection<DodatnaUsluga> DodatnaUsluga;
        public ObservableCollection<Akcija> Akcija;
        public ObservableCollection<Korisnik> TipKorisnika;
        public ObservableCollection<ProdajaNamestaja> ProdajaNamestaja;

        private Projekat()
        {
            tipnamestaja = new ObservableCollection<TipNamestaja>(GenericSerializer.DeSerialize<TipNamestaja>("tipNamestaja.xml"));
            Namestaj = new ObservableCollection<Namestaj>(GenericSerializer.DeSerialize<Namestaj>("namestaj.xml"));
            Korisnik = new ObservableCollection<Korisnik>(GenericSerializer.DeSerialize<Korisnik>("korisnici.xml"));
            DodatnaUsluga = new ObservableCollection<DodatnaUsluga>(GenericSerializer.DeSerialize<DodatnaUsluga>("dodatneUsluge.xml"));
            Akcija = new ObservableCollection<Akcija>(GenericSerializer.DeSerialize<Akcija>("akcije.xml"));
            ProdajaNamestaja = new ObservableCollection<ProdajaNamestaja>(GenericSerializer.DeSerialize<ProdajaNamestaja>("prodajaNamestaja.xml"));
            TipKorisnika = new ObservableCollection<Korisnik>(GenericSerializer.DeSerialize<Korisnik>("tipKorisnika.xml"));
        }




    }
}
