using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Xml.Serialization;

namespace SF_30_2016.Model
{
    [Serializable]
    public class ProdajaNamestaja : INotifyPropertyChanged
    {
        public List<DodatnaUsluga> DodatneUsluge { get; set; }
        public const double PDV = 0.02;
        public List<Namestaj> NamestajZaProdaju { get; set; }

        private int id;
        private DateTime datumProdaje;
        private int brojKomada;
        private string brojRacuna;
        private double ukupnaCena;
        private string kupac;

        //---------------------------------------------------------------------------------------------

        //public ObservableCollection<DodatnaUsluga> Dodatnee { get; set; }
        //private int dodatnaUslugaId;
        //private DodatnaUsluga dodatnaUslugaaa;

        //[XmlIgnore]
        //public DodatnaUsluga DodatnaUsluga
        //{
        //    get
        //    {
        //        if (Dodatnee == null)
        //        {
        //            Dodatnee.Add(DodatnaUsluga.GetById(DodatnaUslugaId)) ;
        //            //dodatnaUslugaaa = DodatnaUsluga.GetById(DodatnaUslugaId);
        //        }
        //        return dodatnaUslugaaa;
        //    }
        //    set
        //    {
        //        dodatnaUslugaaa = value;
        //        DodatnaUslugaId = dodatnaUslugaaa.Id;
        //        OnPropertyChanged("DodatnaUsluga");
        //    }
        //}

        //public int DodatnaUslugaId
        //{
        //    get { return dodatnaUslugaId; }
        //    set { dodatnaUslugaId = value; OnPropertyChanged("DodatnaUslugaId"); }
        //}

        //----------------------------------------------------------------------------------------------

        public event PropertyChangedEventHandler PropertyChanged;

        public string Kupac
        {
            get { return kupac; }
            set { kupac = value; OnPropertyChanged("Kupac"); }
        }

        public double UkupnaCena
        {
            get { return ukupnaCena; }
            set { ukupnaCena = value; OnPropertyChanged("UkupnaCena"); }
        }

        public string BrojRacuna
        {
            get { return brojRacuna; }
            set { brojRacuna = value; OnPropertyChanged("BrojRacuna"); }
        }

        public int BrojKomada
        {
            get { return brojKomada; }
            set { brojKomada = value; OnPropertyChanged("BrojKomada"); }
        }

        public DateTime DatumProdaje
        {
            get { return datumProdaje; }
            set { datumProdaje = value; OnPropertyChanged("DatumProdaje"); }
        }

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
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
