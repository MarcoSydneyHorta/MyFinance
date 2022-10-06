using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace MyFinance.Util
{
    public class Dal
    {
        private static string server = "localhost";
        private static string database = "financeiro";
        private static string user  = "root";
        private static string password = "";
        private string connectionString = $"Server={server};Database{database};Uid={user};Pwd={password}";
        private MySqlConnection connection;

        public Dal()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        public DataTable RetDataTable(string sql)  // Execute SELECT
        {
            DataTable dataTable = new DataTable();
            MySqlCommand command = new MySqlCommand(sql, connection);  // Prepare the SQL command
            MySqlDataAdapter da = new MySqlDataAdapter(command);  // The MySqlDataAdapter, serves as a bridge between a DataSet and MySQL Server for retrieving and saving data
            da.Fill(dataTable);  // Fill with SQL result in dataTable object
            return dataTable;
        } 

        public void ExecutarComandoSQL(string sql)  // Execute INSERT, DELETE, UPDATE
        {
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }
}
