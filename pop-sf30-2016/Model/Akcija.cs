using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

        public static Akcija GetById(int id)
        {
            foreach (var akcija in Projekat.Instace.akcija)
            {
                if (akcija.Id == id)
                {
                    return akcija;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return $"{Popust}%";
        }

        #region CRUD

        public static ObservableCollection<Akcija> GetAll()
        {
            var akcija = new ObservableCollection<Akcija>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Akcija WHERE Obrisan=0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "Akcija");    // izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["Akcija"].Rows)
                {
                    var tn = new Akcija();
                    tn.Id = int.Parse(row["Id"].ToString());
                    tn.DatumPocetka = (DateTime)row["DatumPocetka"]; ;
                    tn.DatumZavrsetka = (DateTime)row["DatumZavrsetka"];
                    tn.Popust = Decimal.Parse(row["Popust"].ToString());
                    tn.Obrisan = bool.Parse(row["Obrisan"].ToString());
                    akcija.Add(tn);
                }
            }
            return akcija;
        }

        public static Akcija Create(Akcija tn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = $"INSERT INTO Akcija (DatumPocetka, DatumZavrsetka, Popust, Obrisan) VALUES (@DatumPocetka, @DatumZavrsetka, @Popust, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("DatumPocetka", tn.DatumPocetka);
                cmd.Parameters.AddWithValue("DatumZavrsetka", tn.DatumZavrsetka);
                cmd.Parameters.AddWithValue("Popust", tn.Popust);
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                int newId = int.Parse(cmd.ExecuteScalar().ToString());  // ExecuteScalar izvrsava query
                tn.Id = newId;
            }

            Projekat.Instace.akcija.Add(tn); // azuriram i STANJE MODELA!

            return tn;
        }

        public static void Update(Akcija tn)
        {
            //azuriranje baze
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {

                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Akcija SET DatumPocetka=@DatumPocetka, DatumZavrsetka=@DatumZavrsetka, Popust=@Popust, Obrisan=@Obrisan WHERE Id=@Id";

                cmd.Parameters.AddWithValue("Id", tn.Id);
                cmd.Parameters.AddWithValue("DatumPocetka", tn.DatumPocetka);
                cmd.Parameters.AddWithValue("DatumZavrsetka", tn.DatumZavrsetka);
                cmd.Parameters.AddWithValue("Popust", tn.Popust);
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                cmd.ExecuteNonQuery();

            }

            // azuriranje modela
            foreach (var akcijaa in Projekat.Instace.akcija)
            {
                if (tn.Id == akcijaa.Id)
                {
                    akcijaa.DatumPocetka = tn.DatumPocetka;
                    akcijaa.DatumZavrsetka = tn.DatumZavrsetka;
                    akcijaa.Popust = tn.Popust;
                    akcijaa.Obrisan = tn.Obrisan;
                    break;
                }
            }

        }

        public static void Delete(Akcija tn)
        {
            tn.Obrisan = true;
            Update(tn);
        }




        #endregion

    }
}
