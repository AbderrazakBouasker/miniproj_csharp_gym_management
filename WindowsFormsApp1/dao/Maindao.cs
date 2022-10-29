﻿using System;
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

        public string getavgincome() 
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
                    income += 60;
                }else if (compareyear == 0)
                {
                    if (comparemonth>0)
                    {
                        income += 60;
                    }
                    else if (comparemonth==0)
                    {
                        if (compareday > 0)
                        {
                            income += 60;
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

        public DataTable maintable()
        {
            try
            {
                string query = "select name,lastname from members";
                SqlCommand sqlCommand1 = new SqlCommand(query, Dbconnect.con);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand1);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                Dbconnect.con.Close();
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Dbconnect.con.Close();
                return null;
            }
            
        }

    }
}