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
using System.Data.Linq.Mapping;
using System.Data.Linq;
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

        // The database
        private DataContext database;

        // The connection terms
        private string serverIp, table, username, password;



        public SqlHandler(string ip, string user, string pass, string dataTable)
        {
            serverIp = ip;
            username = user;
            password = pass;
            table = dataTable;

            string connectString = "server=" + serverIp + ";table=" + table + ";User Id=" + username + ";Password=" + password;
            database = new DataContext(connectString);
        }



        // Initialize the connection
        public void Connect()
        {
            string connectString = "server=" + serverIp + ";table=" + table + ";User Id=" + username + ";Password=" + password;
            connection = new SqlConnection(connectString);
            connection.Open();
        }



        public void AddRow(params SqlPair[] data)
        {
            string values = "";

            // Load all of the data from the parameters
            for (int i = 0; i < data.Length; ++i)
            {
                values += "'" + data[i].Value + "'";

                if (i != data.Length - 1)
                    values += ",";
            }

            // Add a new row
            SqlCommand addCommand = new SqlCommand("INSERT INTO " + table + " VALUES (" + values + ");", connection);
            addCommand.ExecuteNonQuery();
        }



        // Delete an item from the table, given the following values
        public void DeleteRow(params SqlPair[] data)
        {
            string queryLocation = "";

            for (int i = 0; i < data.Length; ++i)
            {
                queryLocation += data[i].Column + " = '" + data[i].Value + "'";

                if (i != data.Length - 1)
                    queryLocation += " AND ";
            }

            // Remove the row
            SqlCommand removeCommand = new SqlCommand("DELETE FROM " + table + " WHERE " + queryLocation + ";", connection);
        }
    }
}
