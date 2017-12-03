using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SF_30_2016.Model
{
    [Serializable]
    public class ProdajaNamestaja
    {
        public List<DodatnaUsluga> DodatneUsluge { get; set; }
        public const double PDV = 0.02;
        public List<Namestaj> NamestajZaProdaju { get; set; }

        private int id;
        private DateTime datumProdaje;
        private int brojKomada;
        private string brojRacuna;
        private double ukupnaCena;
        private string kupac;


        public string Kupac
        {
            get { return kupac; }
            set { kupac = value; }
        }


        public double UkupnaCena
        {
            get { return ukupnaCena; }
            set { ukupnaCena = value; }
        }



        public string BrojRacuna
        {
            get { return brojRacuna; }
            set { brojRacuna = value; }
        }


        public int BrojKomada
        {
            get { return brojKomada; }
            set { brojKomada = value; }
        }



        public DateTime DatumProdaje
        {
            get { return datumProdaje; }
            set { datumProdaje = value; }
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}
