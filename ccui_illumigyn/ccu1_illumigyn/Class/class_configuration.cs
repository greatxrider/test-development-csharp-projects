using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ccu1_illumigyn.Class
{
    public class class_configuration
    {
        public string config_location;  // The file path for the .ini file
        public string config_name;      // The config file name
        public string[] key_name;       // The name of parameter
        public Control[] key_value;      // The value of the parameter
        public Dictionary<string, string> config_dictionary; // The dictionary declaration

        // Declare the WritePrivateProfileString function from the Windows API
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string value, string filePath);

        // Declare the GetPrivateProfileString function from the Windows API
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defaultValue, StringBuilder value, int size, string filePath);

        // Constructor that sets the config file location
        public class_configuration(string configLocation, string configName, string[] configParameters, ref Dictionary<string, string> configDictionary)
        {
            config_location = configLocation;
            config_name = configName;
            key_name = configParameters;
            config_dictionary = configDictionary;
        }

        // Constructor that gets the config file location, name and values
        public class_configuration(string configLocation, string configName, string[] configKey, Control[] configValue, ref Dictionary<string, string> configDictionary)
        {
            config_location = configLocation;
            config_name = configName;
            key_name = configKey;
            key_value = configValue;
            config_dictionary = configDictionary;
        }

        // Method that saves a key-value pair to the .ini file
        public void WriteIni(string sectionName, string keyName, string value)
        {
            // Call the WritePrivateProfileString function to save the key-value pair
            WritePrivateProfileString(sectionName, keyName, value, config_location);
        }

        // Method that reads a key-value pair from the .ini file
        public string ReadIni(string sectionName, string keyName)
        {
            // Create a StringBuilder object to store the value
            StringBuilder value = new StringBuilder(1024);
            // Call the GetPrivateProfileString function to read the key-value pair
            GetPrivateProfileString(sectionName, keyName, "", value, value.Capacity, config_location);
            // Return the value as a string
            return value.ToString();
        }

        // Method that writes the configuration currently in use
        public bool writeConfiginUse(string sectionName, string keyName, string keyValue)
        {
            try
            {
                WriteIni(sectionName, keyName, keyValue);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in writing Configuration Values." + Environment.NewLine + ex.Message, "Default Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Method that reads the configuration currently in use
        public string readConfiginUse()
        {
            // Read the key-value pair from the .ini file 'Default' section 
            return ReadIni("Config in Use", "configInUse");
        }

        //Method that adds the key name and values to the dictionary
        public bool setDictionary(string sectionName)
        {
            config_dictionary.Clear();
            try
            {
                for (int i = 0; i <= key_name.Length - 1; i++)
                {
                    config_dictionary.Add(key_name[i], ReadIni(sectionName, key_name[i]));
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in setting dictionary in Configuration." + Environment.NewLine + ex.Message, "Configuration Dictionary", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
