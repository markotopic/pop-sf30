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
    public class Salon: INotifyPropertyChanged
    {
        private int id;
        private String naziv;
        private String adresa;
        private int telefon;
        private String email;
        private String adresaSajta;
        private int pib;
        private int maticniBroj;
        private String brZiroRacuna;
        private bool obrisan;

        public bool Obrisan
        {
            get { return obrisan; }
            set { obrisan = value; OnPropertyChanged("Obrisan"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }

        public String Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        public String Adresa
        {
            get { return adresa; }
            set
            {
                adresa = value;
                OnPropertyChanged("Adresa");
            }
        }

        public int Telefon
        {
            get { return telefon; }
            set
            {
                telefon = value;
                OnPropertyChanged("Telefon");
            }
        }

        public String Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public String AdresaSajta
        {
            get { return adresaSajta; }
            set
            {
                adresaSajta = value;
                OnPropertyChanged("AdresaSajta");
            }
        }

        public int PIB
        {
            get { return pib; }
            set
            {
                pib = value;
                OnPropertyChanged("PIB");
            }
        }

        public int MaticniBroj
        {
            get { return maticniBroj; }
            set
            {
                maticniBroj = value;
                OnPropertyChanged("MaticniBroj");
            }
        }


        public String BrZiroRacuna
        {
            get { return brZiroRacuna; }
            set
            {
                brZiroRacuna = value;
                OnPropertyChanged("BrZiroRacuna");
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region CRUD

        public static ObservableCollection<Salon> GetAll()
        {
            var salon = new ObservableCollection<Salon>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM Salon WHERE Obrisan=0";

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, "Salon");    // izvrsava se query nad bazom

                foreach (DataRow row in ds.Tables["Salon"].Rows)
                {
                    var s = new Salon();
                    
                    s.ID = (int)row["ID"];
                    s.Naziv = (string)row["Naziv"];
                    s.Adresa = (string)row["Adresa"];
                    s.Telefon = (int)row["Telefon"];
                    s.Email = (string)row["Email"];
                    s.AdresaSajta = (string)row["AdresaSajta"];
                    s.PIB = (int)row["PIB"];
                    s.MaticniBroj = (int)row["MaticniBroj"];
                    s.BrZiroRacuna = (string)row["BrZiroRacuna"];
                    s.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    salon.Add(s);
                }
            }
            return salon;
        }

        public static Salon Create(Salon s)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                DataSet ds = new DataSet();

                cmd.CommandText = "INSERT INTO Salon (ID, Naziv, Adresa, Telefon, Email, AdresaSajta, PIB, MaticniBroj, BrZiroRacuna, Obrisan) VALUES (@ID, @Naziv, @Adresa, @Telefon, @Email, @AdresaSajta, @PIB, @MaticniBroj, @BrZiroRacuna, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("ID", s.ID);
                cmd.Parameters.AddWithValue("Naziv", s.Naziv);
                cmd.Parameters.AddWithValue("Adresa", s.Adresa);
                cmd.Parameters.AddWithValue("Telefon", s.Telefon);
                cmd.Parameters.AddWithValue("Email", s.Email);
                cmd.Parameters.AddWithValue("AdresaSajta", s.AdresaSajta);
                cmd.Parameters.AddWithValue("PIB", s.PIB);
                cmd.Parameters.AddWithValue("MaticniBroj", s.MaticniBroj);
                cmd.Parameters.AddWithValue("BrZiroRacuna", s.BrZiroRacuna);
                cmd.Parameters.AddWithValue("Obrisan", s.Obrisan);

                //tn.Id = int.Parse(cmd.ExecuteScalar().ToString()); //executeScalar izvrsava upit

                int newId = int.Parse(cmd.ExecuteScalar().ToString());  // ExecuteScalar izvrsava query
                s.id = newId;
            }

            Projekat.Instace.salon.Add(s);
            return s;
        }

        public static void Update(Salon s)
        {
            //azuriranje baze
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {

                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE Salon SET Naziv=@Naziv, Adresa=@Adresa, Telefon=@Telefon, Email=@Email, AdresaSajta=@AdresaSajta, PIB=@PIB, MaticniBroj=@MaticniBroj, BrZiroRacuna=@BrZiroRacuna, Obrisan=@Obrisan WHERE ID=@ID";

                cmd.Parameters.AddWithValue("ID", s.ID);
                cmd.Parameters.AddWithValue("Naziv", s.Naziv);
                cmd.Parameters.AddWithValue("Adresa", s.Adresa);
                cmd.Parameters.AddWithValue("Telefon", s.Telefon);
                cmd.Parameters.AddWithValue("Email", s.Email);
                cmd.Parameters.AddWithValue("AdresaSajta", s.AdresaSajta);
                cmd.Parameters.AddWithValue("PIB", s.PIB);
                cmd.Parameters.AddWithValue("MaticniBroj", s.MaticniBroj);
                cmd.Parameters.AddWithValue("BrZiroRacuna", s.BrZiroRacuna);
                cmd.Parameters.AddWithValue("Obrisan", s.Obrisan);

                cmd.ExecuteNonQuery();

            }

            // azuriranje modela
            foreach (var salon in Projekat.Instace.salon)
            {
                if (s.ID == salon.ID)
                {
                    salon.ID = s.ID;
                    salon.Naziv = s.Naziv;
                    salon.Adresa = s.Adresa;
                    salon.Telefon = s.Telefon;
                    salon.Email = s.Email;
                    salon.AdresaSajta = s.AdresaSajta;
                    salon.PIB = s.PIB;
                    salon.MaticniBroj = s.MaticniBroj;
                    salon.BrZiroRacuna = s.BrZiroRacuna;
                    salon.Obrisan = s.Obrisan;
                    break;
                }
            }

        }

        public static void Delete(Salon tn)
        {
            tn.Obrisan = true;
            Update(tn);
        }

        #endregion


    }



}
