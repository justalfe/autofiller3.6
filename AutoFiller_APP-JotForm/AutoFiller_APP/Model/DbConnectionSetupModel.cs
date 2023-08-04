using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFiller_APP.Model
{
    public class DbConnectionSetupModel
    {
        private string _connectionString;
        public static string ConnectionString
        {
            get
            {
                return BuildConnectionString();
            }
        }

        private static string BuildConnectionString()
        {
            var rootPath = System.Windows.Forms.Application.StartupPath;


            var filetPath = rootPath + @"\DbManagment\DbConfig.json";
            var content = "";
            using (StreamReader reader = new StreamReader(new FileStream(filetPath, FileMode.Open)))
            {
                content = reader.ReadToEnd();
            }

            var model = JsonConvert.DeserializeObject<ServerConfigModel>(content);


            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = model.sql_server_name,
                InitialCatalog = model.database_name,
                MultipleActiveResultSets = true,
            };

            sqlConnectionStringBuilder.UserID = model.sql_user_id;
            sqlConnectionStringBuilder.Password = model.sql_password;
            sqlConnectionStringBuilder.IntegratedSecurity = false;
            
            //Entityramework connection string builder
            EntityConnectionStringBuilder entityConnectionStringBuilder = new EntityConnectionStringBuilder()
            {
                Provider = "System.Data.SqlClient",
                Metadata = @"res://*/Entites.DBUtilityModel.csdl|res://*/Entites.DBUtilityModel.ssdl|res://*/Entites.DBUtilityModel.msl",
                ProviderConnectionString = sqlConnectionStringBuilder.ToString()
            };
            return entityConnectionStringBuilder.ToString();
        }
    }
}
