using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SF_30_2016.Model
{
    [Serializable]
    public class Namestaj
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public double JedinicnaCena { get; set; }
        public int KolicinaUMagacinu { get; set; }
        public TipNamestaja TipNamestaja { get; set; }
        public bool Akcija { get; set; }

        public override string ToString()
        {
            return $"{Naziv}, {JedinicnaCena}";
        }
    }
}
