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
        public ObservableCollection<Namestaj> namestaj;
        public ObservableCollection<DodatnaUsluga> dodatnausluga;
        public ObservableCollection<Korisnik> korisnik;

        public ObservableCollection<Akcija> Akcija;
        public ObservableCollection<ProdajaNamestaja> ProdajaNamestaja;

        private Projekat()
        {
            tipnamestaja = TipNamestaja.GetAll();
            namestaj = Namestaj.GetAll();
            dodatnausluga = DodatnaUsluga.GetAll();
            korisnik = Korisnik.GetAll();
            
            Akcija = new ObservableCollection<Akcija>(GenericSerializer.DeSerialize<Akcija>("akcije.xml"));
            ProdajaNamestaja = new ObservableCollection<ProdajaNamestaja>(GenericSerializer.DeSerialize<ProdajaNamestaja>("prodajaNamestaja.xml"));
        }




    }
}
