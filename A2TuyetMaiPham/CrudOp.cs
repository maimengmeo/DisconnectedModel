using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2TuyetMaiPham
{
    public class CrudOp
    {
        private SqlConnection conn;
        private SqlDataAdapter adp;
        private SqlCommandBuilder cmdBuilder;
        private DataSet ds;
        private DataTable tbl;

        public CrudOp()
        {
            string query = "Select * from Continent";
            conn = new SqlConnection(Data.ConnectionString);

            adp = new SqlDataAdapter(query, conn);
            cmdBuilder = new SqlCommandBuilder(adp);

            FillDataSet();
        }

        private void FillDataSet()
        {
            ds = new DataSet();

            adp.Fill(ds, "Continent");
            tbl = ds.Tables[0];

            DataColumn[] pk = new DataColumn[1];
            pk[0] = tbl.Columns["ContinentId"];
            pk[0].AutoIncrement = true;

            tbl.PrimaryKey = pk;
        }

        public DataTable GetContinents()
        {
            FillDataSet();
            return tbl;
        }
    }
}
