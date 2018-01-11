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
using System.Windows.Documents;
using System.Xml.Serialization;

namespace SF_30_2016.Model
{
    [Serializable]
    public class ProdajaNamestaja : INotifyPropertyChanged
    {
        public const double PDV = 0.02;
       
        private int id;
        private DateTime datumProdaje;
        private string brojRacuna;
        private string kupac;

        private double ukupnaCena;
        private bool obrisan;

        public bool Obrisan
        {
            get { return obrisan; }
            set { obrisan = value; OnPropertyChanged("Obrisan"); }
        }

        public double UkupnaCena
        {
            get { return ukupnaCena; }
            set { ukupnaCena = value; OnPropertyChanged("UkupnaCena"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Kupac
        {
            get { return kupac; }
            set { kupac = value; OnPropertyChanged("Kupac"); }
        }

        public string BrojRacuna
        {
            get { return brojRacuna; }
            set { brojRacuna = value; OnPropertyChanged("BrojRacuna"); }
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

        #region CRUD    

        public static ObservableCollection<ProdajaNamestaja> GetAll()
        {
            var namestaj = new ObservableCollection<ProdajaNamestaja>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Racun";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "Racun");    // izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["Racun"].Rows)
                {
                    var tn = new ProdajaNamestaja();

                    tn.Id = int.Parse(row["Id"].ToString());
                    tn.DatumProdaje = DateTime.Parse(row["DatumProdaje"].ToString());
                    tn.BrojRacuna = row["BrojRacuna"].ToString();
                    tn.Kupac = row["Kupac"].ToString();
                    tn.UkupnaCena = double.Parse(row["UkupnaCena"].ToString());
                    tn.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    namestaj.Add(tn);
                }
            }
            return namestaj;
        }

        public static ProdajaNamestaja Create(ProdajaNamestaja tn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                DataSet ds = new DataSet();

                cmd.CommandText = "INSERT INTO Racun (Id, DatumProdaje, BrojRacuna, Kupac, UkupnaCena, Obrisan) VALUES (@Id, @DatumProdaje, @BrojRacuna, @Kupac, @UkupnaCena, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Id", tn.Id);
                cmd.Parameters.AddWithValue("DatumProdaje", tn.DatumProdaje);
                cmd.Parameters.AddWithValue("BrojRacuna", tn.BrojRacuna);
                cmd.Parameters.AddWithValue("Kupac", tn.Kupac);
                cmd.Parameters.AddWithValue("UkupnaCena", tn.UkupnaCena);
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                int newId = int.Parse(cmd.ExecuteScalar().ToString());  // ExecuteScalar izvrsava query
                tn.Id = newId;
            }

            Projekat.Instace.prodajanamestaja.Add(tn);
            return tn;
        }

        #endregion


    }
}
