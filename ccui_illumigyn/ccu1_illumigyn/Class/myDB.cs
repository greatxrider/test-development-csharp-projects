using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ccu1_illumigyn.Class.class_globals;

namespace ccu1_illumigyn.Class
{
    public class myDB
    {
        private string sqlConnectionString;
        private static SqlConnection _sqlConnection;
        private static SqlCommand _sqlCommand;
        private static SqlDataReader sqlDataReader;
        public static string query { get; set; }

        public myDB(string connectionString, string password)
        {
            try
            {
                sqlConnectionString = connectionString + password + ";";
                _sqlConnection = new SqlConnection(sqlConnectionString);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        public byte[] ExtractTestLog(string tableName, string recordID)
        {
            byte[] log_file = null;
            try
            {
                //  SqlDataReader mySqlReader;
                string sqlQuery = "SELECT LOG_FILE FROM " + tableName + " WHERE ID = @id";
                _sqlConnection.Open();
                _sqlCommand = new SqlCommand(sqlQuery, _sqlConnection);
                _sqlCommand.Parameters.Add(new SqlParameter("@id", (recordID)));
                sqlDataReader = _sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    log_file = (byte[])sqlDataReader["LOG_FILE"];
                }
                return log_file;
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("The connection was not closed. "))
                    MessageBox.Show("The connection was not closed.");
                else if (!ex.ToString().Contains("Unable to cast object of type 'System.DBNull' to type 'System.Byte[]"))
                {
                    MessageBox.Show("Error Occurred In Searching Device History, Check Error Logs For More Information", "Error");
                }
            }

            finally
            {
                _sqlConnection.Close();
            }

            return log_file;
        }
    }
}
