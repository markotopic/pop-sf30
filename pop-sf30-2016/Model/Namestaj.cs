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
        private double jedinicnaCena;
        private TipNamestaja tipNamestaja;
        private string sifra;
        private int kolicina;

        private int akcijaId;
        private Akcija akcija;

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; OnPropertyChanged("Naziv"); }
        }

        public string Sifra
        {
            get { return sifra = Naziv.Substring(0, 2) + Id.ToString() + TipNamestaja.ToString().Substring(0, 2); }
            set { sifra = value; OnPropertyChanged("Sifra"); }
        }

        public int AkcijaId
        {
            get { return akcijaId; }
            set { akcijaId = value; }
        }


        public int Kolicina
        {
            get { return kolicina; }
            set { kolicina = value; OnPropertyChanged("Kolicina"); }
        }

        [XmlIgnore]
        public Akcija Akcija
        {
            get
            {
                if (akcija == null)
                {
                    akcija = Akcija.GetById(AkcijaId);
                }
                return akcija;
            }
            set
            {
                akcija = value;
                AkcijaId = akcija.Id;
                OnPropertyChanged("Akcija");
            }
        }

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


        public double JedinicnaCena
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
            foreach (var Namestaja in Projekat.Instace.namestaj)
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

        public static ObservableCollection<Namestaj> GetAll()
        {
            var namestaj = new ObservableCollection<Namestaj>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Namestaj WHERE Obrisan=0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "Namestaj");    // izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["Namestaj"].Rows)
                {
                    var tn = new Namestaj();

                    tn.Id = int.Parse(row["Id"].ToString());
                    tn.TipNamestajaId = int.Parse(row["TipNamestajaId"].ToString());
                    tn.AkcijaId = int.Parse(row["AkcijaId"].ToString());
                    tn.Naziv = row["Naziv"].ToString();
                    tn.Sifra = row["Sifra"].ToString();
                    tn.JedinicnaCena = double.Parse(row["Cena"].ToString());
                    tn.Kolicina = int.Parse(row["Kolicina"].ToString());
                    tn.Obrisan = bool.Parse(row["Obrisan"].ToString());
                
                    namestaj.Add(tn);
                }
            }
            return namestaj;
        }

        public static Namestaj Create(Namestaj tn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                DataSet ds = new DataSet();  

                cmd.CommandText = "INSERT INTO Namestaj (Naziv, TipNamestajaId, AkcijaId, Cena, Kolicina, Sifra, Obrisan) VALUES (@Naziv, @TipNamestajaId, @AkcijaId, @Cena, @Kolicina, @Sifra, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                //cmd.Parameters.AddWithValue("Id", tn.Id);
                cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                cmd.Parameters.AddWithValue("Cena", tn.jedinicnaCena);
                cmd.Parameters.AddWithValue("Kolicina", tn.Kolicina);
                cmd.Parameters.AddWithValue("TipNamestajaId", tn.TipNamestajaId);
                cmd.Parameters.AddWithValue("AkcijaId", tn.AkcijaId);
                cmd.Parameters.AddWithValue("Sifra", tn.Sifra);
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                //tn.Id = int.Parse(cmd.ExecuteScalar().ToString()); //executeScalar izvrsava upit

                int newId = int.Parse(cmd.ExecuteScalar().ToString());  // ExecuteScalar izvrsava query
                tn.Id = newId;
            }

            Projekat.Instace.namestaj.Add(tn);
            return tn;
        }

        public static void Update(Namestaj tn)
        {
            //azuriranje baze
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {

                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Namestaj SET Naziv=@Naziv, TipNamestajaId=@TipNamestajaId, AkcijaId=@AkcijaId, Cena=@Cena, Kolicina=@Kolicina, Sifra=@Sifra, Obrisan=@Obrisan WHERE Id=@Id";
                //cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Id", tn.Id);
                cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                cmd.Parameters.AddWithValue("Cena", tn.jedinicnaCena);
                cmd.Parameters.AddWithValue("Kolicina", tn.Kolicina);
                cmd.Parameters.AddWithValue("TipNamestajaId", tn.TipNamestajaId);
                cmd.Parameters.AddWithValue("AkcijaId", tn.AkcijaId);
                cmd.Parameters.AddWithValue("Sifra", tn.Sifra);
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                cmd.ExecuteNonQuery();

            }

            // azuriranje modela
            foreach (var namestaja in Projekat.Instace.namestaj)
            {
                if (tn.Id == namestaja.Id)
                {
                    namestaja.Id = tn.Id;
                    namestaja.Naziv = tn.Naziv;
                    namestaja.JedinicnaCena = tn.JedinicnaCena;
                    namestaja.Kolicina = tn.Kolicina;
                    namestaja.TipNamestajaId = tn.TipNamestajaId;
                    namestaja.AkcijaId = tn.AkcijaId;
                    namestaja.Sifra = tn.Sifra;
                    namestaja.Obrisan = tn.Obrisan;
                    break;
                }
            }

        }

        public static void Delete(Namestaj tn)
        {
            tn.Obrisan = true;
            Update(tn);
        }

        #endregion

    }
}
