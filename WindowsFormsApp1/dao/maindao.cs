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
            string query="select count(id) as 'num' from members";
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

        public string getavgincome(int cost) 
        {
            DateTime localDate = DateTime.Now;
            DateTime enddate;
            int income = 0;
            int compareday = 0;
            int comparemonth = 0;
            int compareyear = 0;
            string query = "select enddate from members";
            SqlCommand sqlCommand =new SqlCommand(query,Dbconnect.con);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                string tempdate= dataRow["enddate"].ToString();
                enddate=DateTime.Parse(tempdate);
                compareyear=enddate.Year.CompareTo(localDate.Year);
                comparemonth=enddate.Month.CompareTo(localDate.Month);
                compareday=enddate.Day.CompareTo(localDate.Day);
                if (compareyear > 0)
                {
                    income += cost;
                }else if (compareyear == 0)
                {
                    if (comparemonth>0)
                    {
                        income += cost;
                    }
                    else if (comparemonth==0)
                    {
                        if (compareday > 0)
                        {
                            income += cost;
                        }
                    }
                }
            }
            Dbconnect.con.Close();
            return income.ToString();
            
        }

        public void addmember(string idnumber,string name,string lastname,string companyname,string paymentreduction,string startdate,string enddate)
        {
            try
            {
                string query = "insert into members (idnumber,name,lastname,companyname,paymentreduction,startdate,enddate) values (" + idnumber + ",'" + name + "','" + lastname + "','" + companyname + "', " + paymentreduction + " ,'" + startdate + "','" + enddate + "')";
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

        public DataTable maintable(int daysdiff)
        {
            try
            {
                string tempstartdate;
                string tempenddate;
                DateTime startdate;
                DateTime enddate;
                string query = "select name,lastname,startdate,enddate from members";
                SqlCommand sqlCommand1 = new SqlCommand(query, Dbconnect.con);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand1);
                DataTable dataTable = new DataTable();
                DataTable dataTable2 = new DataTable();
                dataTable2.Columns.Add("name", typeof(string));
                dataTable2.Columns.Add("lastname",typeof(string));
                dataTable2.Columns.Add("expirationdate", typeof(DateTime));
                adapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    tempstartdate = row["startdate"].ToString();
                    tempenddate = row["enddate"].ToString();
                    startdate = DateTime.Parse(tempstartdate);
                    enddate = DateTime.Parse(tempenddate);
                    if ((enddate-startdate).TotalDays <= daysdiff)
                    {
                        dataTable2.Rows.Add(row["name"], row["lastname"], row["enddate"]);
                    }
                }
                Dbconnect.con.Close();
                return dataTable2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Dbconnect.con.Close();
                throw;
            }
            
        }

        public DataTable fillmembertab()
        {
            try
            {
                string query = "select * from members";
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
        public DataTable fillmembertabbyname(string name)
        {
            try
            {
                string query = "select * from members where name like '"+name+""+"%"+"'";
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
        public void deletemember(string ids)
        {
            try
            {
                string query = "delete from members where id in (" + ids + ")";
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
        public void editmember(string id,string idnumber,string name,string lastname,string company,string reduction,string startdate,string enddate)
        {
            try
            {
                String query = "UPDATE members SET idnumber = " + idnumber + ", name ='" + name + "' , lastname ='" + lastname + "', companyname ='" + company + "', paymentreduction =" + reduction + ", startdate ='" + startdate + "', enddate = '" + enddate + "' WHERE id =" + id;
                SqlCommand sqlCommand = new SqlCommand(query, Dbconnect.con);
                sqlCommand.ExecuteNonQuery();
                Dbconnect.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Dbconnect.con.Close();
                throw;
            }
        }

    }
}
