using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace A2TuyetMaiPham
{
    public class Data
    {
        private static string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                         Initial Catalog=WorldDB;
                                         Integrated Security=True";
        public static string ConnectionString { get => connStr; }

        public DataTable GetContinents()
        {
            string query = "Select ContinentId, ContinentName from Continent";

            SqlConnection conn = new SqlConnection(Data.ConnectionString);

            SqlDataAdapter adp = new SqlDataAdapter(query, conn);

            DataSet ds = new DataSet();

            adp.Fill(ds, "Continent");

            DataTable tblContinents = ds.Tables["Continent"];

            return tblContinents;

        }

        public DataTable GetCountry()
        {
            string query = "Select * from City";
            SqlConnection conn = new SqlConnection(Data.ConnectionString);
            SqlDataAdapter adp = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds, "Country");
            DataTable tblCountry = ds.Tables["Country"];
            return tblCountry;
        }

        public DataTable GetCity()
        {
            string query = "select * from City";
            SqlConnection conn = new SqlConnection(Data.ConnectionString);
            SqlDataAdapter adp = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds, "City");
            DataTable tblCity = ds.Tables["City"];
            return tblCity;
        }
    }

    
}
