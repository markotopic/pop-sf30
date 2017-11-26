using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SF_30_2016.Model
{

    [Serializable]
    public class DodatnaUsluga: INotifyPropertyChanged
    {
        private int id;
        private double cenaUsluge;
        private string naziv;
        private bool obrisan;

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

        public double CenaUsluge
        {
            get { return cenaUsluge; }
            set { cenaUsluge = value; OnPropertyChanged("CenaUsluge"); }
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

    }

    

    
}
