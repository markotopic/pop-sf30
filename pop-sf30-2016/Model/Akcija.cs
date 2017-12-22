using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SF_30_2016.Modeli
{

    [Serializable]
    public class Akcija : INotifyPropertyChanged
    {
        private int id;
        private DateTime datumPocetka;
        private DateTime datumZavrsetka;
        private decimal popust;
        private bool obrisan;

        public bool Obrisan
        {
            get { return obrisan; }
            set { obrisan = value; OnPropertyChanged("Obrisan"); }
        }
        
        public decimal Popust
        {
            get { return popust; }
            set { popust = value; OnPropertyChanged("Popust"); }
        }

        public DateTime DatumZavrsetka
        {
            get { return datumZavrsetka; }
            set { datumZavrsetka = value; OnPropertyChanged("DatumZavrsetka"); }
        }

        public DateTime DatumPocetka
        {
            get { return datumPocetka; }
            set { datumPocetka = value; OnPropertyChanged("DatumPocetka"); }
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

        #region Databse




        #endregion

    }
}
