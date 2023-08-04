using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ccu1_illumigyn.Class
{
    internal class FileWatcher
    {
        public static FileSystemWatcher watcher;
        public static string[] stringSeparators = new string[] { "\n" };
        public static string currentString = "";
        public static string lastDateContent = "";
        public static int arrayLength = 0;
        public static string result = "";
        public static string sourceLocation = "";

        public static void StartFileWatcher(string source_location, int arrayLength_)
        {
            try
            {
                result = "";
                arrayLength = arrayLength_;
                sourceLocation = source_location;
                // Create a new FileSystemWatcher object
                watcher = new FileSystemWatcher
                {
                    // Set the path of the directory to watch
                    Path = source_location,

                    // Watch for changes in the directory
                    NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName,
                    IncludeSubdirectories = true
                };

                // Set the filter for the types of files to watch
                //watcher.Filter = "*.txt";

                // Subscribe to the events
                watcher.Created += OnCreated;
                watcher.Changed += OnChanged;
                watcher.Renamed += OnRenamed;
                watcher.Deleted += OnDeleted;

                // Start watching
                watcher.EnableRaisingEvents = true;
            }
            catch (Exception)
            {

            }
        }

        public static bool StopFileWatcher()
        {
            try
            {
                //Stop watching
                watcher.EnableRaisingEvents = false;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static void OnCreated(object source, FileSystemEventArgs e)
        {
            if (Directory.Exists(e.FullPath))
            {
                result = $"File created: {e.FullPath}";
            }
        }

        public static void OnChanged(object source, FileSystemEventArgs e)
        {
            while (true)
            {
                try
                {
                    currentString = "";
                    // Read the contents of the file
                    string content = File.ReadAllText(e.FullPath);
                    string stream_content = "";
                    // stream_content += $"File {e.FullPath} changed:";

                    string[] splitContent = content.Split(stringSeparators, StringSplitOptions.None);

                    for (int i = arrayLength; i <= splitContent.GetUpperBound(0); i++)
                    {
                        currentString = splitContent[i];
                        stream_content += currentString + Environment.NewLine;
                    }
                    result = stream_content;
                    arrayLength = splitContent.Length - 1;
                    break;
                }
                catch (Exception)
                {
                    Thread.Sleep(100);
                }
            }
        }

        public static void OnRenamed(object source, RenamedEventArgs e)
        {
            result = $"File renamed: {e.OldFullPath} to {e.FullPath}";
        }

        public static void OnDeleted(object source, FileSystemEventArgs e)
        {
            result = $"File deleted: {e.FullPath}";
        }

        public static string GetResult()
        {
            string output = result;
            result = "";
            return output;
        }

        public static int GetArrayLength()
        {
            return arrayLength;
        }
    }
}
