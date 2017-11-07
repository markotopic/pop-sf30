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
        public List<Namestaj> Namestaj { get; set; }
        public int MyProperty { get; set; }

        private List<Namestaj> namestaj = new List<Namestaj>();

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
                GenericSerializer.Serialize<Namestaj>("namestaj.xml", namestaj);  }
        }

    }
}
