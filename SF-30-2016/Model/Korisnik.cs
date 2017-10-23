using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SF_30_2016.Model
{

    public enum TipKorisnika
    {
        Administrator,
        Prodavac
    }

    public class Korisnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public TipKorisnika TipKorisnika { get; set; }
        public bool Obrisan { get; set; }
    }
}
