using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ccu1_illumigyn.Class
{
    internal class class_filedelete
    {
        public static void Fdelete()
        {
            string folderPath = "C:\\tmp\\Illumigyn\\test";
            try
            {
                // Check if the folder exists
                if (Directory.Exists(folderPath))
                {
                    // Delete the folder and its contents recursively
                    Directory.Delete(folderPath, true);
                    return;
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                return;
            }
        }

        //public static int Filecounter(int counter)
        //{
        //    string foldername = class_filedelete.FolderWatcher();
        //    string folderPath = "C:\\tmp\\Illumigyn\\test\\" + foldername;
        //    if (Directory.Exists(folderPath))
        //    {
        //        string[] fileNames = Directory.GetFiles(folderPath);

        //        foreach (string fileName in fileNames)
        //        {
        //            Console.WriteLine(Path.GetFileName(fileName));
        //            counter++;
        //        }
        //    }
        //    else
        //    {
        //    }
        //    return counter;
        //}

        public static int Filecounter()
        {
            int counter = 0;
            string foldername = class_filedelete.FolderWatcher();
            string folderPath = "C:\\tmp\\Illumigyn\\test\\" + foldername;
            if (Directory.Exists(folderPath))
            {
                string[] fileNames = Directory.GetFiles(folderPath);
                counter = fileNames.Length;
            }

            return counter;
        }

        public static string FolderWatcher()
        {
            string folderPath = "C:\\tmp\\Illumigyn\\test";
            string mainfoldername = string.Empty;
            while (true)
            {
                if (Directory.Exists(folderPath))
                {
                    string[] folderNames = Directory.GetDirectories(folderPath);
                    foreach (string folderName in folderNames)
                    {
                        mainfoldername = Path.GetFileName(folderName);
                        break;
                    }
                    return mainfoldername;
                }
                else
                {                  
                    return mainfoldername;
                }
            }
        }
    }
}
