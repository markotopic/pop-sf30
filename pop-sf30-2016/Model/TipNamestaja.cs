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
        private bool obrisan;

        //private int tipNamestajaId;
        //public int TipNamestajaId
        //{
        //    get { return tipNamestajaId; }
        //    set { tipNamestajaId = value; OnPropertyChanged("TipNamestajaId"); }
        //}

        public bool Obrisan
        {
            get { return obrisan; }
            set { obrisan = value; OnPropertyChanged("Obrisan"); }
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
