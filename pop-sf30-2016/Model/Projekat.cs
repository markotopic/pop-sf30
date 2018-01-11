using pop_sf30_2016.Model;
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
        public bool Aktivan { get; set; }

        public ObservableCollection<TipNamestaja> tipnamestaja;
        public ObservableCollection<Namestaj> namestaj;
        public ObservableCollection<DodatnaUsluga> dodatnausluga;
        public ObservableCollection<Korisnik> korisnik;
        public ObservableCollection<Akcija> akcija;
        public ObservableCollection<Salon> salon;

        public ObservableCollection<ProdajaNamestaja> prodajanamestaja;//racun
        public ObservableCollection<StavkaNamestaja> stavka;//stavka
        

        private Projekat()
        {
            tipnamestaja = TipNamestaja.GetAll();
            namestaj = Namestaj.GetAll();
            dodatnausluga = DodatnaUsluga.GetAll();
            korisnik = Korisnik.GetAll();
            akcija = Akcija.GetAll();
            salon = Salon.GetAll();

            prodajanamestaja = ProdajaNamestaja.GetAll();
        }




    }
}
