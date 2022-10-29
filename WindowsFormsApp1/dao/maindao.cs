using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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

        public void addmember(string idnumber,string name,string lastname,string companyname,string paymentreduction,string startdate,string enddate)
        {
            try
            {
                string query = "insert into members (idnumber,name,lastname,companyname,paymentreduction,startdate,enddate) values (" + idnumber + ",'" + name + "','" + lastname + "','" + companyname + "', " + paymentreduction + " ,'" + startdate + "','" + enddate + "')";
                Console.WriteLine(query);
                SqlCommand sqlCommand = new SqlCommand(query, Dbconnect.con);
                sqlCommand.ExecuteNonQuery();
                Dbconnect.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Dbconnect.con.Close();
            }
        }
    }
}
