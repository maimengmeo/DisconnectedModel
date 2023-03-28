using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2TuyetMaiPham
{
    class CrudOpCountries
    {
        private SqlConnection conn;
        private SqlDataAdapter adp;
        private SqlCommandBuilder cmdBuilder;
        private DataSet ds;
        private DataTable tbl;

        public CrudOpCountries()
        {
            string query = "Select * from Country";
            conn = new SqlConnection(Data.ConnectionString);
            adp = new SqlDataAdapter(query, conn);

            cmdBuilder = new SqlCommandBuilder(adp);

            FillCountryDataSet();
        }

        private void FillCountryDataSet()
        {
            ds = new DataSet();
            adp.Fill(ds, "Country");
            tbl = ds.Tables[0];

            DataColumn[] pk = new DataColumn[1];
            pk[0] = tbl.Columns["CountryId"];
            pk[0].AutoIncrement = true;
            tbl.PrimaryKey = pk;
        }

        public DataRow[] GetCountries(int continentId)
        {
            FillCountryDataSet();
            DataRow[] countries = tbl.Select("ContinentId = " + continentId);
            return countries;

        }

    }
}
