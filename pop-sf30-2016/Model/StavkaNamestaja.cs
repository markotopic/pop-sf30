using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pop_sf30_2016.Model
{
    public class StavkaNamestaja
    {
        public int NamestajId { get; set; }
        public int RacunId { get; set; }
        public int Kolicina { get; set; }


        #region CRUD

        public static StavkaNamestaja Create(StavkaNamestaja tn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                DataSet ds = new DataSet();

                cmd.CommandText = "INSERT INTO Stavka (NamestajId, RacunId, Kolicina) VALUES (@NamestajId, @RacunId, @Kolicina);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("NamestajId", tn.NamestajId);
                cmd.Parameters.AddWithValue("RacunId", tn.RacunId);
                cmd.Parameters.AddWithValue("Kolicina", tn.Kolicina);

                cmd.ExecuteNonQuery();

                //int newId = int.Parse(cmd.ExecuteScalar().ToString());  // ExecuteScalar izvrsava query
                //tn.Id = newId;
            }

            //Projekat.Instace.prodajanamestaja.Add(tn);
            return tn;
        }

        #endregion

    }
}
