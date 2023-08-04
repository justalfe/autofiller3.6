using AutoFiller_APP.Entites;
using AutoFiller_APP.Model;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Forms;
using static ClosedXML.Excel.XLPredefinedFormat;

namespace AutoFiller_APP
{
    public partial class DbConfigForm : Form
    {
        public const string _conStr = "";
        public DbConfigForm()
        {
            InitializeComponent();
            ReadConfigFromFile();
        }

        void ReadConfigFromFile()
        {
            try
            {
                var rootPath = System.Windows.Forms.Application.StartupPath;


                var filetPath = rootPath + @"\DbManagment\DbConfig.json";

                var content = "";
                using (StreamReader reader = new StreamReader(new FileStream(filetPath, FileMode.Open)))
                {
                    content = reader.ReadToEnd();
                }

                var model = JsonConvert.DeserializeObject<ServerConfigModel>(content);
                if (model != null)
                {
                    txtServerName.Text = model.sql_server_name;
                    txt_database_name.Text = model.database_name;
                    txt_user_name.Text = model.sql_user_id;
                    txt_password.Text = model.sql_password;
                    txtWebServer.Text = model.web_server_url;
                    txtJotformUrl.Text = model.jotform_url;
                    txtJotApiKey.Text = model.jotform_api_key;
                    txtJotformID.Text = model.jotform_id.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_test_connection_Click(object sender, EventArgs e)
        {
            try
            {
                //validate form
                var isFormValid = true;
                if (string.IsNullOrEmpty(txtServerName.Text))
                {
                    isFormValid = false;
                    MessageBox.Show("Enter Server Name.");
                }

                if (string.IsNullOrEmpty(txt_database_name.Text))
                {
                    isFormValid = false;
                    MessageBox.Show("Enter Database Name.");
                }

                if (string.IsNullOrEmpty(txt_user_name.Text))
                {
                    isFormValid = false;
                    MessageBox.Show("Enter Sql Server UserName.");
                }

                if (string.IsNullOrEmpty(txt_password.Text))
                {
                    isFormValid = false;
                    MessageBox.Show("Enter Sql Server Password.");
                }
                if (string.IsNullOrEmpty(txtWebServer.Text))
                {
                    isFormValid = false;
                    MessageBox.Show("Enter Web Server Url.");
                }
                if (string.IsNullOrEmpty(txtJotApiKey.Text))
                {
                    isFormValid = false;
                    MessageBox.Show("Enter Jotform API key.");
                }
                if (string.IsNullOrEmpty(txtJotformID.Text))
                {
                    isFormValid = false;
                    MessageBox.Show("Enter Jotform ID.");
                }
                if (string.IsNullOrEmpty(txtJotformUrl.Text))
                {
                    txtJotformUrl.Text = "https://api.jotform.com/";
                }

                if (isFormValid)
                {
                    if (SaveConfigurations())
                    {
                        TestConnection();
                    }
                    else
                    {
                        MessageBox.Show("Unable to save configurations.");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured to save & test connection settings.");
            }
        }

        private bool SaveConfigurations()
        {
            var model = new ServerConfigModel()
            {
                database_name = txt_database_name.Text,
                sql_server_name = txtServerName.Text,
                sql_user_id = txt_user_name.Text,
                sql_password = txt_password.Text,
                web_server_url = txtWebServer.Text,
                jotform_url = txtJotformUrl.Text,
                jotform_api_key = txtJotApiKey.Text,
                jotform_id = string.IsNullOrEmpty(txtJotformID.Text) ? 0 : long.Parse(txtJotformID.Text)
            };


            var content = JsonConvert.SerializeObject(model);

            var startupPath = System.Windows.Forms.Application.StartupPath;

            var filetPath = startupPath + @"\DbManagment\DbConfig.json";

            File.WriteAllText(filetPath, content);

            return true;
        }
        private void TestConnection()
        {
            string _conStr = $"server={txtServerName.Text};database={txt_database_name.Text};uid={txt_user_name.Text};password={txt_password.Text};";
            try
            {
                using (SqlConnection connection = new SqlConnection(_conStr))
                {
                    connection.Open();
                    MessageBox.Show("You have been successfully connected to the SQL Database!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
