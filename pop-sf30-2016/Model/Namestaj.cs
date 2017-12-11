using SF_30_2016.Modeli;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

        #region CRUD

        public static Namestaj Create(Namestaj tn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {

                SqlCommand cmd = con.CreateCommand();
                DataSet ds = new DataSet();  

                cmd.CommandText = "INSERT INTO Namestaja (Id, Naziv, JedinicnaCena, Sifra, Obrisan) VALUES (@Id, @Naziv, @JedinicnaCena, @Sifra, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY";

                cmd.Parameters.AddWithValue("Id", tn.Id);
                cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                cmd.Parameters.AddWithValue("JedinicnaCena", tn.JedinicnaCena);
                cmd.Parameters.AddWithValue("Sifra", tn.Sifra);
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                tn.Id = int.Parse(cmd.ExecuteScalar().ToString()); //executeScalar izvrsava upit

            }

            Projekat.Instace.Namestaj.Add(tn);
            return tn;
        }

        public static void Update(Namestaj tn)
        {
            //azuriranje baze
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {

                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Namestaj SET Naziv=@Naziv, JedinicnaCena=@JedinicnaCena, Sifra=@Sifra, Obrisan=@Obrisan WHERE Id=@Id";
                cmd.CommandText += "SELECT SCOPE_IDENTITY";

                cmd.Parameters.AddWithValue("Id", tn.Id);
                cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                cmd.Parameters.AddWithValue("JedinicnaCena", tn.JedinicnaCena);
                cmd.Parameters.AddWithValue("Sifra", tn.Sifra);
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                cmd.ExecuteNonQuery();

            }

            // azuriranje modela
            foreach (var namestaja in Projekat.Instace.Namestaj)
            {
                if (tn.Id == namestaja.Id)
                {

                    namestaja.Id = tn.Id;
                    namestaja.Naziv = tn.Naziv;
                    namestaja.JedinicnaCena = tn.JedinicnaCena;
                    namestaja.Sifra = tn.Sifra;
                    namestaja.Obrisan = tn.Obrisan;
                }
            }

        }
        #endregion

    }
}
