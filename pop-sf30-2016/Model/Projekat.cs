using SF_30_2016.Model;
using SF_30_2016.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SF_30_2016.Modeli
{
    public class Projekat
    {
        public static Projekat Instace { get; private set; } = new Projekat();
        public List<TipNamestaja> TipoviNamestaja { get; set; }


        public List<Namestaj> Namestaj;

        public List<Namestaj> namestaj = new List<Namestaj>();

        public List<Namestaj> Naamestaj
        {
            get
            {
                this.namestaj = GenericSerializer.DeSerialize<Namestaj>("namestaj.xml");
                return this.namestaj;
            }
            set
            {
                namestaj = value;
                GenericSerializer.Serialize<Namestaj>("namestaj.xml", namestaj); }
        }

        public List<Korisnik> korisnici;
        public List<Korisnik> Korisnici
        {
            get
            {
                this.Korisnici = GenericSerializer.DeSerialize<Korisnik>("korisnici.xml");
                return Korisnici;
            }
            set
            {
                this.korisnici = value;
                GenericSerializer.Serialize<Korisnik>("korisnici.xml", korisnici);
            }
        }

        public List<TipNamestaja> tipnamestaja;
        public List<TipNamestaja> TipNamestaja
        {
            get
            {
                this.TipNamestaja = GenericSerializer.DeSerialize<TipNamestaja>("tipNamestaja.xml");
                return TipNamestaja;
            }
            set
            {
                this.TipNamestaja = value;
                GenericSerializer.Serialize<TipNamestaja>("tipNamestaja.xml", TipNamestaja);
            }
        }




    }
}
