using AutoFiller_APP.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutoFiller_APP
{
    class Utility
    {
        public const string SETTINGS_FILENAME = "./DbManagment/DbConfig.json";        

        public class Constants
        {
            public const string NO_ENTRY_SELECTED = "Please select an Entry";
            public const string UNABLE_TO_DELETE = "Unable to Delete the Entry";
            public const string UNABLE_TO_RETRIEVE_DATA = "Unable to Retrieve any Server Data";
        }

        public static string GetServerString()
        {
            var rootPath = System.Windows.Forms.Application.StartupPath;


            var filetPath = rootPath + @"\DbManagment\DbConfig.json";
            var content = "";
            using (StreamReader reader = new StreamReader(new FileStream(filetPath, FileMode.Open)))
            {
                content = reader.ReadToEnd();
            }

            var model = JsonConvert.DeserializeObject<ServerConfigModel>(content);
            string _conStr = $"server={model.sql_server_name};database={model.database_name};uid={model.sql_user_id};password={model.sql_password};";
            return _conStr;
        }
        public static string GetStates()
        {
            var rootPath = System.Windows.Forms.Application.StartupPath;


            var filetPath = rootPath + @"\DbManagment\states.json";
            var content = "";
            using (StreamReader reader = new StreamReader(new FileStream(filetPath, FileMode.Open)))
            {
                content = reader.ReadToEnd();
            }
            return content;
        }

        public static ServerConfigModel GetConfigData()
        {
            var rootPath = System.Windows.Forms.Application.StartupPath;

            var filetPath = rootPath + @"\DbManagment\DbConfig.json";
            var content = "";
            using (StreamReader reader = new StreamReader(new FileStream(filetPath, FileMode.Open)))
            {
                content = reader.ReadToEnd();
            }

            var model = JsonConvert.DeserializeObject<ServerConfigModel>(content);
            return model;
        }

        public static Random _random = new Random();

        public static string GenerateSringToken()
        {
            Random rnd = new Random();
            string token = "";
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            for (int i = 0; i < 64; i++)
            {
                token += characters[_random.Next(characters.Length)];
            }
            return token;
        }
        public static string GetNumbers(string str)
        {
            var result = "";
            if (str != null)
                result = String.Join("", str.ToCharArray().Where(Char.IsDigit));
            return result;
        }
    }
}
