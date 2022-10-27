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
    internal class Logindao
    {
        public Logindao()
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
        public bool login( string username , string password)
        {
            string query= "Select * FROM logininfo WHERE username='" + username+"' and password='"+password+"'";
            SqlDataAdapter reader = new SqlDataAdapter(query, Dbconnect.con);
            DataTable dataTable = new DataTable();
            reader.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                Dbconnect.con.Close();
                return true;
            }
            else
            {
                Dbconnect.con.Close();
                return false;
            }

        }

        public bool checkuserexist()
        {
            string query = "Select * FROM logininfo ";
            SqlDataAdapter reader = new SqlDataAdapter(query, Dbconnect.con);
            DataTable dataTable = new DataTable();
            reader.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                Dbconnect.con.Close();
                return true;
            }
            else
            {
                Dbconnect.con.Close();
                return false;
            }

        }

    }
}
