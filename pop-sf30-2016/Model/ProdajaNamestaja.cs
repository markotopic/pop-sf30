using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SF_30_2016.Model
{
    [Serializable]
    public class ProdajaNamestaja
    {
        public int Id { get; set; }
        public int BrojKomada { get; set; }
        public DateTime DatumProdaje { get; set; }
        public string BrojRacuna { get; set; }
        public List<DodatnaUsluga> DodatneUsluge { get; set; }
        public const double PDV = 0.02;
        public double UkupnaCena { get; set; }
        public string Kupac { get; set; }
        public List<Namestaj> NamestajZaProdaju { get; set; }
        
    }
}
