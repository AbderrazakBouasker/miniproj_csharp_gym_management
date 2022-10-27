using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.dao
{
    internal class Maindao
    {
        public Maindao()
        {
            try
            {
                Dbconnect.con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Dbconnect.con.Close();
                return;

            }
        }

        public string getmemcount()
        {
            string count = "";
            string query="select count(*) as 'num' from members";
            SqlCommand sqlCommand = new SqlCommand(query,Dbconnect.con);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                count = dataRow["num"].ToString();
            }
            Dbconnect.con.Close();
            return count;
        }

        /*public string getavgincome()
        {

        }*/

    }
}
