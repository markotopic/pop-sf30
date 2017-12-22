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

namespace SF_30_2016.Model
{
    [Serializable]

    public enum TipKorisnika
    {
        Administrator,
        Prodavac
    }

    public class Korisnik : INotifyPropertyChanged
    {
        private int id;
        private string ime;
        private string prezime;
        private string korisnickoIme;
        private string sifra;
        private TipKorisnika tipKorisnika;
        private bool obrisan;

        public bool Obrisan
        {
            get { return obrisan; }
            set { obrisan = value; OnPropertyChanged("Obrisan"); }
        }

        public TipKorisnika TipKorisnika
        {
            get { return tipKorisnika; }
            set { tipKorisnika = value; OnPropertyChanged("TipKorisnika"); }
        }

        public string Sifra
        {
            get { return sifra; }
            set { sifra = value; OnPropertyChanged("Sifra"); }
        }

        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set { korisnickoIme = value; OnPropertyChanged("KorisnickoIme"); }
        }

        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; OnPropertyChanged("Prezime"); }
        }

        public string Ime
        {
            get { return ime; }
            set { ime = value; OnPropertyChanged("Ime"); }
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

        public override string ToString()
        {
            return $"{tipKorisnika}";
        }

        #region Database

        public static ObservableCollection<Korisnik> GetAll()
        {
            var korisnik = new ObservableCollection<Korisnik>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Korisnik WHERE Obrisan=0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "Korisnik");    // izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["Korisnik"].Rows)
                {
                    var tn = new Korisnik();

                    tn.Id = int.Parse(row["Id"].ToString());
                    tn.Ime = row["Ime"].ToString();
                    tn.Prezime = row["Prezime"].ToString();
                    tn.KorisnickoIme = row["KorisnickoIme"].ToString();
                    tn.Sifra = row["Sifra"].ToString();
                    //tn.TipKorisnika = int.Parse(row["TipKorisnika"].ToString());
                    tn.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    korisnik.Add(tn);
                }
            }
            return korisnik;
        }

        public static Korisnik Create(Korisnik tn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                DataSet ds = new DataSet();

                cmd.CommandText = "INSERT INTO Korisnik (Ime, Prezime, KorisnickoIme, Sifra, TipKorisnika, Obrisan) VALUES (@Ime, @Prezime, @KorisnickoIme, @Sifra, @TipKorisnika, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                //cmd.Parameters.AddWithValue("Id", tn.Id);
                cmd.Parameters.AddWithValue("Ime", tn.Ime);
                cmd.Parameters.AddWithValue("Prezime", tn.Prezime);
                cmd.Parameters.AddWithValue("KorisnickoIme", tn.KorisnickoIme);
                cmd.Parameters.AddWithValue("Sifra", tn.Sifra);
                cmd.Parameters.AddWithValue("TipKorisnika", tn.TipKorisnika);
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                int newId = int.Parse(cmd.ExecuteScalar().ToString());  // ExecuteScalar izvrsava query
                tn.Id = newId;

            }

            Projekat.Instace.korisnik.Add(tn);
            return tn;
        }

        public static void Update(Korisnik tn)
        {
            //azuriranje baze
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {

                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Korisnik SET Ime=@Ime, Prezime=@Prezime, KorisnickoIme=@KorisnickoIme, Sifra=@Sifra, TipKorisnika=@TipKorisnika, Obrisan=@Obrisan WHERE Id=@Id";

                cmd.Parameters.AddWithValue("Id", tn.Id);
                cmd.Parameters.AddWithValue("Ime", tn.Ime);
                cmd.Parameters.AddWithValue("Prezime", tn.Prezime);
                cmd.Parameters.AddWithValue("KorisnickoIme", tn.KorisnickoIme);
                cmd.Parameters.AddWithValue("Sifra", tn.Sifra);
                cmd.Parameters.AddWithValue("TipKorisnika", tn.TipKorisnika);
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                cmd.ExecuteNonQuery();

            }

            // azuriranje modela
            foreach (var korisnici in Projekat.Instace.korisnik)
            {
                if (tn.Id == korisnici.Id)
                {

                    korisnici.Id = tn.Id;
                    korisnici.Ime = tn.Ime;
                    korisnici.Prezime = tn.Prezime;
                    korisnici.KorisnickoIme = tn.KorisnickoIme;
                    korisnici.Sifra = tn.Sifra;
                    korisnici.TipKorisnika = tn.TipKorisnika;
                    korisnici.Obrisan = tn.Obrisan;
                    break;
                }
            }

        }

        public static void Delete(Korisnik tn)
        {
            tn.Obrisan = true;
            Update(tn);
        }


        #endregion

    }
}
