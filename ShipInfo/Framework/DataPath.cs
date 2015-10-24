using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ShipInfo.Framework
{    class DataPath
    {
    private string dbconnection = "Data Source=SQL-PC\\SQLEXPRESS;Initial Catalog=dbapptest;Persist Security Info=True;User ID=admin;Password=admin;";
   
        public void post(SqlCommand command)
        {
            SqlConnection connection=new SqlConnection(dbconnection);
            command.Connection = connection;
            connection.Open();
             command.ExecuteNonQuery();
            connection.Close();

            


        }
        public DataTable Query( string Q)
        {
            SqlConnection connection = new SqlConnection(dbconnection);
            SqlDataAdapter da = new SqlDataAdapter(Q, connection);
            DataTable dt = new DataTable();
            connection.Open();
            da.Fill(dt);
            connection.Close();
            return dt;

        }


    }
}
