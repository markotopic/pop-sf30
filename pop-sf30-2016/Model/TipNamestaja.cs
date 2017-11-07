using SF_30_2016.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SF_30_2016.Model
{
    public class TipNamestaja
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public double JedinicnaCena { get; set; }
        public int KolicinaUMagacinu { get; set; }
        public TipNamestaja TipNamestaj { get; set; }

        public static TipNamestaja GetById(int id)
        {
            foreach (var tipNamestaja in Projekat.Instace.TipoviNamestaja)
            {
                if (tipNamestaja.Id == id)
                {
                    return tipNamestaja;
                }
            }
            return null;
        }
    }
    
}
