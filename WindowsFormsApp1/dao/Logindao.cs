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
            Dbconnect dcon= new Dbconnect();
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

        public bool checkuserexist(string username,string qmovie,string qmusic)
        {
            string query = "Select * FROM logininfo where username='"+username+"' and qmovie='"+qmovie+"' and qmusic='"+qmusic+"'";
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

        public void creatuser(string username,string password,string qmovie,string qmusic)
        {
            string query = "INSERT INTO logininfo (username, password, qmovie, qmusic) VALUES ('"+username+"','"+password+"','"+qmovie+"','"+qmusic+"')";
            SqlCommand sqlCommand = new SqlCommand(query,Dbconnect.con);
            sqlCommand.ExecuteNonQuery();
            Dbconnect.con.Close();
        }

        public string getpassword(string username,string qmovie,string qmusic)
        {
            string password="";
            string query= "select password from logininfo where username='" + username + "' and qmovie='" + qmovie + "' and qmusic='" + qmusic + "'";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, Dbconnect.con);
            DataTable dataTable =new DataTable();
            dataAdapter.Fill(dataTable);
            foreach (DataRow datarow in dataTable.Rows)
            {
                password = datarow["password"].ToString();
            }
            Dbconnect.con.Close();
            return password;
        }

    }
}
