using SF_30_2016.Modeli;
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
        public bool Obrisan { get; set; }

        public override string ToString()
        {
            return $"{Naziv}, {JedinicnaCena}";
        }

        public static Namestaj GetById(int id)
        {
            foreach (var Namestaja in Projekat.Instace.Naamestaj)
            {
                if (Namestaja.Id == id)
                {
                    return Namestaja;
                }
            }
            return null;
        }

    }
}
