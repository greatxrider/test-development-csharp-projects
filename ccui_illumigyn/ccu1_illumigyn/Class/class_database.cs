using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ccu1_illumigyn.Class.class_globals;

namespace ccu1_illumigyn.Class
{
    public class class_database
    {
        private string connection_string;
        private static SqlConnection sql_connection;
        private static SqlCommand sql_command;
        private static SqlDataReader sql_datareader;
        public static string V;
        public string query;

        public class_database(string serverName, string databaseName, string username, string password)
        {
            try
            {
                connection_string = $"Data Source = {serverName}; Database = {databaseName}; user id = {username}; password = {password};";
                sql_connection = new SqlConnection(connection_string);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task<bool> checkDatabaseConnection()
        {
            try
            {
                await sql_connection.OpenAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                sql_connection.Close();
            }
        }

        public async Task<int> getTestCount(string table_name, string dateStart, string dateEnd, string result1, string result2)
        {
            int testCount = 0;
            try
            {
                string query = "SELECT COUNT(*)  FROM " + table_name + " WHERE TEST_START >= @dateStart AND TEST_END <= @dateEnd AND (OVERALL = @result1 OR OVERALL = @result2)";
                await sql_connection.OpenAsync();
                sql_command = new SqlCommand(query, sql_connection);
                sql_command.Parameters.Add(new SqlParameter("@dateStart", dateStart));
                sql_command.Parameters.Add(new SqlParameter("@dateEnd", dateEnd));
                sql_command.Parameters.Add(new SqlParameter("@result1", result1));
                sql_command.Parameters.Add(new SqlParameter("@result2", result2));
                sql_datareader = sql_command.ExecuteReader();
                while (sql_datareader.Read())
                {
                    testCount = sql_datareader.GetInt32(0);
                }
                return testCount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return testCount;
            }
            finally
            {
                sql_connection.Close();
            }
        }

        public async Task<int> countAllperResult(string table_name, string result1)
        {
            int testCount = 0;
            try
            {
                string query = $"SELECT COUNT(*) FROM {table_name} WHERE OVERALL = @result1";
                await sql_connection.OpenAsync();
                sql_command = new SqlCommand(query, sql_connection);
                sql_command.Parameters.Add(new SqlParameter("@result1", result1));
                sql_datareader = sql_command.ExecuteReader();
                while (sql_datareader.Read())
                {
                    testCount = sql_datareader.GetInt32(0);
                }
                return testCount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return testCount;
            }
            finally
            {
                sql_connection.Close();
            }
        }
       
        public async Task<bool> InsertTestResults(string table_name, string test_start, string test_end, string OS_D1_PIN_1, string OS_R39_PIN_1, string OS_R43_PIN_1, string OS_R42_PIN_1, 
            string OS_U10_PIN_5, string OS_U11_PIN_5, string OS_U12_PIN_5, string OS_U13_PIN_5, string OS_U5_PIN_5, string OS_U6_PIN_5,
            string OS_U7_PIN_5, string OS_U8_PIN_5, string TEST_PC_NAME, string TEST_STATION, string PCB_SERIAL_NUMBER, string SERIAL_NUMBER, string PART_NUMBER, string UNIT_TYPE,
            string OPERATOR_NAME, string JIG_NUMBER, string ERROR_CODE, string REMARKS, string OVERALL)
        {
            try
            {

                string query = $"INSERT INTO " + table_name + " (test_start, test_end, OS_D1_PIN_1, OS_R39_PIN_1," +
                    $"OS_R43_PIN_1, OS_R42_PIN_1, OS_U10_PIN_5, " +
                    $"OS_U11_PIN_5, OS_U12_PIN_5, OS_U13_PIN_5, OS_U5_PIN_5, OS_U6_PIN_5, " +
                    $"OS_U7_PIN_5, OS_U8_PIN_5, TEST_PC_NAME, TEST_STATION, " +
                    $"PCB_SERIAL_NUMBER, SERIAL_NUMBER, PART_NUMBER, UNIT_TYPE, OPERATOR_NAME, " +
                    $"JIG_NUMBER, ERROR_CODE, REMARKS, OVERALL) VALUES (@test_start, @test_end, @OS_D1_PIN_1, @OS_R39_PIN_1, @OS_R43_PIN_1, @OS_R42_PIN_1, @OS_U10_PIN_5, @OS_U11_PIN_5," +
                    $"@OS_U12_PIN_5, @OS_U13_PIN_5, @OS_U5_PIN_5, @OS_U6_PIN_5, @OS_U7_PIN_5, @OS_U8_PIN_5, @TEST_PC_NAME, @TEST_STATION, @PCB_SERIAL_NUMBER, " +
                    $"@SERIAL_NUMBER, @PART_NUMBER, @UNIT_TYPE, @OPERATOR_NAME," +
                    $"@JIG_NUMBER, @ERROR_CODE, @REMARKS, @OVERALL);";

                await sql_connection.OpenAsync();
                sql_command = new SqlCommand(query, sql_connection);
                sql_command.Parameters.Add(new SqlParameter("@test_start", test_start == null ? "EMPTY" : test_start));
                sql_command.Parameters.Add(new SqlParameter("@test_end", test_end == null ? "EMPTY" : test_end));
                sql_command.Parameters.Add(new SqlParameter("@OS_D1_PIN_1", OS_D1_PIN_1 == null ? "EMPTY" : OS_D1_PIN_1));
                sql_command.Parameters.Add(new SqlParameter("@OS_R39_PIN_1", OS_R39_PIN_1 == null ? "EMPTY" : OS_R39_PIN_1));
                sql_command.Parameters.Add(new SqlParameter("@OS_R43_PIN_1", OS_R43_PIN_1 == null ? "EMPTY" : OS_R43_PIN_1 ));
                sql_command.Parameters.Add(new SqlParameter("@OS_R42_PIN_1", OS_R42_PIN_1 == null ? "EMPTY" : OS_R42_PIN_1));
                sql_command.Parameters.Add(new SqlParameter("@OS_U10_PIN_5", OS_U10_PIN_5 == null ? "EMPTY" : OS_U10_PIN_5));
                sql_command.Parameters.Add(new SqlParameter("@OS_U11_PIN_5", OS_U11_PIN_5 == null ? "EMPTY" : OS_U11_PIN_5));
                sql_command.Parameters.Add(new SqlParameter("@OS_U12_PIN_5", OS_U12_PIN_5 == null ? "EMPTY" : OS_U12_PIN_5));
                sql_command.Parameters.Add(new SqlParameter("@OS_U13_PIN_5", OS_U13_PIN_5 == null ? "EMPTY" : OS_U13_PIN_5));
                sql_command.Parameters.Add(new SqlParameter("@OS_U5_PIN_5", OS_U5_PIN_5 == null ? "EMPTY" : OS_U5_PIN_5));
                sql_command.Parameters.Add(new SqlParameter("@OS_U6_PIN_5", OS_U6_PIN_5 == null ? "EMPTY" : OS_U6_PIN_5));
                sql_command.Parameters.Add(new SqlParameter("@OS_U7_PIN_5", OS_U7_PIN_5 == null ? "EMPTY" : OS_U7_PIN_5));
                sql_command.Parameters.Add(new SqlParameter("@OS_U8_PIN_5", OS_U8_PIN_5 == null ? "EMPTY" : OS_U8_PIN_5));
                sql_command.Parameters.Add(new SqlParameter("@TEST_PC_NAME", TEST_PC_NAME == null ? "EMPTY" : TEST_PC_NAME));
                sql_command.Parameters.Add(new SqlParameter("@TEST_STATION", TEST_STATION == null ? "EMPTY" : TEST_STATION));
                sql_command.Parameters.Add(new SqlParameter("@PCB_SERIAL_NUMBER", PCB_SERIAL_NUMBER == null ? "EMPTY" : PCB_SERIAL_NUMBER));
                sql_command.Parameters.Add(new SqlParameter("@SERIAL_NUMBER", SERIAL_NUMBER == null ? "EMPTY" : SERIAL_NUMBER));
                sql_command.Parameters.Add(new SqlParameter("@PART_NUMBER", PART_NUMBER == null ? "EMPTY" : PART_NUMBER));
                sql_command.Parameters.Add(new SqlParameter("@UNIT_TYPE", UNIT_TYPE == null ? "EMPTY" : UNIT_TYPE));
                sql_command.Parameters.Add(new SqlParameter("@OPERATOR_NAME", OPERATOR_NAME == null ? "EMPTY" : OPERATOR_NAME));
                sql_command.Parameters.Add(new SqlParameter("@JIG_NUMBER", JIG_NUMBER == null ? "EMPTY" : JIG_NUMBER ));
                sql_command.Parameters.Add(new SqlParameter("@ERROR_CODE", ERROR_CODE == null ? "EMPTY" : ERROR_CODE));
                sql_command.Parameters.Add(new SqlParameter("@REMARKS", REMARKS == null ? "EMPTY" : REMARKS));
                sql_command.Parameters.Add(new SqlParameter("@OVERALL", OVERALL == null ? "EMPTY" : OVERALL));             
                await sql_command.ExecuteNonQueryAsync();
                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            finally
            {
                sql_connection.Close();
            }
        }

        public async Task<bool> UpdateLogFile(string tableName, byte[] logfile, string testStart)
        {
            try
            {
                string query = "UPDATE " + tableName + " SET LOG_FILE = @logFile WHERE TEST_START = @testStart";
                await sql_connection.OpenAsync();
                sql_command = new SqlCommand(query, sql_connection);
                sql_command.Parameters.Add(new SqlParameter("@testStart", testStart));
                sql_command.Parameters.Add(new SqlParameter("@logFile", logfile));
                await sql_command.ExecuteNonQueryAsync();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                sql_connection.Close();
            }
        }

        public async Task<bool> SearchDeviceHistory_Single(string table_name, string dateStart, string dateEnd, string overall_passed, string overall_failed, string overall_aborted, string serial_number)
        {
            V = "";

            while (Form_devicehistory.instance.serialnumb_details.Text == V || Form_devicehistory.instance.serialnumb_details.Text != V)
            {
                if (Form_devicehistory.instance.serialnumb_details.Text == V)
                {
                    if (Form_devicehistory.instance.passed.Checked)
                    {
                        query = $"SELECT * FROM {table_name} WHERE TEST_START >= @dateStart AND TEST_END <= @dateEnd  AND (OVERALL = @overall_passed OR OVERALL = '') AND (SERIAL_NUMBER != @serial_number)";
                        break;
                    }

                    else if (Form_devicehistory.instance.failed.Checked)
                    {
                        query = $"SELECT * FROM {table_name} WHERE TEST_START >= @dateStart AND TEST_END <= @dateEnd  AND (OVERALL = '' OR OVERALL = @overall_failed) AND (SERIAL_NUMBER != @serial_number)";
                        break;
                    }

                    else
                    {
                        if (Form_devicehistory.instance.both.Checked)
                        {
                            query = $"SELECT * FROM {table_name} WHERE TEST_START >= @dateStart AND TEST_END <= @dateEnd AND (OVERALL = @overall_passed OR OVERALL = @overall_failed OR OVERALL = @overall_aborted) AND (SERIAL_NUMBER != @serial_number)";
                            break;
                        }

                        else if (Form_devicehistory.instance.aborted.Checked)
                        {
                            query = $"SELECT * FROM {table_name} WHERE TEST_START >= @dateStart AND TEST_END <= @dateEnd AND (OVERALL = '' OR OVERALL = @overall_aborted) AND (SERIAL_NUMBER != @serial_number)";
                            break;
                        }
                    }        
                }

                else if (Form_devicehistory.instance.serialnumb_details.Text != V)
                {
                    if (Form_devicehistory.instance.passed.Checked)
                    {
                        query = $"SELECT * FROM {table_name} WHERE TEST_START >= @dateStart AND TEST_END <= @dateEnd  AND (OVERALL = @overall_passed OR OVERALL = '') AND (SERIAL_NUMBER = @serial_number)";
                        break;
                    }

                    else if (Form_devicehistory.instance.failed.Checked)
                    {
                        query = $"SELECT * FROM {table_name} WHERE TEST_START >= @dateStart AND TEST_END <= @dateEnd  AND (OVERALL = '' OR OVERALL = @overall_failed) AND (SERIAL_NUMBER = @serial_number)";
                        break;
                    }

                    else
                    {
                        if (Form_devicehistory.instance.both.Checked)
                        {
                            query = $"SELECT * FROM {table_name} WHERE TEST_START >= @dateStart AND TEST_END <= @dateEnd  AND (OVERALL = @overall_passed OR OVERALL = @overall_failed OR OVERALL = @overall_aborted) AND (SERIAL_NUMBER = @serial_number)";
                            break;
                        }

                        else if (Form_devicehistory.instance.aborted.Checked)
                        {
                            query = $"SELECT * FROM {table_name} WHERE TEST_START >= @dateStart AND TEST_END <= @dateEnd AND (OVERALL = '' OR OVERALL = @overall_aborted) AND (SERIAL_NUMBER = @serial_number)";
                            break;
                        }
                    }
                }
            }

            try
            {
                await sql_connection.OpenAsync();
                sql_command = new SqlCommand(query, sql_connection);
                sql_command.Parameters.Add(new SqlParameter("@dateStart", dateStart));
                sql_command.Parameters.Add(new SqlParameter("@dateEnd", dateEnd));
                sql_command.Parameters.Add(new SqlParameter("@overall_passed", overall_passed));
                sql_command.Parameters.Add(new SqlParameter("@overall_failed", overall_failed));
                sql_command.Parameters.Add(new SqlParameter("@overall_aborted", overall_aborted));
                sql_command.Parameters.Add(new SqlParameter("@serial_number", serial_number));
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sql_command);
                dataAdapter.Fill(dataTable);
                Form_devicehistory.instance.datagrid1.DataSource = dataTable;
                await sql_command.ExecuteNonQueryAsync();
                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            finally
            {
                sql_connection.Close();
            }
        }

        public async Task<bool> SearchDeviceHist_SummaryView(string table_name, string dateStart, string dateEnd, string overall_passed, string overall_failed, string overall_aborted, string serial_number)
        {
            V = "";

            while (Form_devicehistory.instance.serialnumb_details.Text == V || Form_devicehistory.instance.serialnumb_details.Text != V)
            {
                if (Form_devicehistory.instance.serialnumb_details.Text == V)
                {
                    if (Form_devicehistory.instance.passed.Checked)
                    {
                        query = $"SELECT TEST_START, TEST_END, SERIAL_NUMBER, OPERATOR_NAME, OVERALL FROM {table_name} WHERE TEST_START >= @dateStart AND TEST_END <= @dateEnd AND OPERATOR_NAME != '' AND (OVERALL = @overall_passed OR OVERALL = '') AND (SERIAL_NUMBER != @serial_number)";
                        break;
                    }

                    else if (Form_devicehistory.instance.failed.Checked)
                    {
                        query = $"SELECT TEST_START, TEST_END, SERIAL_NUMBER, OPERATOR_NAME, OVERALL FROM {table_name} WHERE TEST_START >= @dateStart AND TEST_END <= @dateEnd AND OPERATOR_NAME != '' AND (OVERALL = '' OR OVERALL = @overall_failed) AND (SERIAL_NUMBER != @serial_number)";
                        break;
                    }

                    else
                    {
                        if (Form_devicehistory.instance.both.Checked)
                        {
                            query = $"SELECT TEST_START, TEST_END, SERIAL_NUMBER, OPERATOR_NAME, OVERALL FROM {table_name} WHERE TEST_START >= @dateStart AND TEST_END <= @dateEnd AND OPERATOR_NAME != '' AND (OVERALL = @overall_passed OR OVERALL = @overall_failed OR OVERALL = @overall_aborted) AND (SERIAL_NUMBER != @serial_number)";
                            break;
                        }

                        else if (Form_devicehistory.instance.aborted.Checked)
                        {
                            query = $"SELECT TEST_START, TEST_END, SERIAL_NUMBER, OPERATOR_NAME, OVERALL FROM {table_name} WHERE TEST_START >= @dateStart AND TEST_END <= @dateEnd AND OPERATOR_NAME != '' AND (OVERALL = '' OR OVERALL = @overall_aborted) AND (SERIAL_NUMBER != @serial_number)";
                            break;
                        }
                    }
                }

                else if (Form_devicehistory.instance.serialnumb_details.Text != V)
                {
                    if (Form_devicehistory.instance.passed.Checked)
                    {
                        query = $"SELECT TEST_START, TEST_END, SERIAL_NUMBER, OPERATOR_NAME, OVERALL FROM {table_name} WHERE TEST_START >= @dateStart AND TEST_END <= @dateEnd AND OPERATOR_NAME != '' AND (OVERALL = @overall_passed OR OVERALL = '') AND (SERIAL_NUMBER = @serial_number)";
                        break;
                    }

                    else if (Form_devicehistory.instance.failed.Checked)
                    {
                        query = $"SELECT TEST_START, TEST_END, SERIAL_NUMBER, OPERATOR_NAME, OVERALL FROM {table_name} WHERE TEST_START >= @dateStart AND TEST_END <= @dateEnd AND OPERATOR_NAME != '' AND (OVERALL = '' OR OVERALL = @overall_failed) AND (SERIAL_NUMBER = @serial_number)";
                        break;
                    }

                    else
                    {
                        if (Form_devicehistory.instance.both.Checked)
                        {
                            query = $"SELECT TEST_START, TEST_END, SERIAL_NUMBER, OPERATOR_NAME, OVERALL FROM {table_name} WHERE TEST_START >= @dateStart AND TEST_END <= @dateEnd AND OPERATOR_NAME != '' AND (OVERALL = @overall_passed OR OVERALL = @overall_failed OR OVERALL = @overall_aborted) AND (SERIAL_NUMBER = @serial_number)";
                            break;
                        }

                        else if (Form_devicehistory.instance.aborted.Checked)
                        {
                            query = $"SELECT TEST_START, TEST_END, SERIAL_NUMBER, OPERATOR_NAME, OVERALL FROM {table_name} WHERE TEST_START >= @dateStart AND TEST_END <= @dateEnd AND OPERATOR_NAME != '' AND (OVERALL = '' OR OVERALL = @overall_aborted) AND (SERIAL_NUMBER = @serial_number)";
                            break;
                        }
                    }
                }
            }

            try
            {
                await sql_connection.OpenAsync();
                sql_command = new SqlCommand(query, sql_connection);
                sql_command.Parameters.Add(new SqlParameter("@dateStart", dateStart));
                sql_command.Parameters.Add(new SqlParameter("@dateEnd", dateEnd));
                sql_command.Parameters.Add(new SqlParameter("@overall_passed", overall_passed));
                sql_command.Parameters.Add(new SqlParameter("@overall_failed", overall_failed));
                sql_command.Parameters.Add(new SqlParameter("@overall_aborted", overall_aborted));
                sql_command.Parameters.Add(new SqlParameter("@serial_number", serial_number));
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sql_command);
                dataAdapter.Fill(dataTable);
                Form_devicehistory.instance.datagridsummary.DataSource = dataTable;

                await sql_command.ExecuteNonQueryAsync();
                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            finally
            {
                sql_connection.Close();
            }
        }

        public async Task<bool> SearchDeviceHist_SummaryView(string table_name)
        {
            try
            {
                query = $"SELECT * FROM {table_name}";

                await sql_connection.OpenAsync();

                sql_command = new SqlCommand(query, sql_connection);         
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sql_command);
                dataAdapter.Fill(dataTable);
                Form_devicehistory.instance.datagridsummary.DataSource = dataTable;

                await sql_command.ExecuteNonQueryAsync();
                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            finally
            {
                sql_connection.Close();
            }
        }

        public async Task<bool> Test_Start(string table_name, string Test_start)
        {
            try
            {
                query = $"INSERT INTO {table_name}(TEST_START) VALUES ('{Test_start}');";
                await sql_connection.OpenAsync();
                sql_command = new SqlCommand(query, sql_connection);              
                await sql_command.ExecuteNonQueryAsync();
                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            finally
            {
                sql_connection.Close();
            }
        }

        public async Task<bool> Test_End(string table_name, string Test_end)
        {
            try
            {           
                query = $"UPDATE {table_name} SET TEST_END = '{Test_end}' WHERE ID = " +
                $"(SELECT TOP 1 ID FROM tblCCU1SystemTest ORDER BY ID DESC);";
                await sql_connection.OpenAsync();
                sql_command = new SqlCommand(query, sql_connection);
                await sql_command.ExecuteNonQueryAsync();
                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            finally
            {
                sql_connection.Close();
            }
        }

        public async Task<byte[]> gettestlogPath(string SN, string table)
        {
            byte[] logpathBytes = null;
            try
            {
                query = $"SELECT top 1 LOG_FILE FROM {table} WHERE SERIAL_NUMBER = '{SN}' ORDER BY TEST_START DESC";
                sql_connection.Open();
                sql_command = new SqlCommand(query, sql_connection);
                sql_datareader = sql_command.ExecuteReader();

                if (sql_datareader.HasRows)
                {
                    while (sql_datareader.Read())
                    {
                        logpathBytes = (byte[])sql_datareader["LOG_FILE"];
                    }
                }
                return logpathBytes;
            }
            catch (Exception)
            {
                return logpathBytes;
                throw;
            }
            finally
            {
                sql_connection.Close();
            }
        }

        public void CloseConnection()
        {
            sql_connection.Close();
        }
    }
}