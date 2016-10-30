using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

//
// SqlHandler - A class responsible for all communication with the SqlServer
//


namespace Common
{
    public class SqlHandler
    {
        // The connection to the table
        private SqlConnection connection;

        // The connection terms
        private string serverIp, table, username, password;



        public SqlHandler(string ip, string user, string pass, string dataTable)
        {
            serverIp = ip;
            username = user;
            password = pass;
            table = dataTable;
        }



        // Initialize the connection
        public void Connect()
        {
            string connectString = "server=" + serverIp + ";table=" + table + ";User Id=" + username + ";Password=" + password;
            connection = new SqlConnection(connectString);
            connection.Open();
        }


        private string c(string x) => "'" + x + "',";
        private string cf(string x) => "'" + x + "'";
        // Add an item into the table
        public void AddRow(params string[] strings)
        {
            string data = "";

            // Load all of the data from the parameters
            for (int i = 0; i < strings.Length; ++i)
            {
                if (i != strings.Length - 1)
                    data += c(strings[i]);
                else
                    data += cf(strings[i]);
            }

            // Add a new row
            SqlCommand addCommand = new SqlCommand("INSERT INTO " + table + " VALUES (" + data + ")", connection);
            addCommand.ExecuteNonQuery();
        }
    }
}
