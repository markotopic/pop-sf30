using SF_30_2016.Modeli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SF_30_2016.Model
{
    public class TipNamestaja : INotifyPropertyChanged
    {
        private int id;
        private string naziv;
        private bool obrisan;

        //private int tipNamestajaId;
        //public int TipNamestajaId
        //{
        //    get { return tipNamestajaId; }
        //    set { tipNamestajaId = value; OnPropertyChanged("TipNamestajaId"); }
        //}

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


        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static TipNamestaja GetById(int id)
        {
            foreach (var tipNamestaja in Projekat.Instace.tipnamestaja)
            {
                if (tipNamestaja.Id == id)
                {
                    return tipNamestaja;
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

        public override string ToString()
        {
            return $"{Naziv}";
        }

        #region CRUD
        public static TipNamestaja Create(TipNamestaja tn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {

                SqlCommand cmd = con.CreateCommand();
                DataSet ds = new DataSet();

                cmd.CommandText = "INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES (@Naziv, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY";
                cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                tn.Id = int.Parse(cmd.ExecuteScalar().ToString()); //executeScalar izvrsava upit

            }
            Projekat.Instace.tipnamestaja.Add(tn);
            return tn;
        }

        public static void Update(TipNamestaja tn)
        {
            //azuriranje baze
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {

                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE TipNamestaja SET Naziv=@Naziv, Obrisan=@Obrisan WHERE Id=@Id";
                cmd.CommandText += "SELECT SCOPE_IDENTITY";

                cmd.Parameters.AddWithValue("Id", tn.Id);
                cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                cmd.ExecuteNonQuery();

            }

            // azuriranje modela
            foreach (var tipNamestaja in Projekat.Instace.tipnamestaja)
            {
                if (tn.Id == tipNamestaja.Id)
                {
                    tipNamestaja.Naziv = tn.Naziv;
                    tipNamestaja.Obrisan = tn.Obrisan;
                }
            }

        }

        public static void Delete(TipNamestaja tn)
        {
            tn.Obrisan = true;
            Update(tn);
        }

        #endregion
    }

}
