using SF_30_2016.Modeli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SF_30_2016.Model
{
    [Serializable]
    public class Namestaj : INotifyPropertyChanged
    {
        private int id;
        private string naziv;
        private int tipNamestajaId;
        private bool obrisan;
        private int jedinicnaCena;
        private TipNamestaja tipNamestaja;
        private string sifra;

        [XmlIgnore]
        public TipNamestaja TipNamestaja
        {
            get
            {
                if (tipNamestaja == null)
                {
                    tipNamestaja = TipNamestaja.GetById(TipNamestajaId);
                }
                return tipNamestaja;
            }
            set
            {
                tipNamestaja = value;
                TipNamestajaId = tipNamestaja.Id;
                OnPropertyChanged("TipNamestaja");
            }
        }

        public string Sifra
        {
            get { return sifra; }
            set { sifra = value; OnPropertyChanged("Sifra"); }
        }


        public int JedinicnaCena
        {
            get { return jedinicnaCena; }
            set { jedinicnaCena = value; OnPropertyChanged("JedinicnaCena"); }
        }


        public bool Obrisan
        {
            get { return obrisan; }
            set { obrisan = value; OnPropertyChanged("Obrisan"); }
        }


        public int TipNamestajaId
        {
            get { return tipNamestajaId; }
            set { tipNamestajaId = value; OnPropertyChanged("TipNamestajaId"); }
        }


        //public double Cena
        //{
        //    get { return cena; }
        //    set { cena = value; OnPropertyChanged("Cena"); }
        //}


        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; OnPropertyChanged("Naziv"); }
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{Naziv}, {JedinicnaCena}";
        }

        public static Namestaj GetById(int id)
        {
            foreach (var Namestaja in Projekat.Instace.Namestaj)
            {
                if (Namestaja.Id == id)
                {
                    return Namestaja;
                }
            }
            return null;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
