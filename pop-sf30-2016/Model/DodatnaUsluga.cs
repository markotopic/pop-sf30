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
    public class DodatnaUsluga: INotifyPropertyChanged
    {
        private int id;
        private double cenaUsluge;
        private string naziv;
        private bool obrisan;

        public static DodatnaUsluga GetById(int id)
        {
            foreach (var a in Projekat.Instace.dodatnausluga)
            {
                if (a.Id == id)
                {
                    return a;
                }
            }
            return null;
        }

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

        #region CRUD

        public static ObservableCollection<DodatnaUsluga> GetAll()
        {
            var dodatneUsluge = new ObservableCollection<DodatnaUsluga>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM DodatnaUsluga WHERE Obrisan=0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "DodatnaUsluga");    // izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["DodatnaUsluga"].Rows)
                {
                    var tn = new DodatnaUsluga();
                    tn.Id = int.Parse(row["Id"].ToString());
                    tn.CenaUsluge = double.Parse(row["CenaUsluge"].ToString());
                    tn.Naziv = row["Naziv"].ToString();
                    tn.Obrisan = bool.Parse(row["Obrisan"].ToString());
                    dodatneUsluge.Add(tn);
                }
            }
            return dodatneUsluge;
        }

        public static DodatnaUsluga Create(DodatnaUsluga tn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"INSERT INTO DodatnaUsluga (CenaUsluge, Naziv, Obrisan) VALUES (@CenaUsluge, @Naziv, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("CenaUsluge", tn.CenaUsluge);
                cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                int newId = int.Parse(cmd.ExecuteScalar().ToString());  // ExecuteScalar izvrsava query
                tn.Id = newId;
            }

            Projekat.Instace.dodatnausluga.Add(tn); // azuriram i STANJE MODELA!

            return tn;
        }

        public static void Update(DodatnaUsluga tn)
        {
            //azuriranje baze
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {

                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE DodatnaUsluga SET CenaUsluge=@CenaUsluge, Naziv=@Naziv, Obrisan=@Obrisan WHERE Id=@Id";

                cmd.Parameters.AddWithValue("Id", tn.Id);
                cmd.Parameters.AddWithValue("CenaUsluge", tn.CenaUsluge);
                cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                cmd.ExecuteNonQuery();

            }

            // azuriranje modela
            foreach (var dodatnaUsluga in Projekat.Instace.dodatnausluga)
            {
                if (tn.Id == dodatnaUsluga.Id)
                {
                    dodatnaUsluga.CenaUsluge = tn.CenaUsluge;
                    dodatnaUsluga.Naziv = tn.Naziv;
                    dodatnaUsluga.Obrisan = tn.Obrisan;
                    break;
                }
            }
            
        }

        public static void Delete(DodatnaUsluga tn)
        {
            tn.Obrisan = true;
            Update(tn);
        }

        #endregion

    }

    

    
}
