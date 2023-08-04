using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ccu1_illumigyn.Class.class_globals;
using ccu1_illumigyn.Class;

namespace ccu1_illumigyn.Class
{
    public class class_saveLogs
    {
        SaveFileDialog SaveFileDialog1;

        public class_saveLogs()
        {
        }

        public async Task<bool> SaveTextLogs(string folderLocation, string serialNumber, string startDate, string endDate, string operatorName, string overall, string raw_log, string randomChar)
        {
            try
            {
                await createDirectory(folderLocation);
                File.WriteAllText(folderLocation + serialNumber + "_" + randomChar, raw_log);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task createDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            }
        }

        public async Task<bool> ExportData()
        {
            SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            SaveFileDialog1.FileName = "CCU1_Test_";
            overall = string.Empty;

            try
            {
                if(Form_devicehistory.instance.datagrid1.Rows.Count > 0)
                {                
                    if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        StringBuilder sb = new StringBuilder();

                        // Build the header row
                        foreach (DataGridViewColumn column in Form_devicehistory.instance.datagrid1.Columns)
                        {
                            sb.Append(column.HeaderText + ",");
                        }

                        // Remove the last comma
                        sb.Remove(sb.Length - 1, 1);

                        // Add a new line
                        sb.Append("\r\n");

                        // Build the data rows
                        foreach (DataGridViewRow row in Form_devicehistory.instance.datagrid1.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                sb.Append(cell.Value + ",");
                            }

                            sb.Remove(sb.Length - 1, 1); // Remove the last comma
                            sb.Append("\r\n"); // Add a new line
                        }
                   
                        if (await exportTestLog(SaveFileDialog1.FileName, sb.ToString(), ""))
                        {
                            MessageBox.Show("Database export completed !", "Database View", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }

                        else
                        {
                            MessageBox.Show("Database export failed !", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }                   
                    }
                }
                else
                {
                    MessageBox.Show("The Data Grid is empty!", "Database View", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            return true;
        }

        public async Task <bool> exportTestLog(string FilePath, string text, string serialNumber)
        {
            try
            {
                File.WriteAllText(FilePath, text);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
    }
}