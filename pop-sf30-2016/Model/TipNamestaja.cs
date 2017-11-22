using SF_30_2016.Modeli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SF_30_2016.Model
{
    public class TipNamestaja : INotifyPropertyChanged
    {
        private int id;
        private string naziv;
        private double jedinicnaCena;
        private int kolicinaUMagacinu;
        private int tipNamestajaId;

        public int TipNamestajaId
        {
            get { return tipNamestajaId; }
            set { tipNamestajaId = value; OnPropertyChanged("TipNamestajaId"); }
        }


        public int KolicinaUMagacinu
        {
            get { return kolicinaUMagacinu; }
            set { kolicinaUMagacinu = value; OnPropertyChanged("KolicinaUMagacinu"); }
        }


        public double JedinicnaCena
        {
            get { return jedinicnaCena; }
            set { jedinicnaCena = value; OnPropertyChanged("JedinicnaCena"); }
        }


        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; OnPropertyChanged("Naziv"); }
        }


        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static TipNamestaja GetById(int id)
        {
            foreach (var tipNamestaja in Projekat.Instace.tipnamestaja)
            {
                if (tipNamestaja.Id == id)
                {
                    return tipNamestaja;
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

        public override string ToString()
        {
            return $"{Naziv}";
        }
    }
    
}
