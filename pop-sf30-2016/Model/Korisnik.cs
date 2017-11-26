using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SF_30_2016.Model
{
    [Serializable]

    public enum TipKorisnika
    {
        Administrator,
        Prodavac
    }

    public class Korisnik : INotifyPropertyChanged
    {
        private int id;
        private string ime;
        private string prezime;
        private string korisnickoIme;
        private string sifra;
        private TipKorisnika tipKorisnika;
        private bool obrisan;

        public bool Obrisan
        {
            get { return obrisan; }
            set { obrisan = value; OnPropertyChanged("Obrisan"); }
        }

        public TipKorisnika TipKorisnika
        {
            get { return tipKorisnika; }
            set { tipKorisnika = value; OnPropertyChanged("TipKorisnika"); }
        }

        public string Sifra
        {
            get { return sifra; }
            set { sifra = value; OnPropertyChanged("Sifra"); }
        }

        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set { korisnickoIme = value; OnPropertyChanged("KorisnickoIme"); }
        }

        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; OnPropertyChanged("Prezime"); }
        }

        public string Ime
        {
            get { return ime; }
            set { ime = value; OnPropertyChanged("Ime"); }
        }

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public override string ToString()
        {
            return $"{tipKorisnika}";
        }

    }
}
