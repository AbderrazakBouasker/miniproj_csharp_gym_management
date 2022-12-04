using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.dao
{
    internal class Musicdao
    {
        public Musicdao()
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
        public void addmusic(string title, string link)
        {
            try
            {
                string query = "insert into music (title,link) values ('" + title + "','" + link + "')";
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
        public DataTable fillmusictab()
        {
            try
            {
                string query = "select * from music";
                SqlCommand sqlCommand = new SqlCommand(query, Dbconnect.con);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                Dbconnect.con.Close();
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Dbconnect.con.Close();
                throw;
            }
        }
        public void deletemusic(string ids)
        {
            try
            {
                string query = "delete from music where id in (" + ids + ")";
                SqlCommand cmd = new SqlCommand(query, Dbconnect.con);
                cmd.ExecuteNonQuery();
                Dbconnect.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Dbconnect.con.Close();
                throw;
            }
        }
        public void editmusic(string id, string title, string link)
        {
            try
            {
                String query = "UPDATE music SET title = '" + title + "', link ='" + link + " ' WHERE id =" + id;
                Console.WriteLine(query);
                SqlCommand sqlCommand = new SqlCommand(query, Dbconnect.con);
                sqlCommand.ExecuteNonQuery();
                Dbconnect.con.Close();
            }
            catch (Exception ex)
            {
                Dbconnect.con.Close();
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
